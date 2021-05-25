using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            this.ViewContext.Chart = this.Chart;
            this.ViewContext.Statistic = planetTypeStatistic;

            this.ViewContext.Load();
        }
    }
}
