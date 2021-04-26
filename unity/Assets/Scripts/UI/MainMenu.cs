
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
    public Slider BackgroundVolumeSlider;
    public Image sunShader;
    private Vector3 rotationAxis = new Vector3(0, 0, 1);
    private static readonly float angle = 1.5f;

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
