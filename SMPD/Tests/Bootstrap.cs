using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using SMPD.Classifiers;
using SMPD.Extensions;

namespace SMPD.Tests
{
    class Bootstrap<T> : ClassifierTestter<T> where T : ClassifierBase, new()
    {
        public Bootstrap(List<MapleSample> samples, int k) : base(samples, k)
        {
        }

        public double Test(int nParts, int times)
        {
            var results = new List<double>();
            for (int i = 0; i < times; i++)
            {
                var result = this.Test(nParts);
                results.Add(result);
            }

            return results.Average();
        }

        public override double Test(int nParts)
        {
            this._samples.Shuffle();
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
                    .Where(x => !string.IsNullOrEmpty(x.label))
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
