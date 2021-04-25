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

    private void Start()
    {
        LoadTargetPlanet();
    }
    
    public void FlyAway()
    {
        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));

        Core.BackgroundAudioSource.Pause();

        FlyOffAudioSource.Play();

        StartCoroutine(waitForSound(() =>
        {
            SceneManager.LoadScene(SceneNames.Far);
            Core.BackgroundAudioSource.Play();
        }));
    }

    IEnumerator waitForSound(Action action)
    {
        //Wait Until Sound has finished playing
        while (FlyOffAudioSource.isPlaying)
        {
            yield return default;
        }

        //Auidio has finished playing, disable GameObject
        action();
    }

    public void LoadTargetPlanet()
    {
        LoadPlanet(Core.GameState.CurrentTarget);
    }

    public void TestPlanet()
    {
        Planet planet = PlanetGenerator.GeneratePlanet();
        LoadPlanet(planet);
    }

    public void LoadPlanet(Planet planet)
    {
        planetBase.color = planet.BaseColor;


        planetLand.color = planet.LandColor;
        planetLand.sprite = planet.LandSprite;


        planetClouds.color = planet.CloudColor;
        planetClouds.sprite = planet.CloudSprite;
    }
}
