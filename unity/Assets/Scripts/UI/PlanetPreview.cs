using System.Collections.Generic;
using System.Linq;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPreview : MonoBehaviour
{
    public bool scanned = false;

    public Image planetBase;
    public Image planetLand;
    public Image planetCloud;
    public Text type;
    public Planet planet;

    public SubRangeDisplayer oxygenRangeDisplayer;

    public void SelectThisPlanet()
    {
        if (SceneManager.GetActiveScene().name == SceneNames.Far)
        {
            Core.GameState.CurrentTarget = planet;

            DeleteRandomNotScannedPlanet(Core.GameState.Planets);

            SceneManager.LoadScene(SceneNames.Approach);
        }
        else if (SceneManager.GetActiveScene().name == SceneNames.Approach)
        {
            if (this.scanned)
            {
                SceneManager.LoadScene(SceneNames.Planet);
            }
            else
            {
                Core.GameState.CurrentTarget = planet;
                Scan();
                DeleteRandomNotScannedPlanet(Core.GameState.Planets);
                SceneManager.LoadScene(SceneNames.Close);
            }
        }
        else if (SceneManager.GetActiveScene().name == SceneNames.Close)
        {
            if (this.scanned)
            {
                SceneManager.LoadScene(SceneNames.Planet);
            }
            else
            {
                Core.GameState.CurrentTarget = planet;
                Scan();
                SceneManager.LoadScene(SceneNames.Close);
            }
        }

        if (!Core.GameState.Ship.Move(1f))
        {
            SceneManager.LoadScene(SceneNames.GameOver);
        }        
    }
    private void DeleteRandomNotScannedPlanet(List<Planet> planets)
    {
        List<Planet> notScanned = planets.Where(p => !p.Scanned).ToList();
        int index = UnityEngine.Random.Range(0, notScanned.Count);
        planets.Remove(notScanned[index]);
    }


    public void Scan()
    {
        planetLand.sprite = planet.LandSprite;
        planetLand.color = planet.LandColor;
        planetCloud.sprite = planet.CloudSprite;
        planetCloud.color = planet.CloudColor;
        scanned = true;
        planet.Scanned = true;
        oxygenRangeDisplayer.min = planet.Resources.Oxygen.DispersionRangeMin;
        oxygenRangeDisplayer.max = planet.Resources.Oxygen.DispersionRangeMax;
        oxygenRangeDisplayer.rangeMin = planet.Resources.Oxygen.RangeMin;
        oxygenRangeDisplayer.rangeMax = planet.Resources.Oxygen.RangeMax;
    }
}
