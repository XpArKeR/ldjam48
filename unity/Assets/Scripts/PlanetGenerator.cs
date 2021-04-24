using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerator : MonoBehaviour
{
    public Sprite[] planetLands;
    public Sprite[] clouds;

    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;

    public Color[] planetColors;
    public Color[] planetLandColors;
    public Color[] planetCloudColors;

    public void GeneratePlanet()
    {
        Planet planet = new Planet() {
            BaseColor = ChooseRandomColor(planetColors),
            LandColor = ChooseRandomColor(planetLandColors),
            LandSprite = ChooseRandomSprite(planetLands),
            CloudColor = ChooseRandomColor(planetCloudColors),
            CloudSprite = ChooseRandomSprite(clouds)
        };

        LoadPlanet(planet);
    }


    public void LoadPlanet(Planet planet)
    {
        planetBase.color = planet.BaseColor;


        planetLand.color = planet.LandColor;
        planetLand.sprite = planet.LandSprite;


        planetClouds.color = planet.CloudColor;
        planetClouds.sprite = planet.CloudSprite;
    }

    private Color ChooseRandomColor(Color[] colors)
    {
        int baseLandIndex = Random.Range(0, colors.Length);
        return colors[baseLandIndex];
    }

    private Sprite ChooseRandomSprite(Sprite[] sprites)
    {
        int baseLandIndex = Random.Range(0, sprites.Length);
        return sprites[baseLandIndex];
    }

}
