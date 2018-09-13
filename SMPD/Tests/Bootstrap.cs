using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using SMPD.Klasyfikatory;
using SMPD.Extensions;

namespace SMPD.Tests
{
    class Bootstrap<T> : TesterKlasyfikatorów where T : Klasyfikator, new()
    {
        public Bootstrap(List<MapleProbki> probki, int k) : base(probki, k)
        {
        }

        public virtual double Test(int times)
        {
            var testCollection = new List<MapleProbki>();

            for (var i = 0; i < times; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    this._probki.Shuffle();
                    testCollection.Add(this._probki.First());
                }
            }
            var accs = new List<double>();

            var uut = new T();
            var inputs = this._probki
                .SelectMany(x => x.samples).ToArray();
            var outputs = this._probki
                .Where(x => !string.IsNullOrEmpty(x.label))
                .SelectMany(x => x.label, (sample, c) => sample.label.StartsWith("Acer") ? 0 : 1)
                .ToArray();

            uut.Trenuj(_k, 2, inputs, outputs, Distance.Euclidean);
            var results = testCollection.SelectMany(x => x.samples).Select(x => uut.Klasyfikuj(x)).ToArray();
            accs.Add(testCollection.Select(x => x.label.StartsWith("Acer") ? 0 : 1).Where((t, i) => t == results[i]).Count() / (double)testCollection.Count);
            return accs.Average() * 100;
        }
    }

}
