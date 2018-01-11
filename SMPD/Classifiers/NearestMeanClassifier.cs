using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Extensions.Statistics;
using Accord.Math;
using Accord.Statistics;

namespace SMPD.Classifiers
{
    public class NearestMeanClassifier : ClassifierBase
    {
        private double[] _firstCentroid;
        private double[] _secondCentroid;

        public NearestMeanClassifier()
        {
            
        }
        public NearestMeanClassifier(double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, inputs, outputs, distance)
        {
        }

        public NearestMeanClassifier(int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, classes, inputs, outputs, distance)
        {
        }

        public override void Train(int k, int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance)
        {
            var firstclass = inputs.Where((x, index) => outputs[index] == 0).ToArray();
            var secondClass = inputs.Where((x, index) => outputs[index] == 1).ToArray();

            this._firstCentroid = firstclass.Mean(0);
            this._secondCentroid = secondClass.Mean(0);
        }

        public override int Execute(double[] input)
        {
            var distanceToFirstClass = Distance.Euclidean(_firstCentroid, input);
            var distanceToSecondClass = Distance.Euclidean(_secondCentroid, input);
            return distanceToFirstClass > distanceToSecondClass ? 1 : 0;
        }
    }

}
