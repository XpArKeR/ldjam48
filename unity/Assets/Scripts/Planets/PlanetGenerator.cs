using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
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
        planetTypes = JsonUtility.ListFromJson<PlanetType>(Path.Combine(Application.streamingAssetsPath, "Planets", "PlanetTypes.json"));

        NormalizeColors();
        GetMinMaxResourceValues();
        Debug.Log("PlanetTypes loaded: " + planetTypes.Count);
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
        PlanetType planetType = GetRandomPlanetType();

        return GeneratePlanet(planetType);
    }

    private static PlanetType GetRandomPlanetType()
    {
        int index = UnityEngine.Random.Range(0, planetTypes.Count);
        return planetTypes[index];
    }

    private static Color ChooseRandomColor(List<Color> colors)
    {
        int index = UnityEngine.Random.Range(0, colors.Count);

        return colors[index];
    }

    private static Sprite ChooseRandomSprite(List<string> sprites)
    {
        int index = UnityEngine.Random.Range(0, sprites.Count);

        return LoadSprite(sprites[index]);
    }

    private static Sprite LoadSprite(string spriteName)
    {
        return Core.ResourceCache.GetSprite("Planets/Sprites/" + spriteName);
    }

    public static Planet GeneratePlanet(PlanetType planetType)
    {
        Planet planet = new Planet()
        {
            Type = planetType.Name,
            BaseColor = ChooseRandomColor(planetType.BaseColors),
            LandColor = ChooseRandomColor(planetType.LandColors),
            LandSprite = ChooseRandomSprite(planetType.LandSprites),
            CloudColor = ChooseRandomColor(planetType.CloudColors),
            CloudSprite = ChooseRandomSprite(planetType.CloudSprites),
            Resources = GenerateResources(planetType)
        };

        return planet;
    }

    private static PlanetResources GenerateResources(PlanetType planetType)
    {
        PlanetResources generatedResources = new PlanetResources();
        PlanetResources resources = planetType.Resources;
        generatedResources.Oxygen = GenerateResource(resources.Oxygen);
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
