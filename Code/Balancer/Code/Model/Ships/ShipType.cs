using System;

namespace Balancer.Model.Ships
{
    public class ShipType
    {
        public String Name { get; set; }
        public Double MaxOxygenLevel { get; set; }
        public Double OxygenLevel { get; set; }
        public Double OxygenConsumption { get; set; }

        public Double MaxFoodLevel { get; set; }
        public Double FoodLevel { get; set; }
        public Double FoodConsumption { get; set; }

        public Double MaxFuelLevel { get; set; }
        public Double FuelLevel { get; set; }
        public Double FuelConsumption { get; set; }
    }
}
