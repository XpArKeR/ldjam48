using System.Collections.Generic;
using System.Windows;

using Balancer.Model.Planets;

namespace Balancer.Views.TypeTesting
{
    /// <summary>
    /// Interaction logic for TypeTestingWindow.xaml
    /// </summary>
    public partial class TypeTestingWindow : Window
    {
        public TypeTestingWindow()
        {
            InitializeComponent();
        }

        public TypeTestingWindow(List<PlanetType> planetTypes) : this()
        {
            this.ViewContext.PlanetTypes = planetTypes;
        }
    }
}
