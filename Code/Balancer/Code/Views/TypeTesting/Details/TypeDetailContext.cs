using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

using Balancer.Views.TypeTesting.Statistics;

using InteractiveDataDisplay.WPF;

namespace Balancer.Views.TypeTesting.Details
{
    public class TypeDetailContext : DialogContext
    {
        private PlanetTypeStatistic statistic;
        public PlanetTypeStatistic Statistic
        {
            get
            {
                return this.statistic;
            }
            set
            {
                SetProperty(ref this.statistic, value);
            }
        }

        private Chart oxygenChart;
        public Chart OxygenChart
        {
            get
            {
                return this.oxygenChart;
            }
            set
            {
                SetProperty(ref this.oxygenChart, value);
            }
        }

        private Grid oxygenChartGrid;
        public Grid OxygenChartGrid
        {
            get
            {
                return this.oxygenChartGrid;
            }
            set
            {
                SetProperty(ref this.oxygenChartGrid, value);
            }
        }

        private Chart foodChart;
        public Chart FoodChart
        {
            get
            {
                return this.foodChart;
            }
            set
            {
                SetProperty(ref this.foodChart, value);
            }
        }

        private Grid foodChartGrid;
        public Grid FoodChartGrid
        {
            get
            {
                return this.foodChartGrid;
            }
            set
            {
                SetProperty(ref this.foodChartGrid, value);
            }
        }

        private Chart fuelChart;
        public Chart FuelChart
        {
            get
            {
                return this.fuelChart;
            }
            set
            {
                SetProperty(ref this.fuelChart, value);
            }
        }

        private Grid fuelChartGrid;
        public Grid FuelChartGrid
        {
            get
            {
                return this.fuelChartGrid;
            }
            set
            {
                SetProperty(ref this.fuelChartGrid, value);
            }
        }

        private LineGraph oxygenLine;
        public LineGraph OxygenLine
        {
            get
            {
                return this.oxygenLine;
            }
            set
            {
                SetProperty(ref this.oxygenLine, value);
            }
        }

        private LineGraph foodLine;
        public LineGraph FoodLine
        {
            get
            {
                return this.foodLine;
            }
            set
            {
                SetProperty(ref this.foodLine, value);
            }
        }

        private LineGraph fuelLine;
        public LineGraph FuelLine
        {
            get
            {
                return this.fuelLine;
            }
            set
            {
                SetProperty(ref this.fuelLine, value);
            }
        }

        private Double oxygenMinAmount;
        public Double OxygenMinAmount
        {
            get
            {
                return this.oxygenMinAmount;
            }
            set
            {
                SetProperty(ref this.oxygenMinAmount, value);
            }
        }

        private Double oxygenMaxAmount;
        public Double OxygenMaxAmount
        {
            get
            {
                return this.oxygenMaxAmount;
            }
            set
            {
                SetProperty(ref this.oxygenMaxAmount, value);
            }
        }

        private Double foodMinAmount;
        public Double FoodMinAmount
        {
            get
            {
                return this.foodMinAmount;
            }
            set
            {
                SetProperty(ref this.foodMinAmount, value);
            }
        }

        private Double foodMaxAmount;
        public Double FoodMaxAmount
        {
            get
            {
                return this.foodMaxAmount;
            }
            set
            {
                SetProperty(ref this.foodMaxAmount, value);
            }
        }

        private Double fuelMinAmount;
        public Double FuelMinAmount
        {
            get
            {
                return this.fuelMinAmount;
            }
            set
            {
                SetProperty(ref this.fuelMinAmount, value);
            }
        }

        private Double fuelMaxAmount;
        public Double FuelMaxAmount
        {
            get
            {
                return this.fuelMaxAmount;
            }
            set
            {
                SetProperty(ref this.fuelMaxAmount, value);
            }
        }

        public void Load()
        {
            var oxygenLineGraph = new LineGraph()
            {
                Description = "Oxygen",
                Stroke = Brushes.Turquoise,
                StrokeThickness = 2
            };

            var foodLineGraph = new LineGraph()
            {
                Description = "Food",
                Stroke = Brushes.LightGreen,
                StrokeThickness = 2
            };

            var fuelLineGraph = new LineGraph()
            {
                Description = "Fuel",
                Stroke = Brushes.DarkOrange,
                StrokeThickness = 2
            };

            var planetsOxygenMinAmount = Double.MaxValue;
            var planetsOxygenMaxAmount = 0d;

            var planetsFoodMinAmount = Double.MaxValue;
            var planetsFoodMaxAmount = 0d;

            var planetsFuelMinAmount = Double.MaxValue;
            var planetsFuelMaxAmount = 0d;

            this.PlotResource(oxygenLineGraph, this.Statistic.Planets.GroupBy(p => Math.Round(p.Resources.Oxygen.Value)).OrderBy(g => g.Key), ref planetsOxygenMinAmount, ref planetsOxygenMaxAmount);
            this.PlotResource(foodLineGraph, this.Statistic.Planets.GroupBy(p => Math.Round(p.Resources.Food.Value)).OrderBy(g => g.Key), ref planetsFoodMinAmount, ref planetsFoodMaxAmount);
            this.PlotResource(fuelLineGraph, this.Statistic.Planets.GroupBy(p => Math.Round(p.Resources.Fuel.Value)).OrderBy(g => g.Key), ref planetsFuelMinAmount, ref planetsFuelMaxAmount);

            this.OxygenMinAmount = planetsOxygenMinAmount;
            this.OxygenMaxAmount = planetsOxygenMaxAmount;

            this.FoodMinAmount = planetsFoodMinAmount;
            this.FoodMaxAmount = planetsFoodMaxAmount;

            this.FuelMinAmount = planetsFuelMinAmount;
            this.FuelMaxAmount = planetsFuelMaxAmount;

            OxygenChartGrid.Children.Clear();
            OxygenChartGrid.Children.Add(oxygenLineGraph);

            FoodChartGrid.Children.Clear();
            FoodChartGrid.Children.Add(foodLineGraph);

            FuelChartGrid.Children.Clear();
            FuelChartGrid.Children.Add(fuelLineGraph);
        }

        private void PlotResource(LineGraph lineGraph, IOrderedEnumerable<IGrouping<Double, Model.Planets.Planet>> orderedResouces, ref Double minAmount, ref Double maxAmount)
        {
            var oxygenValueCollection = new Dictionary<Double, Double>();

            foreach (var planetGroup in orderedResouces)
            {
                var amount = planetGroup.Count();

                if (amount < minAmount)
                {
                    minAmount = amount;
                }

                if (amount > maxAmount)
                {
                    maxAmount = amount;
                }

                oxygenValueCollection[planetGroup.Key] = amount;
            }

            lineGraph.Plot(oxygenValueCollection.Keys, oxygenValueCollection.Values);
        }
    }
}
