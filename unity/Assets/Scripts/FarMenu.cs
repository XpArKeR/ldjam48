using Assets.Scripts;
using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FarMenu : MonoBehaviour
{
    public List<PlanetPreview> previews;

    void Start()
    {
        RefreshPlanetViews();
    }

     public void GeneratePlanets()
    {
        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
        RefreshPlanetViews();
    }

    private void RefreshPlanetViews()
    {
        if (Core.GameState.Planets.Count == 0)
        {
            Core.GameState.Planets.Clear();
            Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
        }


        for (int i = 0; i < previews.Count; i++)
        {
            PlanetPreview planetPreview = previews[i];

            Text type = planetPreview.type;
            Planet planet = Core.GameState.Planets[i];
            type.text = planet.type;

            Image planetImage = planetPreview.planet;
            planetImage.color = planet.BaseColor;
            Debug.Log(planetImage.color.ToString());
        }

    }
}
