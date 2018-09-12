using System;
using System.Linq;
using Accord.Math;

namespace SMPD.Klasyfikatory
{
    public abstract class Klasyfikator
    {

        public Klasyfikator()
        {
            
        }
        protected Klasyfikator(int k, double[][] inputs, int[] outputs, Func<double[], double[], double> distance)
        {
            var classCount = outputs.Distinct().Count();

            Trenuj(k, classCount, inputs, outputs, distance);
        }

        protected Klasyfikator(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance) => Trenuj(k, classes, inputs, outputs, distance);

        public abstract void Trenuj(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance);

        public abstract int Klasyfikuj(double[] input);
    }
}