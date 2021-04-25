using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApproachMenu : MonoBehaviour
{
    public List<PlanetPreview> previews;



    void Start()
    {
        RefreshPlanetViews();
    }



    private void RefreshPlanetViews()
    {

        for (int i = 0; i < previews.Count; i++)
        {
            PlanetPreview planetPreview = previews[i];
            Planet planet = Core.GameState.Planets[i];
            planetPreview.planet = planet;

            Text type = planetPreview.type;
            type.text = planet.type;

            Image planetBase = planetPreview.planetBase;
            planetBase.color = planet.BaseColor;

            if (planet == Core.GameState.CurrentTarget)
            {
                planetPreview.planetLand.sprite = planet.LandSprite;
                planetPreview.planetLand.color = planet.LandColor;
                planetPreview.planetCloud.sprite = planet.CloudSprite;
                planetPreview.planetCloud.color = planet.CloudColor;

            }
        }

    }
}
