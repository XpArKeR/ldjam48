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
        public ObservableCollection<UnityColor> BaseColors { get; set; }
        public ObservableCollection<UnityColor> LandColors { get; set; }
        public ObservableCollection<UnityColor> CloudColors { get; set; }

        internal Boolean Any(Func<Object, Boolean> p)
        {
            throw new NotImplementedException();
        }
    }
}
