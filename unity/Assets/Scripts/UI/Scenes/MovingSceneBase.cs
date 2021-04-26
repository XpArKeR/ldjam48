using System;
using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;

public class MovingSceneBase : MonoBehaviour
{
    public virtual void SelectPlanet(PlanetPreview planetPreview)
    {
        Core.GameState.CurrentTarget = planetPreview.planet;
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
