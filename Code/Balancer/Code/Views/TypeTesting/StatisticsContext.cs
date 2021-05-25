using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model.Planets;
using Balancer.Views.TypeTesting.Details;
using Balancer.Views.TypeTesting.Statistics;

namespace Balancer.Views.TypeTesting
{
    public class StatisticsContext : BaseContext
    {
        Object lockerObject = new Object();

        private ConcurrentDictionary<String, PlanetTypeStatistic> planetTypeCache = new ConcurrentDictionary<String, PlanetTypeStatistic>();
        public ICollection<PlanetTypeStatistic> PlanetTypeStatistics
        {
            get
            {
                return this.planetTypeCache.Values;
            }
        }

        private Int32 totalPlanets;
        public Int32 TotalPlanets
        {
            get
            {
                return this.totalPlanets;
            }
            private set
            {
                SetProperty(ref this.totalPlanets, value);
            }
        }

        private ICommand viewDetailsCommand;
        public ICommand ViewDetailsCommand
        {
            get
            {
                if (this.viewDetailsCommand == default)
                {
                    this.viewDetailsCommand = new SimpleCommand<PlanetTypeStatistic>(ExecuteViewDetailsCommand);
                }

                return this.viewDetailsCommand;
            }
        }

        public void AddPlanet(Planet planet)
        {
            if (!planetTypeCache.TryGetValue(planet.Type.Name, out PlanetTypeStatistic planetTypeStatistic))
            {
                planetTypeStatistic = new PlanetTypeStatistic(planet.Type);

                planetTypeCache[planet.Type.Name] = planetTypeStatistic;
                OnPropertyChanged(nameof(PlanetTypeStatistics));
            }

            if (planetTypeStatistic.Add(planet))
            {
                lock (lockerObject)
                {
                    TotalPlanets++;
                }
            }
        }

        private void ExecuteViewDetailsCommand(PlanetTypeStatistic typeStatistic)
        {
            new TypeDetailWindow(typeStatistic).Show();
        }
    }
}
