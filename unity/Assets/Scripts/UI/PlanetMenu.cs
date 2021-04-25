
using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
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

        if ((!Core.GameState.IsVictorious) && Core.GameState.PlanetsVisited > 19)
        {
            Core.GameState.IsVictorious = true;
            Core.ChangeScene(SceneNames.Victorious);
        }
    }

    public void FlyAway()
    {
        Core.GameState.PlanetsVisited++;
        Core.GameState.Planets.Clear();
        Core.GameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));

        Core.MusicManager.Mute();

        FlyOffAudioSource.Play();

        StartCoroutine(FlyOffAudioSource.WaitForSound(() =>
        {
            Core.ChangeScene(SceneNames.Far);
            Core.MusicManager.Unmute();
        }));
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
        var leftoverValue = Core.GameState.Ship.AddOxygen(Core.GameState.CurrentTarget.Resources.Oxygen.Value);
        Core.GameState.CurrentTarget.Resources.Oxygen.Value = leftoverValue;
        planetOxygen.text = Core.GameState.CurrentTarget.Resources.Oxygen.Value.ToString("N0");

        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherOxygen))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
    }

    public void TakeFood()
    {
        var leftoverValue = Core.GameState.Ship.AddFood(Core.GameState.CurrentTarget.Resources.Food.Value);
        Core.GameState.CurrentTarget.Resources.Food.Value = leftoverValue;
        planetFood.text = Core.GameState.CurrentTarget.Resources.Food.Value.ToString("N0");

        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherFood))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
    }

    public void TakeFuel()
    {
        var leftoverValue = Core.GameState.Ship.AddFuel(Core.GameState.CurrentTarget.Resources.Fuel.Value);
        Core.GameState.CurrentTarget.Resources.Fuel.Value = leftoverValue;
        planetFuel.text = Core.GameState.CurrentTarget.Resources.Fuel.Value.ToString("N0");

        if (!Core.GameState.Ship.Consume(Core.GameState.ConsumptionRates.GatherFuel))
        {
            Core.ChangeScene(SceneNames.GameOver);
        }
    }
}
