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

        planetBase.color = ChooseRandomColor(planetColors);


        planetLand.color = ChooseRandomColor(planetLandColors);
        planetLand.sprite = ChooseRandomSprite(planetLands);


        planetClouds.color = ChooseRandomColor(planetCloudColors);
        planetClouds.sprite = ChooseRandomSprite(clouds);

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
