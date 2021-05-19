using Assets.Scripts.Ships;
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
    ""name"": ""Water"",
    ""resources"": {
      ""oxygen"": {
        ""rangeMin"": 120.0,
        ""rangeMax"": 180.0,
        ""dispersion"": 80.0
      },
      ""food"": {
        ""rangeMin"": 80.0,
        ""rangeMax"": 150.0,
        ""dispersion"": 70.0
      },
      ""fuel"": {
        ""rangeMin"": 15.0,
        ""rangeMax"": 50.0,
        ""dispersion"": 20.0
      }
    },
    ""landSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""cloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""baseColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.1309804,
        ""g"": 0.26745096,
        ""b"": 0.26745096
      },
      {
        ""a"": 1.0,
        ""r"": 0.05960784,
        ""g"": 0.17411765,
        ""b"": 0.23960784
      },
      {
        ""a"": 1.0,
        ""r"": 0.07058824,
        ""g"": 0.12313725,
        ""b"": 0.2635294
      },
      {
        ""a"": 1.0,
        ""r"": 0.08196078,
        ""g"": 0.20392157,
        ""b"": 0.19294117
      }
    ],
    ""landColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.050980393,
        ""g"": 0.15058824,
        ""b"": 0.037254903
      },
      {
        ""a"": 1.0,
        ""r"": 0.11490196,
        ""g"": 0.22784314,
        ""b"": 0.09921569
      },
      {
        ""a"": 1.0,
        ""r"": 0.12196079,
        ""g"": 0.7517647,
        ""b"": 0.17686275
      }
    ],
    ""cloudColors"": [
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 0.0,
        ""b"": 1.0
      }
    ]
  },
  {
    ""name"": ""Forest"",
    ""resources"": {
      ""oxygen"": {
        ""rangeMin"": 120.0,
        ""rangeMax"": 240.0,
        ""dispersion"": 100.0
      },
      ""food"": {
        ""rangeMin"": 60.0,
        ""rangeMax"": 120.0,
        ""dispersion"": 35.0
      },
      ""fuel"": {
        ""rangeMin"": 60.0,
        ""rangeMax"": 90.0,
        ""dispersion"": 80.0
      }
    },
    ""landSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""cloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""baseColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.050980393,
        ""g"": 0.15058824,
        ""b"": 0.037254903
      },
      {
        ""a"": 1.0,
        ""r"": 0.11490196,
        ""g"": 0.22784314,
        ""b"": 0.09921569
      },
      {
        ""a"": 1.0,
        ""r"": 0.12196079,
        ""g"": 0.7517647,
        ""b"": 0.17686275
      }
    ],
    ""landColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.1309804,
        ""g"": 0.26745096,
        ""b"": 0.26745096
      },
      {
        ""a"": 1.0,
        ""r"": 0.05960784,
        ""g"": 0.17411765,
        ""b"": 0.23960784
      },
      {
        ""a"": 1.0,
        ""r"": 0.07058824,
        ""g"": 0.12313725,
        ""b"": 0.2635294
      },
      {
        ""a"": 1.0,
        ""r"": 0.08196078,
        ""g"": 0.20392157,
        ""b"": 0.19294117
      }
    ],
    ""cloudColors"": [
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 1.0,
        ""b"": 1.0
      }
    ]
  },
  {
    ""name"": ""Rock"",
    ""resources"": {
      ""oxygen"": {
        ""rangeMin"": 25.0,
        ""rangeMax"": 40.0,
        ""dispersion"": 40.0
      },
      ""food"": {
        ""rangeMin"": 5.0,
        ""rangeMax"": 25.0,
        ""dispersion"": 10.0
      },
      ""fuel"": {
        ""rangeMin"": 160.0,
        ""rangeMax"": 270.0,
        ""dispersion"": 95.0
      }
    },
    ""landSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""cloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""baseColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.7439216,
        ""g"": 0.4145098,
        ""b"": 0.2682353
      },
      {
        ""a"": 1.0,
        ""r"": 0.707451,
        ""g"": 0.3827451,
        ""b"": 0.1462745
      },
      {
        ""a"": 1.0,
        ""r"": 0.707451,
        ""g"": 0.51686275,
        ""b"": 0.08588235
      }
    ],
    ""landColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.707451,
        ""g"": 0.6768628,
        ""b"": 0.08588235
      },
      {
        ""a"": 1.0,
        ""r"": 0.707451,
        ""g"": 0.5905883,
        ""b"": 0.30313727
      },
      {
        ""a"": 1.0,
        ""r"": 0.6964706,
        ""g"": 0.69803923,
        ""b"": 0.030196078
      },
      {
        ""a"": 1.0,
        ""r"": 0.6964706,
        ""g"": 0.51686275,
        ""b"": 0.3129412
      }
    ],
    ""cloudColors"": [
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 1.0,
        ""b"": 1.0
      }
    ]
  },
  {
    ""name"": ""Lava"",
    ""resources"": {
      ""oxygen"": {
        ""rangeMin"": 15.0,
        ""rangeMax"": 25.0,
        ""dispersion"": 10.0
      },
      ""food"": {
        ""rangeMin"": 0.0,
        ""rangeMax"": 0.0,
        ""dispersion"": 0.0
      },
      ""fuel"": {
        ""rangeMin"": 190.0,
        ""rangeMax"": 300.0,
        ""dispersion"": 170.0
      }
    },
    ""landSprites"": [
      ""planet_01_lm"",
      ""planet_02_lm"",
      ""planet_03_lm"",
      ""planet_04_lm"",
      ""planet_05_lm""
    ],
    ""cloudSprites"": [
      ""clouds_01_2"",
      ""clouds_02_2""
    ],
    ""baseColors"": [
      {
        ""a"": 1.0,
        ""r"": 0.88392156,
        ""g"": 0.2615686,
        ""b"": 0.055686273
      },
      {
        ""a"": 1.0,
        ""r"": 0.88392156,
        ""g"": 0.10078432,
        ""b"": 0.090980396
      },
      {
        ""a"": 1.0,
        ""r"": 0.88392156,
        ""g"": 0.013333334,
        ""b"": 0.020392155
      }
    ],
    ""landColors"": [
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 0.7917647,
        ""b"": 0.20705882
      },
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 0.5101961,
        ""b"": 0.29294115
      },
      {
        ""a"": 1.0,
        ""r"": 0.86588234,
        ""g"": 0.6709804,
        ""b"": 0.060784314
      },
      {
        ""a"": 1.0,
        ""r"": 0.8172549,
        ""g"": 0.8388235,
        ""b"": 0.09607843
      }
    ],
    ""cloudColors"": [
      {
        ""a"": 1.0,
        ""r"": 1.0,
        ""g"": 1.0,
        ""b"": 1.0
      }
    ]
  }
]";


        public static List<ShipType> GetShipTypes()
        {
            return JsonUtility.ListFromJsonString<ShipType>(shiptypesString);
        }

        private const String shiptypesString = @"[
  {
    ""name"": ""Default"",
    ""maxOxygenLevel"": 1000.0,
    ""oxygenLevel"": 1000.0,
    ""oxygenConsumption"": 60.0,
    ""maxFoodLevel"": 500.0,
    ""foodLevel"": 300.0,
    ""foodConsumption"": 20.0,
    ""maxFuelLevel"": 1000.0,
    ""fuelLevel"": 500.0,
    ""fuelConsumption"": 100.0
  }
]";

    }







}
