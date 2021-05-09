using System;
using System.Collections.Generic;

namespace Balancer.Model.Planets
{
    public class PlanetType
    {
        public String Name { get; set; }
        public PlanetResources Resources { get; set; }
        public List<String> LandSprites { get; set; }
        public List<String> CloudSprites { get; set; }
        public List<CustomColor> BaseColors { get; set; }
        public List<CustomColor> LandColors { get; set; }
        public List<CustomColor> CloudColors { get; set; }
    }
}
