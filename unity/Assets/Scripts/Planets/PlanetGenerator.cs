using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class PlanetGenerator 
{

    private static List<PlanetType> planetTypes = new List<PlanetType>();

    public static void LoadPlanetTypes()
    {
        planetTypes = JsonUtility.ListFromJson<PlanetType>("Assets/Resources/Planets/PlanetTypes.json");
        Debug.Log("PlanetTypes loaded: " + planetTypes.Count);
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
        return Core.ResourceCache.GetSprit("Planets/Sprites/" + spriteName);
    }

    public static Planet GeneratePlanet(PlanetType planetType)
    {
        Planet planet = new Planet()
        {
            type = planetType.Name,
            BaseColor = ChooseRandomColor(planetType.BaseColors),
            LandColor = ChooseRandomColor(planetType.LandColors),
            LandSprite = ChooseRandomSprite(planetType.LandSprites),
            CloudColor = ChooseRandomColor(planetType.CloudColors),
            CloudSprite = ChooseRandomSprite(planetType.CloudSprites)
        };

        return planet;
    }

}
