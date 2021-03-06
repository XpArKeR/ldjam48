
using System;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    private Boolean isFlyingOff;
    private float pauseTime;

    public AudioSource AudioSource;
    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;

    public Text planetOxygen;
    public Text planetFood;
    public Text planetFuel;
    public Image currentBackground;

    public HeaderMenu headerMenu;

    public void FlyAway()
    {
        Core.GameState.PlanetsVisited++;
        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));

        Core.BackgroundMusicManager.Mute();

        if (Core.Options.AreAnimationsEnabled)
        {
            var clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "FlyOff-Short"));
            AudioSource.clip = clip;

            AudioSource.Play();

            this.isFlyingOff = true;

            StartCoroutine(AudioSource.WaitForSound(FinishedFlyOff));
        }
        else
        {
            this.ChangeScene();
        }
    }

    private void FinishedFlyOff()
    {
        this.isFlyingOff = false;
        this.ChangeScene();
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
        planetOxygen.text = Core.GameState.CurrentTarget.Resources.Oxygen.Value.ToString("N0");
        planetFood.text = Core.GameState.CurrentTarget.Resources.Food.Value.ToString("N0");
        planetFuel.text = Core.GameState.CurrentTarget.Resources.Fuel.Value.ToString("N0");
    }

    public void TakeOxygen()
    {
        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherOxygen))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
        else if (Core.GameState.CurrentTarget.Resources.Oxygen.Value > 0)
        {
            var leftoverValue = Core.GameState.Ship.AddOxygen(Core.GameState.CurrentTarget.Resources.Oxygen.Value);
            Core.GameState.CurrentTarget.Resources.Oxygen.Value = leftoverValue;
            planetOxygen.text = Core.GameState.CurrentTarget.Resources.Oxygen.Value.ToString("N0");

            var audioNumber = 1;

            var midRange = (Core.GameState.CurrentTarget.Resources.Oxygen.DispersionRangeMax + Core.GameState.CurrentTarget.Resources.Oxygen.DispersionRangeMin) / 2;

            if (Core.GameState.CurrentTarget.Resources.Oxygen.Value > midRange)
            {
                audioNumber = 2;
            }

            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", string.Format("Gathering_Oxygen_{0}", audioNumber)));
            AudioSource.Play();
        }
        else
        {
            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "Gathering_Failed"));
            AudioSource.Play();
        }
    }

    public void TakeFood()
    {
        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherFood))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
        else if (Core.GameState.CurrentTarget.Resources.Food.Value > 0)
        {
            var leftoverValue = Core.GameState.Ship.AddFood(Core.GameState.CurrentTarget.Resources.Food.Value);
            Core.GameState.CurrentTarget.Resources.Food.Value = leftoverValue;
            planetFood.text = Core.GameState.CurrentTarget.Resources.Food.Value.ToString("N0");


            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "Gathering_Food"));
            AudioSource.Play();
        }
        else
        {
            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "Gathering_Failed"));
            AudioSource.Play();
        }
    }

    public void TakeFuel()
    {
        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherFuel))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
        else if (Core.GameState.CurrentTarget.Resources.Fuel.Value > 0)
        {
            var leftoverValue = Core.GameState.Ship.AddFuel(Core.GameState.CurrentTarget.Resources.Fuel.Value);
            Core.GameState.CurrentTarget.Resources.Fuel.Value = leftoverValue;
            planetFuel.text = Core.GameState.CurrentTarget.Resources.Fuel.Value.ToString("N0");

            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "Gathering_Fuel"));
            AudioSource.Play();
        }
        else
        {
            AudioSource.clip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "Gathering_Failed"));
            AudioSource.Play();
        }
    }


    public void ShowOxygenAddition()
    {
        headerMenu.ShowPossibleChangeAddOxygen(Core.GameState.CurrentTarget.Resources.Oxygen.Value, Core.GameState.ConsumptionRates.GatherOxygen);
    }

    public void ShowFoodAddition()
    {
        headerMenu.ShowPossibleChangeAddFood(Core.GameState.CurrentTarget.Resources.Food.Value, Core.GameState.ConsumptionRates.GatherFood);
    }

    public void ShowFuelAddition()
    {
        headerMenu.ShowPossibleChangeAddFuel(Core.GameState.CurrentTarget.Resources.Fuel.Value, Core.GameState.ConsumptionRates.GatherFuel);
    }

    public void ShowFlyAwayConsumption()
    {
        headerMenu.ShowPossibleChangeConsumption(Core.GameState.ConsumptionRates.Movement);
    }


    public void ClearPossibleChanges()
    {
        headerMenu.ClearPossibleChange();
    }



    private void Start()
    {
        if (Core.BackgroundMusicManager != default)
        {
            Core.BackgroundMusicManager.PauseToggled.AddListener(this.OnPauseToggled);
        }

        if (Core.ForegroundMusicManager != default)
        {
            this.AudioSource.volume = Core.ForegroundMusicManager.Volume;
            Core.ForegroundMusicManager.VolumeChanged.AddListener(OnEffectsVolumeChanged);
        }

        LoadTargetPlanet();
        RefreshResources();

        currentBackground.sprite = Core.GetBackgroundSprite();

        if ((!Core.GameState.IsVictorious) && Core.GameState.PlanetsVisited > 19)
        {
            Core.GameState.IsVictorious = true;
            Core.ChangeScene(SceneNames.Victorious);
        }
        else
        {
            var appoarchClip = Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Effects", "ApproachEffect"));

            this.AudioSource.clip = appoarchClip;
            this.AudioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (Core.BackgroundMusicManager != default)
        {
            Core.BackgroundMusicManager.PauseToggled.RemoveListener(this.OnPauseToggled);
        }
    }

    private void OnPauseToggled(Boolean isPaused)
    {
        if (isPaused)
        {
            if (this.AudioSource.isPlaying)
            {
                if (isFlyingOff)
                {
                    StopCoroutine(AudioSource.WaitForSound(FinishedFlyOff));
                }

                this.AudioSource.Pause();
                pauseTime = this.AudioSource.time;
            }
        }
        else
        {
            if ((!this.AudioSource.isPlaying) && (pauseTime > 0))
            {
                this.AudioSource.time = pauseTime;
                this.AudioSource.Play();

                if (isFlyingOff)
                {
                    StartCoroutine(AudioSource.WaitForSound(FinishedFlyOff));
                }

                pauseTime = default;
            }
        }
    }

    private void OnEffectsVolumeChanged(float volume)
    {
        this.AudioSource.volume = volume;
    }

    private void ChangeScene()
    {
        Core.ChangeScene(SceneNames.Far);
        Core.BackgroundMusicManager.Unmute();
    }
}
