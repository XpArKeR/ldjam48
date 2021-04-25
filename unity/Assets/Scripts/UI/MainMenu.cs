
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
        if (Core.BackgroundAudioSource == default)
        {
            Core.BackgroundAudioSource = this.MusicPlayer.GetComponent<AudioSource>();
        }

        if (!Core.BackgroundAudioSource.isPlaying)
        {
            Core.BackgroundAudioSource.Play();
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
            MaxFoodLevel = 100f,
            FoodLevel = 100f,
            FoodConsumption = 10f,
            MaxFuelLevel = 1000f,
            FuelLevel = 500f,
            FuelConsumtion = 100f,
        };

        SceneManager.LoadScene(SceneNames.Far);
    }

    public void ShowOptions()
    {
        this.BackgroundVolumeSlider.value = Core.BackgroundAudioSource.volume;

        this.MainMenuContainer.SetActive(false);
        this.OptionsContainer.SetActive(true);
    }

    public void OnBackgroundSliderChanged()
    {
        Core.BackgroundAudioSource.volume = BackgroundVolumeSlider.value;
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
