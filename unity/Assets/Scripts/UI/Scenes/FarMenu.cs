using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class FarMenu : MovingSceneBase
{
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

    public override void SelectPlanet(PlanetPreview planetPreview)
    {
        base.SelectPlanet(planetPreview);

        planetPreview.Scan(OnScanCompleted);
    }

    protected override void OnScanCompleted()
    {
        base.OnScanCompleted();

        this.Move(Core.GameState.ConsumptionRates.Movement, SceneNames.Approach);
    }

    private void SelectAndSetBackGround()
    {
        Sprite background = backgrounds.GetRandomEntry();

        Core.SetCurrentBackground(background);
        currentBackground.sprite = background;
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


            Image planetImage = planetPreview.planetBase;
            planetImage.color = planet.BaseColor;
        }
    }
}
