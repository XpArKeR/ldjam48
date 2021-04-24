using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider OxygenSlider;
    public Slider FoodSlider;
    public Slider FuelSlider;

    // Start is called before the first frame update
    void Start()
    {
        this.OxygenSlider.maxValue = Core.GameState.Ship.MaxOxygenLevel;
        this.FoodSlider.maxValue = Core.GameState.Ship.MaxFoodLevel;
        this.FuelSlider.maxValue = Core.GameState.Ship.MaxFuelLevel;
    }
    
    private void FixedUpdate()
    {
        if (this.OxygenSlider.value != Core.GameState.Ship.OxygenLevel)
        {
            this.OxygenSlider.value = Core.GameState.Ship.OxygenLevel;
        }

        if (this.FoodSlider.value != Core.GameState.Ship.FoodLevel)
        {
            this.FoodSlider.value = Core.GameState.Ship.FoodLevel;
        }

        if (this.FuelSlider.value != Core.GameState.Ship.FuelLevel)
        {
            this.FuelSlider.value = Core.GameState.Ship.FuelLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
