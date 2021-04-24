using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerator : MonoBehaviour
{
    public Sprite[] planets;

    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;

    static List<Color> planetColors;

    public void Start()
    {
        planetColors = new List<Color>()
           {
            new Color32(255, 255, 225, 255), 
            new Color32(124, 47, 88, 255),
            new Color32(148, 248, 225, 255) 
    };
    }

    public void GeneratePlanet()
    {

        int baseColorIndex = Random.Range(0, planetColors.Count);
        planetBase.color = planetColors[baseColorIndex];

        int baseLandIndex = Random.Range(0, planets.Length);
        planetLand.sprite = planets[baseLandIndex];

    }

 
}
