using System;
using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Extensions;

using UnityEngine;

public class MovingSceneBase : MonoBehaviour
{
    public List<PlanetPreview> previews;
        
    public virtual void SelectPlanet(PlanetPreview planetPreview)
    {
        Core.GameState.CurrentTarget = planetPreview.planet;

        foreach (var preview in this.previews)
        {
            preview.Button.interactable = false;
        }
    }

    protected virtual void OnScanCompleted()
    {
        Core.GameState.Planets.DeleteRandomEntry(p => !p.Scanned);

        foreach (var preview in this.previews)
        {
            preview.Button.interactable = true;
        }
    }

    protected virtual void Move(float consumptionRate, String sceneName)
    {
        if (!Core.GameState.Ship.Consume(consumptionRate))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
        else
        {
            Core.ChangeScene(sceneName);
        }
    }
}
