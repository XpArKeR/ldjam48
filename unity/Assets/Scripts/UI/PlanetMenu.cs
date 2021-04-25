using System;
using System.Collections;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    public AudioSource FlyOffAudioSource;
    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;

    public Text planetOxygen;
    public Text planetFood;
    public Text planetFuel;

    private void Start()
    {
        LoadTargetPlanet();
        RefreshResources();
    }
    
    public void FlyAway()
    {
        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));

        Core.BackgroundAudioSource.Pause();

        FlyOffAudioSource.Play();

        StartCoroutine(WaitForSound(() =>
        {
            SceneManager.LoadScene(SceneNames.Far);
            Core.BackgroundAudioSource.Play();
        }));
    }

    IEnumerator WaitForSound(Action action)
    {
        while (FlyOffAudioSource.isPlaying)
        {
            yield return default;
        }

        action();
    }

    public void LoadTargetPlanet()
    {
        LoadPlanet(Core.GameState.CurrentTarget);
    }


    public void LoadPlanet(Planet planet)
    {
        planetBase.color = planet.BaseColor;


        planetLand.color = planet.LandColor;
        planetLand.sprite = planet.LandSprite;


        planetClouds.color = planet.CloudColor;
        planetClouds.sprite = planet.CloudSprite;
    }

    public void RefreshResources()
    {
        planetOxygen.text = Core.GameState.CurrentTarget.Resources.Oxygen.Value.ToString();
        planetFood.text = Core.GameState.CurrentTarget.Resources.Food.Value.ToString();
        planetFuel.text = Core.GameState.CurrentTarget.Resources.Fuel.Value.ToString();
    }

    public void TakeOxygen()
    {
        Core.GameState.Ship.OxygenLevel += Core.GameState.CurrentTarget.Resources.Oxygen.Value;
        Core.GameState.CurrentTarget.Resources.Oxygen.Value = 0;
        planetOxygen.text = Core.GameState.CurrentTarget.Resources.Oxygen.Value.ToString();
        Core.GameState.Ship.Move(.25f);
    }
    public void TakeFood()
    {
        Core.GameState.Ship.FoodLevel += Core.GameState.CurrentTarget.Resources.Food.Value;
        Core.GameState.CurrentTarget.Resources.Food.Value = 0;
        planetFood.text = Core.GameState.CurrentTarget.Resources.Food.Value.ToString();
        Core.GameState.Ship.Move(.25f);
    }
    public void TakeFuel()
    {
        Core.GameState.Ship.FuelLevel += Core.GameState.CurrentTarget.Resources.Fuel.Value;
        Core.GameState.CurrentTarget.Resources.Fuel.Value = 0;
        planetFuel.text = Core.GameState.CurrentTarget.Resources.Fuel.Value.ToString();
        Core.GameState.Ship.Move(.25f);
    }
}
