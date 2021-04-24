using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    public Image planetBase;
    public Image planetLand;
    public Image planetClouds;

    private Header header;

    private void Start()
    {
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
