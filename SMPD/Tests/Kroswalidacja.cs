using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using MoreLinq;
using SMPD.Klasyfikatory;
using SMPD.Extensions;

namespace SMPD.Tests
{
    public abstract class TesterKlasyfikatorów
    {
        protected List<MapleProbki> _probki;
        protected int _k;

        protected TesterKlasyfikatorów(List<MapleProbki> probki, int k)
        {
            _probki = probki.Where(x => x.label.StartsWith("Acer") || x.label.StartsWith("Quercus")).ToList();
            _k = k;
        }
    }

    public class Kroswalidacja<T> : TesterKlasyfikatorów where T : Klasyfikator, new()
    {
        public Kroswalidacja(List<MapleProbki> probki, int k) : base(probki, k)
        {
        }

        public virtual double Test(int nParts)
        {
            var splitted = this._probki.PodzielNaGrupyPoN(nParts).ToList();
            var accs = new List<double>();
            foreach (var part in splitted)
            {
                var partList = part.ToList();
                var uut = new T();
                var inputs = splitted
                    .Where(x => !Equals(x, partList))
                    .SelectMany(x => x)
                    .SelectMany(x => x.samples).ToArray();
                var outputs = splitted
                    .Where(x => !Equals(x, partList))
                    .SelectMany(x => x)
                    .Where(x=> !string.IsNullOrEmpty(x.label))
                    .SelectMany(x => x.label, (sample, c) => sample.label.StartsWith("Acer") ? 0 : 1)
                    .ToArray();

                uut.Trenuj(_k, 2, inputs, outputs, Distance.Euclidean);
                var results = partList.SelectMany(x => x.samples).Select(x => uut.Klasyfikuj(x)).ToArray();
                accs.Add(partList.Select(x => x.label.StartsWith("Acer") ? 0 : 1).Where((t, i) => t == results[i]).Count() / (double)partList.Count);
            }
            return accs.Average() * 100;
        }
    }
}
