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
    public class FisherFeatureSelector : FeatureSelector
    {
        public FisherFeatureSelector(int featureCount, IProgress<(int, int)> progress) : base(featureCount, progress)
        {
        }

        public override FeatureSelectorResult SelectFeatures(IEnumerable<IEnumerable<double>> samplesA, IEnumerable<IEnumerable<double>> samplesB)
        {
            var samplesAList = samplesA.ToList();
            var samplesBList = samplesB.ToList();

            var range = Enumerable.Range(0, samplesAList.First().Count()).ToArray();
            List<int[]> combinations;

            if (range.Length > FeatureCount)
            {
                combinations = range.Combinations(FeatureCount).ToList();
            }
            else
            {
                combinations = range.Combinations().ToList();
            }
            var featureSelectorResults = new List<FeatureSelectorResult>();

            foreach (var combination in combinations.Select((x, index) => new { comb = x, index }))
            {
                var selectedFeaturesA = samplesAList.Select(x => x.Where((_, index) => combination.comb.Contains(index)).ToArray()).ToArray();
                var selectedFeaturesB = samplesBList.Select(x => x.Where((_, index) => combination.comb.Contains(index)).ToArray()).ToArray();
                var meansA = selectedFeaturesA.Mean(0);
                var meansB = selectedFeaturesB.Mean(0);
                var covarianceA = selectedFeaturesA.Covariance().ToMatrix();
                var covarianceB = selectedFeaturesB.Covariance().ToMatrix();
                var fisher = meansA.Subtract(meansB).Abs().Euclidean() /
                             (covarianceA.Determinant() + covarianceB.Determinant());


                featureSelectorResults.Add(new FeatureSelectorResult { Features = combination.comb, CriterionValue = fisher });
                this.Progress.Report((combination.index, combinations.Count));
            }

            return featureSelectorResults.MaxBy(x => x.CriterionValue);
        }


    }
}
