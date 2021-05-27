using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPreview : MonoBehaviour
{
    public bool IsScanned = false;

    public Button Button;
    public Image planetBase;
    public Image planetLand;
    public Image planetCloud;
    public Text type;
    public Planet planet;

    public SubRangeDisplayer oxygenRangeDisplayer;
    public SubRangeDisplayer foodRangeDisplayer;
    public SubRangeDisplayer fuelRangeDisplayer;

    public ScannerField scannerField;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public HeaderMenu headerMenu;

    public void Scan(Action onCompletedAction)
    {
        scannerField.Scan(() =>
        {
            RevealResources();
            onCompletedAction();
        });
    }

    public void ChangeCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (planet.Scanned)
        {
            headerMenu.ShowPossibleChangeConsumption(Core.GameState.ConsumptionRates.Movement);
        } else
        {
            headerMenu.ShowPossibleChangeConsumption(Core.GameState.ConsumptionRates.Scan);
        }
    }

    public void RevertCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        headerMenu.ClearPossibleChange();
    }

    public void RevealResources()
    {
        planetLand.sprite = planet.LandSprite;
        planetLand.color = planet.LandColor;
        planetCloud.sprite = planet.CloudSprite;
        planetCloud.color = planet.CloudColor;
        IsScanned = true;
        planet.Scanned = true;
        oxygenRangeDisplayer.min = planet.Resources.Oxygen.DispersionRangeMin;
        oxygenRangeDisplayer.max = planet.Resources.Oxygen.DispersionRangeMax;
        oxygenRangeDisplayer.rangeMin = PlanetGenerator.OxygenMin;
        oxygenRangeDisplayer.rangeMax = PlanetGenerator.OxygenMax;
        oxygenRangeDisplayer.Redraw();

        foodRangeDisplayer.min = planet.Resources.Food.DispersionRangeMin;
        foodRangeDisplayer.max = planet.Resources.Food.DispersionRangeMax;
        foodRangeDisplayer.rangeMin = PlanetGenerator.FoodMin;
        foodRangeDisplayer.rangeMax = PlanetGenerator.FoodMax;
        foodRangeDisplayer.Redraw();

        fuelRangeDisplayer.min = planet.Resources.Fuel.DispersionRangeMin;
        fuelRangeDisplayer.max = planet.Resources.Fuel.DispersionRangeMax;
        fuelRangeDisplayer.rangeMin = PlanetGenerator.FuelMin;
        fuelRangeDisplayer.rangeMax = PlanetGenerator.FuelMax;
        fuelRangeDisplayer.Redraw();
    }
}
