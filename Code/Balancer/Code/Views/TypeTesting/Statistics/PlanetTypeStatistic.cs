using System;
using System.Collections.Generic;
using System.Linq;

using Balancer.Model;
using Balancer.Model.Planets;

namespace Balancer.Views.TypeTesting.Statistics
{
    public class PlanetTypeStatistic : NotifyingObject
    {
        private Object locker = new Object();

        public PlanetTypeStatistic(PlanetType planetType)
        {
            this.PlanetType = planetType;
        }

        private PlanetType planetType;
        public PlanetType PlanetType
        {
            get
            {
                return this.planetType;
            }
            private set
            {
                SetProperty(ref this.planetType, value);
            }
        }

        private List<Planet> planets = new List<Planet>();
        public List<Planet> Planets
        {
            get
            {
                return this.planets;
            }
        }

        public Boolean Add(Planet planet)
        {
            lock (locker)
            {
                if (!this.Planets.Any(p => p.ID == planet.ID))
                {
                    this.Planets.Add(planet);

                    return true;
                }
            }

            return false;
        }
    }
}
