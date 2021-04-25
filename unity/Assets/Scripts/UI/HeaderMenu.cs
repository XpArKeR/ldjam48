
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
    }

    private void FixedUpdate()
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

            var fuelLevelString = Core.GameState.Ship.FuelLevel.ToString();

            if (this.PlanetsVisitedText?.text != fuelLevelString)
            {
                this.PlanetsVisitedText.text = Core.GameState.PlanetsVisited.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
