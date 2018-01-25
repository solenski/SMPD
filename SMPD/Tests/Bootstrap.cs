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

        public override double Test(int times)
        {
            var testCollection = new List<MapleSample>();

            for (var i = 0; i < times; i++)
            {
                this._samples.Shuffle();
                testCollection.Add(this._samples.First());
            }
            var accs = new List<double>();

            var uut = new T();
            var inputs = this._samples
                .SelectMany(x => x.samples).ToArray();
            var outputs = this._samples
                .Where(x => !string.IsNullOrEmpty(x.label))
                .SelectMany(x => x.label, (sample, c) => sample.label.StartsWith("Acer") ? 0 : 1)
                .ToArray();

            uut.Train(_k, 2, inputs, outputs, Distance.Euclidean);
            var results = testCollection.SelectMany(x => x.samples).Select(x => uut.Execute(x)).ToArray();
            accs.Add(testCollection.Select(x => x.label.StartsWith("Acer") ? 0 : 1).Where((t, i) => t == results[i]).Count() / (double)testCollection.Count);
            return accs.Average() * 100;
        }
}

}
