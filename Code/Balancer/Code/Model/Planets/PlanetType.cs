using System;
using System.Collections.ObjectModel;

namespace Balancer.Model.Planets
{
    public class PlanetType
    {
        public String Name { get; set; }
        public PlanetResources Resources { get; set; }
        public ObservableCollection<String> LandSprites { get; set; }
        public ObservableCollection<String> CloudSprites { get; set; }
        public ObservableCollection<CustomColor> BaseColors { get; set; }
        public ObservableCollection<CustomColor> LandColors { get; set; }
        public ObservableCollection<CustomColor> CloudColors { get; set; }
    }
}
