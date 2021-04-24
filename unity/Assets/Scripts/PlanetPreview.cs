using Assets.Scripts;
using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPreview : MonoBehaviour
{
    public Image planet;
    public Text type;
    public Planet thisPlanet;

    public void SelectThisPlanet()
    {
        Core.GameState.CurrentTarget = thisPlanet;
        Core.GameState.Planets.Remove(thisPlanet);
        DeleteRandomPlanet(Core.GameState.Planets);
        Core.GameState.Planets.Add(thisPlanet);
        SceneManager.LoadScene(SceneNames.Approach);
    }
    private void DeleteRandomPlanet(List<Planet> planets)
    {
        int index = UnityEngine.Random.Range(0, planets.Count);
        planets.RemoveAt(index);
    }
}
