using System.Linq;
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

        private Chart chart;
        public Chart Chart
        {
            get
            {
                return this.chart;
            }
            set
            {
                SetProperty(ref this.chart, value);
            }
        }

        public void Load()
        {
            var line = new LineGraph()
            {
                Stroke = Brushes.Red,
                StrokeThickness = 1
            };

            

            foreach (var planet in this.Statistic.Planets.OrderBy( p => p.Resources.Oxygen.Value))
            {
            }
        }
    }
}
