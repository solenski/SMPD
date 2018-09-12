using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Extensions.Math;
using Accord.Math;
using Accord.Statistics;
using Accord.Statistics.Kernels;
using MoreLinq;

namespace SMPD.FeatureSelection
{
    public class FisherSelektorCech : SelektorCech
    {
        public FisherSelektorCech(int liczbaCech) : base(liczbaCech)
        {
        }

        public virtual WynikSelektoraCech WyselekcjonujCechy(IEnumerable<IEnumerable<double>> probkiKlasyA, IEnumerable<IEnumerable<double>> probkiKlasyB)
        {
            var probkiALista = probkiKlasyA.ToList();
            var probkiBLista = probkiKlasyB.ToList();

            var mozliweCechy = Enumerable.Range(0, probkiALista.First().Count()).ToArray();

            var kombinacje = mozliweCechy.Length > LiczbaCech ? mozliweCechy.Combinations(LiczbaCech).ToList() : mozliweCechy.Combinations().ToList();
            var wyniki = new List<WynikSelektoraCech>();

            foreach (var kombinacja in kombinacje.Select((x, index) => new { komb = x, index }))
            {
                var wybraneCechyKlasyA = probkiALista.Select(x => x.Where((_, index) => kombinacja.komb.Contains(index)).ToArray()).ToArray();
                var wybraneCechyKlasyB = probkiBLista.Select(x => x.Where((_, index) => kombinacja.komb.Contains(index)).ToArray()).ToArray();
                var macierzSrednichA = wybraneCechyKlasyA.Mean(0);
                var macierzSrednichB = wybraneCechyKlasyB.Mean(0);
                var kowariancjaA = wybraneCechyKlasyA.Covariance().ToMatrix();
                var kowariancjaB = wybraneCechyKlasyB.Covariance().ToMatrix();
                var fisher = macierzSrednichA.Subtract(macierzSrednichB).Abs().Euclidean() /
                             (kowariancjaA.Determinant() + kowariancjaB.Determinant());


                wyniki.Add(new WynikSelektoraCech { Features = kombinacja.komb, WynikSelektora = fisher });
            }

            return wyniki.MaxBy(x => x.WynikSelektora);
        }


    }
}
