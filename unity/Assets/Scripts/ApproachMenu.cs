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
            planetPreview.thisPlanet = planet;

            Text type = planetPreview.type;
            type.text = planet.type;

            Image planetImage = planetPreview.planet;
            planetImage.color = planet.BaseColor;

            if (planet == Core.GameState.CurrentTarget)
            {
                planetImage.sprite = planet.LandSprite;
            }
        }

    }
}
