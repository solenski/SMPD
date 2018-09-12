using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Extensions.Statistics;
using Accord.Math;
using Accord.Statistics;

namespace SMPD.Klasyfikatory
{
    public class KlasyfikatorNajblizszejSredniej : Klasyfikator
    {
        private double[] _pierwszaSrednia;
        private double[] _drugaSrednia;

        public KlasyfikatorNajblizszejSredniej()
        {
            
        }
        public KlasyfikatorNajblizszejSredniej(double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, inputs, outputs, distance)
        {
        }

        public KlasyfikatorNajblizszejSredniej(int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, classes, inputs, outputs, distance)
        {
        }

        public override void Trenuj(int k, int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance)
        {
            var firstclass = inputs.Where((x, index) => outputs[index] == 0).ToArray();
            var secondClass = inputs.Where((x, index) => outputs[index] == 1).ToArray();

            this._pierwszaSrednia = firstclass.Mean(0);
            this._drugaSrednia = secondClass.Mean(0);
        }

        public override int Klasyfikuj(double[] input)
        {
            var distanceToFirstClass = Distance.Euclidean(_pierwszaSrednia, input);
            var distanceToSecondClass = Distance.Euclidean(_drugaSrednia, input);
            return distanceToFirstClass > distanceToSecondClass ? 1 : 0;
        }
    }

}
