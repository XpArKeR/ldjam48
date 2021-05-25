using System;
using System.Collections.ObjectModel;
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

            this.Oxygen = new ResourceStatistic()
            {
                Name = nameof(PlanetResources.Oxygen)
            };

            this.Food = new ResourceStatistic()
            {
                Name = nameof(PlanetResources.Food)
            };

            this.Fuel = new ResourceStatistic()
            {
                Name = nameof(PlanetResources.Fuel)
            };
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

        private ResourceStatistic oxygen;
        public ResourceStatistic Oxygen
        {
            get
            {
                return this.oxygen;
            }
            private set
            {
                SetProperty(ref this.oxygen, value);
            }
        }

        private ResourceStatistic food;
        public ResourceStatistic Food
        {
            get
            {
                return this.food;
            }
            private set
            {
                SetProperty(ref this.food, value);
            }
        }

        private ResourceStatistic fuel;
        public ResourceStatistic Fuel
        {
            get
            {
                return this.fuel;
            }
            private set
            {
                SetProperty(ref this.fuel, value);
            }
        }

        private ObservableCollection<Planet> planets = new ObservableCollection<Planet>();
        public ObservableCollection<Planet> Planets
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

                    this.AddResources(planet.Resources);

                    return true;
                }
            }

            return false;
        }

        private void AddResources(PlanetResources planetResource)
        {
            this.AddResource(this.Oxygen, planetResource.Oxygen);
            this.AddResource(this.Food, planetResource.Food);
            this.AddResource(this.Fuel, planetResource.Fuel);
        }

        private void AddResource(ResourceStatistic resourceStatistic, PlanetResource resource)
        {
            if (resource.Value < resourceStatistic.MinValue)
            {
                resourceStatistic.MinValue = resource.Value;
            }
            else if (resource.Value > resourceStatistic.MaxValue)
            {
                resourceStatistic.MaxValue = resource.Value;
            }

            resourceStatistic.AverageValue = (resourceStatistic.Amount * resourceStatistic.AverageValue + resource.Value) / ++resourceStatistic.Amount;
        }
    }
}
