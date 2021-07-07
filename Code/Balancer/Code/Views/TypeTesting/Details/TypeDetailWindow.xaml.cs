using System.Windows;

using Balancer.Views.TypeTesting.Statistics;

namespace Balancer.Views.TypeTesting.Details
{
    /// <summary>
    /// Interaction logic for TypeDetailWindow.xaml
    /// </summary>
    public partial class TypeDetailWindow : Window
    {
        public TypeDetailWindow(PlanetTypeStatistic planetTypeStatistic)
        {
            InitializeComponent();

            this.ViewContext.OxygenChart = this.OxygenChart;
            this.ViewContext.OxygenChartGrid = this.OxygenChartGrid;

            this.ViewContext.FoodChart = this.FoodChart;
            this.ViewContext.FoodChartGrid = this.FoodChartGrid;

            this.ViewContext.FuelChart = this.FuelChart;
            this.ViewContext.FuelChartGrid = this.FuelChartGrid;

            this.ViewContext.Statistic = planetTypeStatistic;

            this.ViewContext.Load();
        }
    }
}
