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
            //ShipTypes = JsonUtility.ListFromJson<ShipType>(Path.Combine(Application.streamingAssetsPath, "Ships", "ShipTypes.json"));
            ShipTypes = JsonUtility.ListFromJsonString<ShipType>(@"[  {
                ""Name"": ""Default"",
    ""MaxOxygenLevel"": 1000,
    ""OxygenLevel"": 1000,
    ""OxygenConsumption"": 60,
    ""MaxFoodLevel"": 500,
    ""FoodLevel"": 300,
    ""FoodConsumption"": 20,
    ""MaxFuelLevel"": 1000,
    ""FuelLevel"": 500,
    ""FuelConsumption"": 100
  }
]
");
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
