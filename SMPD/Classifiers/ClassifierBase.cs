using System;
using System.Linq;
using Accord.Math;

namespace SMPD.Classifiers
{
    public abstract class ClassifierBase
    {
        public ClassifierBase()
        {
                
        }
       
        protected ClassifierBase(int k, double[][] inputs, int[] outputs, Func<double[], double[], double> distance)
        {
            var classCount = outputs.Distinct().Count();

            Train(k, classCount, inputs, outputs, distance);
        }

        protected ClassifierBase(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance) => Train(k, classes, inputs, outputs, distance);

        public abstract void Train(int k, int classes, double[][] inputs, int[] outputs,
            Func<double[], double[], double> distance);

        public abstract int Execute(double[] input);
    }
}