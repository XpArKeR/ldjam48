
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class HeaderMenu : MonoBehaviour
{
    public Text PlanetsVisitedText;
    public Slider OxygenSlider;
    public Slider FoodSlider;
    public Slider FuelSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (Core.GameState?.Ship != default)
        {
            this.OxygenSlider?.SetMinMax(0, Core.GameState.Ship.MaxOxygenLevel);
            this.FoodSlider?.SetMinMax(0, Core.GameState.Ship.MaxFoodLevel);
            this.FuelSlider?.SetMinMax(0, Core.GameState.Ship.MaxFuelLevel);

            var planetsVisitedText = Core.GameState.PlanetsVisited.ToString();

            if (this.PlanetsVisitedText?.text != planetsVisitedText)
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

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateValues()
    {
        if (Core.GameState?.Ship != default)
        {
            if (this.OxygenSlider?.value != Core.GameState.Ship.OxygenLevel)
            {
                this.OxygenSlider.value = Core.GameState.Ship.OxygenLevel;
            }

            if (this.FoodSlider?.value != Core.GameState.Ship.FoodLevel)
            {
                this.FoodSlider.value = Core.GameState.Ship.FoodLevel;
            }

            if (this.FuelSlider?.value != Core.GameState.Ship.FuelLevel)
            {
                this.FuelSlider.value = Core.GameState.Ship.FuelLevel;
            }

            var planetsVisitedText = Core.GameState.PlanetsVisited.ToString();

            if (this.PlanetsVisitedText?.text != planetsVisitedText)
            {
                this.PlanetsVisitedText.text = planetsVisitedText;
            }
        }
    }
}