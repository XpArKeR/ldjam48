﻿using Assets.Scripts.Ships;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Constants
{
    public static class Defaults
    {
        private const String consumptionRatesString = @"{
  ""scan"": 0.05,
  ""movement"": 1.0,
  ""gatherOxygen"": 0.1,
  ""gatherFood"": 0.1,
  ""gatherFuel"": 0.1
}";

        private static ConsumptionRates consumptionRates;
        public static ConsumptionRates ConsumptionRates
        {
            get
            {
                if (consumptionRates == default)
                {
                    consumptionRates = UnityEngine.JsonUtility.FromJson<ConsumptionRates>(consumptionRatesString);
                }

                return consumptionRates;
            }
        }



        public static List<PlanetType> GetPlanetTypes()
        {
            return JsonUtility.ListFromJsonString<PlanetType>(planetTypeString);
        }

         private const String planetTypeString = @"[
  {
            ""Name"": ""Water"",
    ""Resources"": {
                ""Oxygen"": {
                    ""RangeMin"": ""120"",
        ""RangeMax"": ""180"",
        ""Dispersion"": ""80""
                },
      ""Food"": {
                    ""RangeMin"": ""80"",
        ""RangeMax"": ""150"",
        ""Dispersion"": ""70""
      },
      ""Fuel"": {
                    ""RangeMin"": ""15"",
        ""RangeMax"": ""50"",
        ""Dispersion"": ""20""
      }
            },
    ""LandSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""CloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""BaseColors"": [
      {
                ""r"": 33.4,
        ""g"": 68.2,
        ""b"": 68.2,
        ""a"": 1.0
      },
      {
                ""r"": 15.2,
        ""g"": 44.4,
        ""b"": 61.1,
        ""a"": 1.0
      },
      {
                ""r"": 18.0,
        ""g"": 31.4,
        ""b"": 67.2,
        ""a"": 1.0
      },
      {
                ""r"": 20.9,
        ""g"": 52.0,
        ""b"": 49.2,
        ""a"": 1.0
      }
    ],
    ""LandColors"": [
      {
                ""r"": 13.0,
        ""g"": 38.4,
        ""b"": 9.5,
        ""a"": 1.0
      },
      {
                ""r"": 29.3,
        ""g"": 58.1,
        ""b"": 25.3,
        ""a"": 1.0
      },
      {
                ""r"": 31.1,
        ""g"": 191.7,
        ""b"": 45.1,
        ""a"": 1.0
      }
    ],
    ""CloudColors"": [
      {
                ""r"": 1.0,
        ""g"": 0.0,
        ""b"": 1.0,
        ""a"": 1.0
      }
    ]
  },
  {
            ""Name"": ""Forest"",
    ""Resources"": {
                ""Oxygen"": {
                    ""RangeMin"": ""120"",
        ""RangeMax"": ""240"",
        ""Dispersion"": ""100""
                },
      ""Food"": {
                    ""RangeMin"": ""60"",
        ""RangeMax"": ""120"",
        ""Dispersion"": ""35""
      },
      ""Fuel"": {
                    ""RangeMin"": ""60"",
        ""RangeMax"": ""90"",
        ""Dispersion"": ""80""
      }
            },
    ""LandSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""CloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""BaseColors"": [
      {
                ""r"": 13.0,
        ""g"": 38.4,
        ""b"": 9.5,
        ""a"": 1.0
      },
      {
                ""r"": 29.3,
        ""g"": 58.1,
        ""b"": 25.3,
        ""a"": 1.0
      },
      {
                ""r"": 31.1,
        ""g"": 191.7,
        ""b"": 45.1,
        ""a"": 1.0
      }
    ],
    ""LandColors"": [
      {
                ""r"": 33.4,
        ""g"": 68.2,
        ""b"": 68.2,
        ""a"": 1.0
      },
      {
                ""r"": 15.2,
        ""g"": 44.4,
        ""b"": 61.1,
        ""a"": 1.0
      },
      {
                ""r"": 18.0,
        ""g"": 31.4,
        ""b"": 67.2,
        ""a"": 1.0
      },
      {
                ""r"": 20.9,
        ""g"": 52.0,
        ""b"": 49.2,
        ""a"": 1.0
      }
    ],
    ""CloudColors"": [
      {
                ""r"": 255.0,
        ""g"": 255.0,
        ""b"": 255.0,
        ""a"": 1.0
      }
    ]
  },
  {
            ""Name"": ""Rock"",
    ""Resources"": {
                ""Oxygen"": {
                    ""RangeMin"": ""25"",
        ""RangeMax"": ""40"",
        ""Dispersion"": ""40""
                },
      ""Food"": {
                    ""RangeMin"": ""5"",
        ""RangeMax"": ""25"",
        ""Dispersion"": ""10""
      },
      ""Fuel"": {
                    ""RangeMin"": ""160"",
        ""RangeMax"": ""270"",
        ""Dispersion"": ""95""
      }
            },
    ""LandSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""CloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""BaseColors"": [
      {
                ""r"": 189.7,
        ""g"": 105.7,
        ""b"": 68.4,
        ""a"": 1.0
      },
      {
                ""r"": 180.4,
        ""g"": 97.6,
        ""b"": 37.3,
        ""a"": 1.0
      },
      {
                ""r"": 180.4,
        ""g"": 131.8,
        ""b"": 21.9,
        ""a"": 1.0
      }
    ],
    ""LandColors"": [
      {
                ""r"": 180.4,
        ""g"": 172.6,
        ""b"": 21.9,
        ""a"": 1.0
      },
      {
                ""r"": 180.4,
        ""g"": 150.6,
        ""b"": 77.3,
        ""a"": 1.0
      },
      {
                ""r"": 177.6,
        ""g"": 178.0,
        ""b"": 7.7,
        ""a"": 1.0
      },
      {
                ""r"": 177.6,
        ""g"": 131.8,
        ""b"": 79.8,
        ""a"": 1.0
      }
    ],
    ""CloudColors"": [
      {
                ""r"": 255.0,
        ""g"": 255.0,
        ""b"": 255.0,
        ""a"": 1.0
      }
    ]
  },
  {
            ""Name"": ""Lava"",
    ""Resources"": {
                ""Oxygen"": {
                    ""RangeMin"": ""15"",
        ""RangeMax"": ""25"",
        ""Dispersion"": ""10""
                },
      ""Food"": {
                    ""RangeMin"": ""0"",
        ""RangeMax"": ""0"",
        ""Dispersion"": ""0""
      },
      ""Fuel"": {
                    ""RangeMin"": ""190"",
        ""RangeMax"": ""300"",
        ""Dispersion"": ""170""
      }
            },
    ""LandSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""CloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""BaseColors"": [
      {
                ""r"": 225.4,
        ""g"": 66.7,
        ""b"": 14.2,
        ""a"": 1.0
      },
      {
                ""r"": 225.4,
        ""g"": 25.7,
        ""b"": 23.2,
        ""a"": 1.0
      },
      {
                ""r"": 225.4,
        ""g"": 3.4,
        ""b"": 5.2,
        ""a"": 1.0
      }
    ],
    ""LandColors"": [
      {
                ""r"": 255.0,
        ""g"": 201.9,
        ""b"": 52.8,
        ""a"": 1.0
      },
      {
                ""r"": 255.0,
        ""g"": 130.1,
        ""b"": 74.7,
        ""a"": 1.0
      },
      {
                ""r"": 220.8,
        ""g"": 171.1,
        ""b"": 15.5,
        ""a"": 1.0
      },
      {
                ""r"": 208.4,
        ""g"": 213.9,
        ""b"": 24.5,
        ""a"": 1.0
      }
    ],
    ""CloudColors"": [
      {
                ""r"": 255.0,
        ""g"": 255.0,
        ""b"": 255.0,
        ""a"": 1.0
      }
    ]
  }
]
";


        public static List<ShipType> GetShipTypes()
        {
            return JsonUtility.ListFromJsonString<ShipType>(shiptypesString);
        }

        private const String shiptypesString = @"[  {
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
]";

    }







}
