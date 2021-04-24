using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPreview : MonoBehaviour
{
    public Image planetBase;
    public Image planetLand;
    public Image planetCloud;
    public Text type;
    public Planet planet;

    public void SelectThisPlanet()
    {
        if (SceneManager.GetActiveScene().name == SceneNames.Far)
        {
            Core.GameState.CurrentTarget = planet;
            Core.GameState.Planets.Remove(planet);
            DeleteRandomPlanet(Core.GameState.Planets);
            Core.GameState.Planets.Add(planet);

            SceneManager.LoadScene(SceneNames.Approach);
        }
        else if (SceneManager.GetActiveScene().name == SceneNames.Approach)
        {
            if (Core.GameState.CurrentTarget == planet)
            {
                SceneManager.LoadScene(SceneNames.Planet);
            }
            else
            {
                Core.GameState.CurrentTarget = planet;
                SceneManager.LoadScene(SceneNames.Planet);
            }
        }

        Core.GameState.Ship.OxygenLevel -= Core.GameState.Ship.OxygenConsumption;
        Core.GameState.Ship.FoodLevel -= Core.GameState.Ship.FoodConsumption;
        Core.GameState.Ship.FuelLevel -= Core.GameState.Ship.FuelConsumtion;
    }
    private void DeleteRandomPlanet(List<Planet> planets)
    {
        int index = UnityEngine.Random.Range(0, planets.Count);
        planets.RemoveAt(index);
    }
}
