using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPD.Classifiers
{
    public class NNClassifier : KnnClassifier
    {
        public NNClassifier()
        {
            
        }
        public NNClassifier(double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, inputs, outputs, distance)
        {
        }

        public NNClassifier(int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, classes, inputs, outputs, distance)
        {
        }
    }
}
