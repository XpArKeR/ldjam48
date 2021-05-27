
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class HeaderMenu : MonoBehaviour
{
    public Text PlanetsVisitedText;
    public PauseMenu pauseMenu;

    public CustomResouceBar OxygenBar;
    public CustomResouceBar FoodBar;
    public CustomResouceBar FuelBar;

    void Start()
    {
        if (Core.GameState?.Ship != default)
        {
            if (this.OxygenBar != default)
            {
                this.OxygenBar.SetMinMax(0, Core.GameState.Ship.MaxOxygenLevel);
            }

            if (this.FoodBar != default)
            {
                this.FoodBar.SetMinMax(0, Core.GameState.Ship.MaxFoodLevel);
            }

            if (this.FuelBar != default)
            {
                this.FuelBar.SetMinMax(0, Core.GameState.Ship.MaxFuelLevel);
            }

            var planetsVisitedText = Core.GameState.PlanetsVisited.ToString();

            if ((this.PlanetsVisitedText != default) && (this.PlanetsVisitedText.text != planetsVisitedText))
            {
                this.PlanetsVisitedText.text = planetsVisitedText;
            }
        }

        UpdateValues();
    }

    private void FixedUpdate()
    {
        UpdateValues();
    }


    public void TogglePauseMenu()
    {
        pauseMenu.ToggleMenu();
    }

    private void UpdateValues()
    {
        if (Core.GameState?.Ship != default)
        {
            if (this.OxygenBar.GetCurrentValue() != Core.GameState.Ship.OxygenLevel)
            {
                this.OxygenBar.SetCurrentValue(Core.GameState.Ship.OxygenLevel);
            }

            if (this.FoodBar.GetCurrentValue() != Core.GameState.Ship.FoodLevel)
            {
                this.FoodBar.SetCurrentValue(Core.GameState.Ship.FoodLevel);
            }

            if (this.FuelBar.GetCurrentValue() != Core.GameState.Ship.FuelLevel)
            {
                this.FuelBar.SetCurrentValue(Core.GameState.Ship.FuelLevel);
            }

            var planetsVisitedText = Core.GameState.PlanetsVisited.ToString();

            if (this.PlanetsVisitedText.text != planetsVisitedText)
            {
                this.PlanetsVisitedText.text = planetsVisitedText;
            }
        }
    }

    public void ShowPossibleChangeConsumption(float consumptionFactor)
    {
        float[] consumptions = Core.GameState.Ship.GetConsumptions(consumptionFactor);
        OxygenBar.SetPossibleChange(-consumptions[0]);
        FoodBar.SetPossibleChange(-consumptions[1]);
        FuelBar.SetPossibleChange(-consumptions[2]);
    }

    public void ShowPossibleChangeAddOxygen(float amount, float consumptionFactor)
    {
        float[] consumptions = Core.GameState.Ship.GetConsumptions(consumptionFactor);
        OxygenBar.SetPossibleChange(amount-consumptions[0]);
        FoodBar.SetPossibleChange(-consumptions[1]);
        FuelBar.SetPossibleChange(-consumptions[2]);
    }

    public void ShowPossibleChangeAddFood(float amount, float consumptionFactor)
    {
        float[] consumptions = Core.GameState.Ship.GetConsumptions(consumptionFactor);
        OxygenBar.SetPossibleChange(-consumptions[0]);
        FoodBar.SetPossibleChange(amount - consumptions[1]);
        FuelBar.SetPossibleChange(-consumptions[2]);
    }

    public void ShowPossibleChangeAddFuel(float amount, float consumptionFactor)
    {
        float[] consumptions = Core.GameState.Ship.GetConsumptions(consumptionFactor);
        OxygenBar.SetPossibleChange(-consumptions[0]);
        FoodBar.SetPossibleChange(-consumptions[1]);
        FuelBar.SetPossibleChange(amount - consumptions[2]);
    }

    public void ClearPossibleChange()
    {
        OxygenBar.ClearPossibleChange();
        FoodBar.ClearPossibleChange();
        FuelBar.ClearPossibleChange();
    }
}
