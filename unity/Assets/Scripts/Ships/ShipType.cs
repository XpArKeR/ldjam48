using System;

namespace Assets.Scripts.Ships
{
    [Serializable]
    public class ShipType
    {
        public String Name;
        public float MaxOxygenLevel;
        public float OxygenLevel;
        public float OxygenConsumption;
        public float MaxFoodLevel;
        public float FoodLevel;
        public float FoodConsumptiom;
        public float MaxFuelLevel;
        public float FuelLevel;
        public float FuelConsumption;
    }
}
