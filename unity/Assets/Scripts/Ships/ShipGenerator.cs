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
            ShipTypes = JsonUtility.ListFromJson<ShipType>(Path.Combine(Application.streamingAssetsPath, "Ships", "ShipTypes.json"));
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
                    MaxOxygenLevel = shipType.MaxOxygenLevel,
                    OxygenLevel = shipType.OxygenLevel,
                    OxygenConsumption = shipType.OxygenConsumption,
                    MaxFoodLevel = shipType.MaxFoodLevel,
                    FoodLevel = shipType.FoodLevel,
                    FoodConsumption = shipType.FoodConsumptiom,
                    MaxFuelLevel = shipType.MaxFuelLevel,
                    FuelLevel = shipType.FuelLevel,
                    FuelConsumption = shipType.FuelConsumption
                };
            }

            return spaceShip;
        }
    }
}
