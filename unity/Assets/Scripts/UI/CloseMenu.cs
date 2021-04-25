using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public List<PlanetPreview> previews;
    public Image currentBackground;

    void Start()
    {
        RefreshPlanetViews();
        currentBackground.sprite = Core.currentBackground;
    }

    private void RefreshPlanetViews()
    {

        for (int i = 0; i < previews.Count; i++)
        {
            PlanetPreview planetPreview = previews[i];
            Planet planet = Core.GameState.Planets[i];
            planetPreview.planet = planet;

            Text type = planetPreview.type;
            type.text = planet.Type;

            Image planetBase = planetPreview.planetBase;
            planetBase.color = planet.BaseColor;

            if (planet == Core.GameState.CurrentTarget)
            {
                planetPreview.Scan();
            }
            if (Core.GameState.Planets[i].Scanned)
            {
                planetPreview.Scan();
            }

        }
    }
}
