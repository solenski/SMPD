using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPD.Klasyfikatory
{
    public class KlasyfikatorNajblizszegoSasiada : KlasyfikatorKNN
    {
        public KlasyfikatorNajblizszegoSasiada()
        {
            
        }
        public KlasyfikatorNajblizszegoSasiada(double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, inputs, outputs, distance)
        {
        }

        public KlasyfikatorNajblizszegoSasiada(int classes, double[][] inputs, int[] outputs, Func<double[], double[], double> distance) : base(1, classes, inputs, outputs, distance)
        {
        }
    }
}
