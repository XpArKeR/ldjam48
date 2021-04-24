using System;

namespace Assets.Scripts.Ships
{
    public class SpaceShip
    {
        public Double FuelConsumtion { get; set; }
        public Double FuelLevel { get; set; }
        public Double MaxFuelLevel { get; set; }

        public Double OxygenConsumption { get; set; }
        public Double OxygenLevel { get; set; }
        public Double MaxOxygenLevel { get; set; }

        public Double FoodConsumption { get; set; }
        public Double FoodLevel { get; set; }
        public Double MaxFoodLevel { get; set; }
    }
}
