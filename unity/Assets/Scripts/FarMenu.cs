using Assets.Scripts;
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
            Text type = GetChildComponentByName<Text>(planetImages[i], "TypeOutput");
            type.text = Core.GameState.Planets[i].type;
        }
    }

    private T GetChildComponentByName<T>(Image planet, string name) where T : Component
    {
        foreach (T component in planet.GetComponentsInChildren<T>(true))
        {
            if (component.gameObject.name == name)
            {
                return component;
            }
        }
        return null;
    }

}
