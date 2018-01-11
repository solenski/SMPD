using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace SMPD.FeatureSelection
{
    public class SequentialForwardSelector : FeatureSelector
    {
        private Func<IEnumerable<IEnumerable<double>>, IEnumerable<IEnumerable<double>>, FeatureSelectorResult> _criterionFunction;

        public SequentialForwardSelector(int featureCount, IProgress<(int, int)> progress, Func<IEnumerable<IEnumerable<double>>, IEnumerable<IEnumerable<double>>, FeatureSelectorResult> criterionFunction) : base(featureCount, progress)
        {
            _criterionFunction = criterionFunction;
        }

        public override FeatureSelectorResult SelectFeatures(IEnumerable<IEnumerable<double>> samplesA, IEnumerable<IEnumerable<double>> samplesB)
        {
            var samplesAList = samplesA.ToList();
            var samplesBList = samplesB.ToList();


            var best = new FeatureSelectorResult { CriterionValue = 0, Features = new int[] { } };


            while (best.Features.Length < this.FeatureCount)
            {
                var bestSoFar = new FeatureSelectorResult { CriterionValue = 0, Features = new int[] { } };

                for (var i = 0; i < samplesAList.First().Count(); i++)
                {
                    var selectedFeaturesA = samplesAList.Select(x =>
                            x.Where((_, index) => best.Features.Contains(index) || index == i).ToArray())
                        .ToArray();
                    var selectedFeaturesB = samplesBList.Select(x =>
                            x.Where((_, index) => best.Features.Contains(index) || index == i).ToArray())
                        .ToArray();

                    var result = this._criterionFunction(selectedFeaturesA, selectedFeaturesB);

                    if (bestSoFar.CriterionValue < result.CriterionValue)
                    {
                        bestSoFar = new FeatureSelectorResult
                        {
                            CriterionValue = result.CriterionValue,
                            Features = new HashSet<int>(best.Features.Concat(new[] { i })).ToArray()
                        };
                    }

                }

                best = bestSoFar;
                this.Progress.Report((best.Features.Length, this.FeatureCount));

            }

            return best;
        }


    }
}

