using System;

namespace Assets.Scripts.Ships
{
    public class SpaceShip
    {
        public SpaceShip()
        {

        }
        public String TypeName { get; set; }

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

        //public float AddOxygen(float amountToAdd)
        //{
        //    var capacity = this.MaxOxygenLevel - this.OxygenLevel;

        //    if (amountToAdd > capacity)
        //    {
        //        var leftoverAmount = amountToAdd - capacity;

        //        this.OxygenLevel += capacity;

        //        return leftoverAmount;
        //    }
        //    else
        //    {
        //        this.OxygenLevel += amountToAdd;
        //    }


        //    return 0;
        //}

        //public float AddFood(float amountToAdd)
        //{
        //    var capacity = this.MaxFoodLevel - this.FoodLevel;

        //    if (amountToAdd > capacity)
        //    {
        //        var leftoverAmount = amountToAdd - capacity;

        //        this.FoodLevel += capacity;

        //        return leftoverAmount;
        //    }
        //    else
        //    {
        //        this.FoodLevel += amountToAdd;
        //    }

        //    return 0;
        //}

        //public float AddFuel(float amountToAdd)
        //{
        //    var capacity = this.MaxFuelLevel - this.FuelLevel;

        //    if (amountToAdd > capacity)
        //    {
        //        var leftoverAmount = amountToAdd - capacity;

        //        this.FuelLevel += capacity;

        //        return leftoverAmount;
        //    }
        //    else
        //    {
        //        this.FuelLevel += amountToAdd;
        //    }

        //    return 0;
        //}

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

        public Boolean Consume(float consumptionFactor)
        {
            var canMove = true;

            var ogygenComsumption = this.OxygenConsumption * consumptionFactor;

            if (ogygenComsumption > this.OxygenLevel)
            {
                canMove = false;
            }
            else
            {
                this.OxygenLevel -= ogygenComsumption;
            }

            if (canMove)
            {
                var foodConsuption = this.FoodConsumption * consumptionFactor;

                if (foodConsuption > this.FoodLevel)
                {
                    canMove = false;
                }
                else
                {
                    this.FoodLevel -= foodConsuption;
                }
            }

            if (canMove)
            {
                var fuelConsumption = this.FuelConsumption * consumptionFactor;

                if (fuelConsumption > this.FuelLevel)
                {
                    canMove = false;
                }
                else
                {
                    this.FuelLevel -= fuelConsumption;
                }
            }

            return canMove;
        }
    }
}
