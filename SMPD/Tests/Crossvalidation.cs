using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using MoreLinq;
using SMPD.Classifiers;
using SMPD.Extensions;

namespace SMPD.Tests
{
    public abstract class ClassifierTestter<T> where T : ClassifierBase, new()
    {
        protected List<MapleSample> _samples;
        protected int _k;

        public ClassifierTestter(List<MapleSample> samples, int k)
        {
            _samples = samples.Where(x => x.label.StartsWith("Acer") || x.label.StartsWith("Quercus")).ToList();
            _k = k;
        }

        public abstract double Test(int nParts);
    }

    public class Crossvalidation<T> : ClassifierTestter<T> where T : ClassifierBase, new()
    {
        public Crossvalidation(List<MapleSample> samples, int k) : base(samples, k)
        {
        }

        public override double Test(int nParts)
        {
            var splitted = this._samples.Split(nParts).ToList();
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

                uut.Train(_k, 2, inputs, outputs, Distance.Euclidean);
                var results = partList.SelectMany(x => x.samples).Select(x => uut.Execute(x)).ToArray();
                accs.Add(partList.Select(x => x.label.StartsWith("Acer") ? 0 : 1).Where((t, i) => t == results[i]).Count() / (double)partList.Count);
            }
            return accs.Average() * 100;
        }
    }
}
