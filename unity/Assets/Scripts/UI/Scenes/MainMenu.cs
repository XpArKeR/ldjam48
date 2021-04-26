
using Assets.Scripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MusicPlayer;
    public GameObject MainMenuContainer;
    public GameObject OptionsContainer;
    public GameObject CreditsContainer;
    public Slider BackgroundVolumeSlider;
    public Toggle AnimationEnabledToggle;
    public Image sunShader;
    private Vector3 rotationAxis = new Vector3(0, 0, 1);
    private static readonly float angle = 5f;

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

    private void Update()
    {
        sunShader.transform.Rotate(rotationAxis, angle * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    public void StartGame()
    {
        Core.GameState.Ship = ShipGenerator.GenerateShip(ShipGenerator.ShipTypes[0]);

        Core.GameState.PlanetsVisited = 0;

        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
        Core.ChangeScene(SceneNames.Far);
    }

    public void ShowOptions()
    {
        this.BackgroundVolumeSlider.value = Core.MusicManager.Volume;
        this.AnimationEnabledToggle.isOn = Core.GameState.Options.AreAnimationsEnabled;

        this.MainMenuContainer.SetActive(false);
        this.OptionsContainer.SetActive(true);
        this.CreditsContainer.SetActive(false);
    }

    public void OnBackgroundSliderChanged()
    {
        Core.MusicManager.Volume = BackgroundVolumeSlider.value;
    }

    public void ShowMainMenu()
    {
        this.MainMenuContainer.SetActive(true);
        this.OptionsContainer.SetActive(false);
        this.CreditsContainer.SetActive(false);
    }

    public void LoadGame()
    {

    }

    public void ShowCredits()
    {
        this.MainMenuContainer.SetActive(false);
        this.OptionsContainer.SetActive(false);
        this.CreditsContainer.SetActive(true);
    }

    public void OnAnimationEnabledToggleValueChanged()
    {
        Core.GameState.Options.AreAnimationsEnabled = this.AnimationEnabledToggle.isOn;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
