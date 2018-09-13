using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace SMPD.FeatureSelection
{
    public class SelektorSFS : SelektorCech
    {
        private Func<IEnumerable<IEnumerable<double>>, IEnumerable<IEnumerable<double>>, WynikSelektoraCech> _criterionFunction;

        public SelektorSFS(int liczbaCech, Func<IEnumerable<IEnumerable<double>>, IEnumerable<IEnumerable<double>>, WynikSelektoraCech> criterionFunction) : base(liczbaCech)
        {
            _criterionFunction = criterionFunction;
        }

        public virtual WynikSelektoraCech SelectFeatures(IEnumerable<IEnumerable<double>> samplesA, IEnumerable<IEnumerable<double>> samplesB)
        {
            var samplesAList = samplesA.ToList();
            var samplesBList = samplesB.ToList();


            var best = new WynikSelektoraCech { WynikSelektora = 0, Features = new int[] { } };


            while (best.Features.Length < this.LiczbaCech)
            {
                var bestSoFar = new WynikSelektoraCech { WynikSelektora = 0, Features = new int[] { } };

                for (var i = 0; i < samplesAList.First().Count(); i++)
                {
                    var selectedFeaturesA = samplesAList.Select(x =>
                            x.Where((_, index) => best.Features.Contains(index) || index == i).ToArray())
                        .ToArray();
                    var selectedFeaturesB = samplesBList.Select(x =>
                            x.Where((_, index) => best.Features.Contains(index) || index == i).ToArray())
                        .ToArray();

                    var result = this._criterionFunction(selectedFeaturesA, selectedFeaturesB);

                    if (bestSoFar.WynikSelektora < result.WynikSelektora)
                    {
                        bestSoFar = new WynikSelektoraCech
                        {
                            WynikSelektora = result.WynikSelektora,
                            Features = new HashSet<int>(best.Features.Concat(new[] { i })).ToArray()
                        };
                    }

                }

                best = bestSoFar;

            }

            return best;
        }


    }
}

