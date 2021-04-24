using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
 

    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;


    public void LoadTargetPlanet()
    {
        LoadPlanet(Core.GameState.CurrentTarget);
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
