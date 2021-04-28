using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Extensions;

using UnityEngine;

public static class PlanetGenerator
{

    private static List<PlanetType> planetTypes = new List<PlanetType>();

    public static float OxygenMax { get; private set; }
    public static float OxygenMin { get; private set; }
    public static float OxygenRange { get; private set; }
    public static float FoodMax { get; private set; }
    public static float FoodMin { get; private set; }
    public static float FoodRange { get; private set; }
    public static float FuelMax { get; private set; }
    public static float FuelMin { get; private set; }
    public static float FuelRange { get; private set; }

    public static void LoadPlanetTypes()
    {
        //planetTypes = JsonUtility.ListFromJson<PlanetType>(Path.Combine(Application.streamingAssetsPath, "Planets", "PlanetTypes.json"));
        planetTypes = JsonUtility.ListFromJsonString<PlanetType>(GetPlanetTypeString());
        if (planetTypes?.Count < 1)
        {            
            throw new MissingComponentException(nameof(planetTypes));
        }

        NormalizeColors();
        GetMinMaxResourceValues();
        Debug.Log("PlanetTypes loaded: " + planetTypes.Count);
    }

    private static String GetPlanetTypeString()
    {
        return @"[
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
    }

    private static void GetMinMaxResourceValues()
    {
        OxygenMax = 0;
        OxygenMin = 0;
        FoodMax = 0;
        FoodMin = 0;
        FuelMax = 0;
        FuelMin = 0;
        foreach (PlanetType planetType in planetTypes)
        {
            OxygenMax = GetMaxValue(OxygenMax, planetType.Resources.Oxygen);
            OxygenMin = GetMinValue(OxygenMin, planetType.Resources.Oxygen);
            FoodMax = GetMaxValue(FoodMax, planetType.Resources.Food);
            FoodMin = GetMinValue(FoodMin, planetType.Resources.Food);
            FuelMax = GetMaxValue(FuelMax, planetType.Resources.Fuel);
            FuelMin = GetMinValue(FuelMin, planetType.Resources.Fuel);
        }


        OxygenMin = Math.Max(OxygenMin, 0);
        FoodMin = Math.Max(FoodMin, 0);
        FuelMin = Math.Max(FuelMin, 0);

        OxygenRange = OxygenMax - OxygenMin;
        FoodRange = FoodMax - FoodMin;
        FuelRange = FuelMax - FuelMin;
    }

    private static float GetMaxValue(float currentValue, PlanetResource resource)
    {
        return Math.Max(currentValue, resource.RangeMax + resource.Dispersion);
    }

    private static float GetMinValue(float currentValue, PlanetResource resource)
    {
        return Math.Min(currentValue, resource.RangeMin - resource.Dispersion);
    }

    private static void NormalizeColors()
    {
        foreach (PlanetType planetType in planetTypes)
        {
            planetType.BaseColors = NormColors(planetType.BaseColors);
            planetType.LandColors = NormColors(planetType.LandColors);
            planetType.CloudColors = NormColors(planetType.CloudColors);
        }
    }

    private static List<Color> NormColors(List<Color> colors)
    {
        List<Color> normedColors = new List<Color>();
        foreach (Color color in colors)
        {
            Color newColor = new Color()
            {
                r = color.r / 255,
                g = color.g / 255,
                b = color.b / 255,
                a = 1
            };
            normedColors.Add(newColor);
        }
        return normedColors;
    }

    public static List<Planet> GeneratePlanets(int amount)
    {
        List<Planet> planets = new List<Planet>();
        for (int i = 0; i < amount; i++)
        {
            planets.Add(GeneratePlanet());
        }
        return planets;
    }

    public static Planet GeneratePlanet()
    {
        PlanetType planetType = planetTypes.GetRandomEntry();

        return GeneratePlanet(planetType);
    }

    private static Sprite LoadSprite(string spriteName)
    {
        return Core.ResourceCache.GetSprite(Path.Combine("Planets", "Sprites", spriteName));
    }

    public static Planet GeneratePlanet(PlanetType planetType)
    {
        Planet planet = new Planet()
        {
            Type = planetType.Name,
            BaseColor = planetType.BaseColors.GetRandomEntry(),
            LandColor = planetType.LandColors.GetRandomEntry(),
            LandSprite = LoadSprite(planetType.LandSprites.GetRandomEntry()),
            CloudColor = planetType.CloudColors.GetRandomEntry(),
            CloudSprite = LoadSprite(planetType.CloudSprites.GetRandomEntry()),
            Resources = GenerateResources(planetType)
        };

        return planet;
    }

    private static PlanetResources GenerateResources(PlanetType planetType)
    {
        PlanetResources generatedResources = new PlanetResources();
        PlanetResources resources = planetType.Resources;
        generatedResources.Oxygen = GenerateResource(resources.Oxygen);
        generatedResources.Food = GenerateResource(resources.Food);
        generatedResources.Fuel = GenerateResource(resources.Fuel);
        return generatedResources;
    }

    private static PlanetResource GenerateResource(PlanetResource origResource)
    {
        PlanetResource generatedResource = new PlanetResource();
        generatedResource.RangeMin = origResource.RangeMin;
        generatedResource.RangeMax = origResource.RangeMax + origResource.Dispersion;

        float value = UnityEngine.Random.Range(generatedResource.RangeMin, generatedResource.RangeMax);
        if (value < 0)
        {
            value = 0;
        }
        generatedResource.Value = value;

        generatedResource.DispersionRangeMin = value - origResource.Dispersion;
        if (generatedResource.DispersionRangeMin < 0)
        {
            generatedResource.DispersionRangeMin = 0;
        }
        generatedResource.DispersionRangeMax = value + origResource.Dispersion;

        return generatedResource;
    }
}
