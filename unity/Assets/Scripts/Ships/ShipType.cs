using System;

using UnityEngine;

namespace Assets.Scripts.Ships
{
    [Serializable]
    public class ShipType
    {
        [SerializeField]
        private String name;
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }

        [SerializeField]
        private float maxOxygenLevel;
        public float MaxOxygenLevel
        {
            get
            {
                return this.maxOxygenLevel;
            }
            set
            {
                if (this.maxOxygenLevel != value)
                {
                    this.maxOxygenLevel = value;
                }
            }
        }

        [SerializeField]
        private float oxygenLevel;
        public float OxygenLevel
        {
            get
            {
                return this.oxygenLevel;
            }
            set
            {
                if (this.oxygenLevel != value)
                {
                    this.oxygenLevel = value;
                }
            }
        }

        [SerializeField]
        private float oxygenConsumption;
        public float OxygenConsumption
        {
            get
            {
                return this.oxygenConsumption;
            }
            set
            {
                if (this.oxygenConsumption != value)
                {
                    this.oxygenConsumption = value;
                }
            }
        }

        [SerializeField]
        private float maxFoodLevel;
        public float MaxFoodLevel
        {
            get
            {
                return this.maxFoodLevel;
            }
            set
            {
                if (this.maxFoodLevel != value)
                {
                    this.maxFoodLevel = value;
                }
            }
        }

        [SerializeField]
        private float foodLevel;
        public float FoodLevel
        {
            get
            {
                return this.foodLevel;
            }
            set
            {
                if (this.foodLevel != value)
                {
                    this.foodLevel = value;
                }
            }
        }

        [SerializeField]
        private float foodConsumption;
        public float FoodConsumption
        {
            get
            {
                return this.foodConsumption;
            }
            set
            {
                if (this.foodConsumption != value)
                {
                    this.foodConsumption = value;
                }
            }
        }

        [SerializeField]
        private float maxFuelLevel;
        public float MaxFuelLevel
        {
            get
            {
                return this.maxFuelLevel;
            }
            set
            {
                if (this.maxFuelLevel != value)
                {
                    this.maxFuelLevel = value;
                }
            }
        }

        [SerializeField]
        private float fuelLevel;
        public float FuelLevel
        {
            get
            {
                return this.fuelLevel;
            }
            set
            {
                if (this.fuelLevel != value)
                {
                    this.fuelLevel = value;
                }
            }
        }

        [SerializeField]
        private float fuelConsumption;
        public float FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                if (this.fuelConsumption != value)
                {
                    this.fuelConsumption = value;
                }
            }
        }
    }
}
