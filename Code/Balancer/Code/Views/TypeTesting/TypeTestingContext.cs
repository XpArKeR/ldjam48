using System;
using System.Collections.Generic;

using Balancer.Model.Planets;

namespace Balancer.Views.TypeTesting
{
    public class TypeTestingContext : BaseContext
    {
        private Boolean? dialogResult;
        public Boolean? DialogResult
        {
            get
            {
                return this.dialogResult;
            }
            set
            {
                SetProperty(ref this.dialogResult, value);
            }
        }

        private List<PlanetType> planetTypes;
        public List<PlanetType> PlanetTypes
        {
            get
            {
                return this.planetTypes;
            }
            set
            {
                SetProperty(ref this.planetTypes, value);
            }
        }
    }
}
