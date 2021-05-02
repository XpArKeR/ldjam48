using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace Assets.Scripts.Ships
{
    public static class ShipGenerator
    {
        public static IList<ShipType> ShipTypes;

        public static void LoadShipTypes()
        {
           
            if (Core.IsFileAccessPossible)
            {
                ShipTypes = JsonUtility.ListFromJson<ShipType>(Path.Combine(Application.streamingAssetsPath, "Ships", "ShipTypes.json"));
            }
            else
            {
                ShipTypes = Assets.Scripts.Constants.Defaults.GetShipTypes();
            }
            if (ShipTypes?.Count < 1)
            {
                throw new MissingComponentException(nameof(ShipTypes));
            }
            Debug.Log("ShipTypes loaded: " + ShipTypes.Count);
        }

        public static SpaceShip GenerateShip(ShipType shipType)
        {
            var spaceShip = default(SpaceShip);

            if (shipType != default)
            {
                spaceShip = new SpaceShip()
                {
                    TypeName = shipType.Name,
                    ShipType = shipType,
                    MaxOxygenLevel = shipType.MaxOxygenLevel,
                    OxygenLevel = shipType.OxygenLevel,
                    OxygenConsumption = shipType.OxygenConsumption,
                    MaxFoodLevel = shipType.MaxFoodLevel,
                    FoodLevel = shipType.FoodLevel,
                    FoodConsumption = shipType.FoodConsumption,
                    MaxFuelLevel = shipType.MaxFuelLevel,
                    FuelLevel = shipType.FuelLevel,
                    FuelConsumption = shipType.FuelConsumption
                };
            }

            return spaceShip;
        }
    }
}
