using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Core.GameState.Ship = new SpaceShip()
        {
            TypeName = "Default",
            MaxOxygenLevel = 1000f,
            OxygenLevel = 1000f,
            OxygenConsumption = 100f,
            MaxFoodLevel = 100f,
            FoodLevel = 100f,
            FoodConsumption = 10f,
            MaxFuelLevel = 1000f,
            FuelLevel = 500f,
            FuelConsumtion = 100f,
        };

        SceneManager.LoadScene(SceneNames.Far);
    }

    public void LoadGame()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
