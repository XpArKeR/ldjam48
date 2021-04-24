using Assets.Scripts;
using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarMenu : MonoBehaviour
{
    public List<Image> planetImages;
    public List<PlanetPreview> previews;

    void Start()
    {
        RefreshPlanetViews();
    }

    public void generatePlanets()
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
        }

        for (int i = 0; i < planetImages.Count; i++)
        {            
            Text type = planetImages[i].GetChildComponentByName<Text>("TypeOutput");
            type.text = Core.GameState.Planets[i].type;
        }
    }
}
