using System;

namespace SMPD.FeatureSelection
{
    public abstract class SelektorCech
    {
        protected int LiczbaCech;

        protected SelektorCech(int liczbaCech)
        {
            this.LiczbaCech = liczbaCech;
        }
    }
}