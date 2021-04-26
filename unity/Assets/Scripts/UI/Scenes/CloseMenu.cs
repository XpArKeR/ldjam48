using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Extensions;

using UnityEngine.UI;

public class CloseMenu : MovingSceneBase
{
    public Image currentBackground;

    void Start()
    {
        RefreshPlanetViews();
        currentBackground.sprite = Core.GetBackgroundSprite();
    }

    public override void SelectPlanet(PlanetPreview planetPreview)
    {
        base.SelectPlanet(planetPreview);

        if (planetPreview.IsScanned)
        {
            this.Move(Core.GameState.ConsumptionRates.Movement, SceneNames.Planet);
        }
        else
        {
            planetPreview.Scan(OnScanCompleted);
        }
    }

    protected override void OnScanCompleted()
    {
        base.OnScanCompleted();

        this.Move(Core.GameState.ConsumptionRates.Scan, SceneNames.Close);
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
                planetPreview.RevealResources();
            }
            if (Core.GameState.Planets[i].Scanned)
            {
                planetPreview.RevealResources();
            }

        }
    }
}
