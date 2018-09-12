using System;
using Accord.Math;

namespace SMPD.Klasyfikatory
{
    public class KlasyfikatorKNN : Klasyfikator
    {
 
        private double[] odleglosci;

        private int k;


        public KlasyfikatorKNN(int k, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(
            k, inputs, outputs, distance)
        {
        }


        public KlasyfikatorKNN(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance) : base(k, classes, inputs, outputs, distance)
        {
        }

        public KlasyfikatorKNN()
        {
        }


        public double[][] Inputs { get; private set; }

        public int[] Outputs { get; private set; }


        public int ClassCount { get; private set; }


        public Func<double[], double[], double> Distance { get; set; }


        public override void Trenuj(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance)
        {
            Inputs = inputs;
            Outputs = outputs;

            this.k = k;
            ClassCount = classes;

            Distance = distance;
            odleglosci = new double[inputs.Length];
        }


        public override int Klasyfikuj(double[] input)
        {
            for (var i = 0; i < Inputs.Length; i++)
                odleglosci[i] = Distance(input, Inputs[i]);

            var idx = odleglosci.Bottom(k, true);

            var scores = new double[ClassCount];

            for (var i = 0; i < idx.Length; i++)
            {
                var j = idx[i];

                var label = Outputs[j];
                var d = odleglosci[i];

                scores[label] += 1.0 / (1.0 + d);
            }

            scores.Max(out var result);

            return result;
        }
    }
}