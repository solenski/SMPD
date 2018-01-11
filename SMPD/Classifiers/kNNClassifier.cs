using System;
using Accord.Math;

namespace SMPD.Classifiers
{
    public class KnnClassifier : ClassifierBase
    {
        public KnnClassifier()
        {
            
        }
        private double[] distances;

        private int k;


        public KnnClassifier(int k, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(
            k, inputs, outputs, distance)
        {
        }


        public KnnClassifier(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance) : base(k, classes, inputs, outputs, distance)
        {
        }


        public double[][] Inputs { get; private set; }

        public int[] Outputs { get; private set; }


        public int ClassCount { get; private set; }


        public Func<double[], double[], double> Distance { get; set; }


        public int K
        {
            get => k;
            set
            {
                if (value <= 0 || value > Inputs.Length)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The value for k should be greater than zero and less than total number of input points.");

                k = value;
            }
        }

        public override void Train(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance)
        {
            Inputs = inputs;
            Outputs = outputs;

            this.k = k;
            ClassCount = classes;

            Distance = distance;
            distances = new double[inputs.Length];
        }


        public override int Execute(double[] input)
        {
            for (var i = 0; i < Inputs.Length; i++)
                distances[i] = Distance(input, Inputs[i]);

            var idx = distances.Bottom(k, true);

            var scores = new double[ClassCount];

            for (var i = 0; i < idx.Length; i++)
            {
                var j = idx[i];

                var label = Outputs[j];
                var d = distances[i];

                scores[label] += 1.0 / (1.0 + d);
            }

            scores.Max(out var result);

            return result;
        }
    }
}