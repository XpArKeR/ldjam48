using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class StarmapEntry
    {
        public StarmapEntry(List<Planet> planets)
        {
            this.AvailablePlanets = planets;
        }

        private List<Planet> availablePlanets;
        public List<Planet> AvailablePlanets
        {
            get
            {
                return this.availablePlanets;
            }
            private set
            {
                if (this.availablePlanets != value)
                {
                    this.availablePlanets = value;
                }
            }
        }
    }
}
