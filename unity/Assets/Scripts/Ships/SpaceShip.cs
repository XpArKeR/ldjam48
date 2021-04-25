using System;

namespace Assets.Scripts.Ships
{
    public class SpaceShip
    {
        public SpaceShip()
        {

        }
        public String TypeName { get; set; }

        public float FuelConsumtion { get; set; }
        public float FuelLevel { get; set; }
        public float MaxFuelLevel { get; set; }

        public float OxygenConsumption { get; set; }
        public float OxygenLevel { get; set; }
        public float MaxOxygenLevel { get; set; }

        public float FoodConsumption { get; set; }
        public float FoodLevel { get; set; }
        public float MaxFoodLevel { get; set; }

        public Boolean Move(float consumptionFactor)
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
                var fuelConsumption = this.FuelConsumtion * consumptionFactor;

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
