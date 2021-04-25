using System.Collections.Generic;
using System.IO;

using Assets.Scripts;

using UnityEngine;

public static class PlanetGenerator
{

    private static List<PlanetType> planetTypes = new List<PlanetType>();

    public static void LoadPlanetTypes()
    {
        planetTypes = JsonUtility.ListFromJson<PlanetType>(Path.Combine(Application.streamingAssetsPath, "Planets", "PlanetTypes.json"));

        NormalizeColors();
        Debug.Log("PlanetTypes loaded: " + planetTypes.Count);
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
            CloudSprite = ChooseRandomSprite(planetType.CloudSprites)
        };

        return planet;
    }
}
