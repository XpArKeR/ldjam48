
using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MusicPlayer;
    public GameObject MainMenuContainer;
    public GameObject OptionsContainer;
    public Slider BackgroundVolumeSlider;

    private void Start()
    {
        if (Core.MusicManager == default)
        {
            Core.MusicManager = this.MusicPlayer.GetComponent<MusicManager>();
        }

        if (!Core.MusicManager.IsPlaying)
        {
            Core.MusicManager.Resume();
        }
    }

    public void StartGame()
    {
        Core.GameState.Ship = new SpaceShip()
        {
            TypeName = "Default",
            MaxOxygenLevel = 1000f,
            OxygenLevel = 1000f,
            OxygenConsumption = 100f,
            MaxFoodLevel = 500f,
            FoodLevel = 300f,
            FoodConsumption = 10f,
            MaxFuelLevel = 1000f,
            FuelLevel = 500f,
            FuelConsumption = 100f,
        };

        Core.GameState.PlanetsVisited = 0;

        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
        SceneManager.LoadScene(SceneNames.Far);
    }

    public void ShowOptions()
    {
        this.BackgroundVolumeSlider.value = Core.MusicManager.Volume;

        this.MainMenuContainer.SetActive(false);
        this.OptionsContainer.SetActive(true);
    }

    public void OnBackgroundSliderChanged()
    {
        Core.MusicManager.Volume = BackgroundVolumeSlider.value;
    }

    public void CloseOptions()
    {
        this.MainMenuContainer.SetActive(true);
        this.OptionsContainer.SetActive(false);
    }

    public void LoadGame()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}