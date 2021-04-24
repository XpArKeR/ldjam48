using System;

namespace Assets.Scripts.Ships
{
    public class SpaceShip
    {
        public SpaceShip()
        {

        }

        public float FuelConsumtion { get; set; }
        public float FuelLevel { get; set; }
        public float MaxFuelLevel { get; set; }

        public float OxygenConsumption { get; set; }
        public float OxygenLevel { get; set; }
        public float MaxOxygenLevel { get; set; }

        public float FoodConsumption { get; set; }
        public float FoodLevel { get; set; }
        public float MaxFoodLevel { get; set; }
    }
}
