using System;
using System.Collections.Generic;

namespace SMPD.FeatureSelection
{
    public abstract class FeatureSelector
    {
        protected int FeatureCount;
        protected IProgress<(int, int)> Progress;

        protected FeatureSelector(int featureCount, IProgress<(int, int)> progress)
        {
            this.FeatureCount = featureCount;
            this.Progress = progress;
        }

        public abstract FeatureSelectorResult SelectFeatures(IEnumerable<IEnumerable<double>> samplesA, IEnumerable<IEnumerable<double>> samplesB);
    }
}