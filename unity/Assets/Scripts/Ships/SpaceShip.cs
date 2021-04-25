using System;

namespace Assets.Scripts.Ships
{
    public class SpaceShip
    {
        public SpaceShip()
        {

        }
        public String TypeName { get; set; }
        public ShipType ShipType { get; set; }

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

        public float AddOxygen(float amountToAdd)
        {
            return this.AddResource(ref this.oxygenLevel, this.MaxOxygenLevel, amountToAdd);
        }

        public float AddFood(float amountToAdd)
        {
            return this.AddResource(ref this.foodLevel, this.MaxFoodLevel, amountToAdd);
        }

        public float AddFuel(float amountToAdd)
        {
            return this.AddResource(ref this.fuelLevel, this.MaxFuelLevel, amountToAdd);
        }

        public Boolean Consume(float consumptionFactor)
        {
            var canMove = this.ConsumeResource(ref this.oxygenLevel, this.OxygenConsumption, consumptionFactor); ;

            if (canMove)
            {
                canMove = this.ConsumeResource(ref this.foodLevel, this.FoodConsumption, consumptionFactor);
            }

            if (canMove)
            {
                canMove = this.ConsumeResource(ref this.fuelLevel, this.FuelConsumption, consumptionFactor);
            }

            return canMove;
        }

        private float AddResource(ref float level, float maxValue, float amountToAdd)
        {
            var capacity = maxValue - level;

            if (amountToAdd > capacity)
            {
                var leftoverAmount = amountToAdd - capacity;

                level += capacity;

                return leftoverAmount;
            }
            else
            {
                level += amountToAdd;
            }

            return 0;
        }
                
        private Boolean ConsumeResource(ref float level, float consumption, float consumptionFactor)
        {
            var hasEnoughtResource = true;

            var consumedAmount = consumption * consumptionFactor;

            if (consumedAmount > level)
            {
                level = 0;
                hasEnoughtResource = false;
            }
            else
            {
                level -= consumedAmount;
            }

            return hasEnoughtResource;
        }
    }
}
