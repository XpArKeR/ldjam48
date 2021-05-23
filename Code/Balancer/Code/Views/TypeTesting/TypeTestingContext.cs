using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model;
using Balancer.Model.Planets;

namespace Balancer.Views.TypeTesting
{
    public class TypeTestingContext : DialogContext
    {
        private StatisticsContext statisticsContext = new StatisticsContext();
        public StatisticsContext StatisticsContext
        {
            get
            {
                return this.statisticsContext;
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

        private Int32 amountToGenerate = 100;
        public Int32 AmountToGenerate
        {
            get
            {
                return this.amountToGenerate;
            }
            set
            {
                SetProperty(ref amountToGenerate, value);
            }
        }

        private ObservableCollection<Turn> generatedTurns = new ObservableCollection<Turn>();
        public ObservableCollection<Turn> GeneratedTurns
        {
            get
            {
                return this.generatedTurns;
            }
        }

        private ICommand generateTurnsCommand;
        public ICommand GenerateTurnsCommand
        {
            get
            {
                if (this.generateTurnsCommand == default)
                {
                    this.generateTurnsCommand = new SimpleCommand(ExecuteGenerateTurnsCommand);
                }

                return this.generateTurnsCommand;
            }
        }

        private void ExecuteGenerateTurnsCommand()
        {
            var planetGenerator = new PlanetGenerator(this.PlanetTypes);

            for (int turnCounter = 0; turnCounter < this.AmountToGenerate + 1; turnCounter++)
            {
                var turn = new Turn()
                {
                    Number = turnCounter + 1
                };

                foreach (var planet in planetGenerator.Generate(4))
                {
                    turn.Planets.Add(planet);

                    AddPlanetToStatisticsAsync(planet);
                }

                this.GeneratedTurns.Add(turn);
            }
        }

        private async Task AddPlanetToStatisticsAsync(Planet planet)
        {
            await Task.Run(() =>
            {                
                this.StatisticsContext.AddPlanet(planet);
            });
        }
    }
}
