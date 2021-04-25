using System;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class FarMenu : MonoBehaviour
{
    public List<PlanetPreview> previews;
    public Image currentBackground;
    public List<Sprite> backgrounds;


    private void Awake()
    {
        SelectAndSetBackGround();
    }

    void Start()
    {
        RefreshPlanetViews();
    }

    private void SelectAndSetBackGround()
    {
        Sprite background = SelectRandomBackground();
        Core.currentBackground = background;
        currentBackground.sprite = background;
    }

    private Sprite SelectRandomBackground()
    {
        int index = UnityEngine.Random.Range(0, backgrounds.Count);
        return backgrounds[index];
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
            Planet planet = Core.GameState.Planets[i];
            planetPreview.planet = planet;

            Text type = planetPreview.type;
            type.text = planet.Type;


            Image planetImage = planetPreview.planetBase;
            planetImage.color = planet.BaseColor;
        }
    }
}
