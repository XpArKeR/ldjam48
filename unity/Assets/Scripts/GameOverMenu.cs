
using Assets.Scripts;
using Assets.Scripts.Constants;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI PlanesVisitedText;
    // Start is called before the first frame update
    void Start()
    {
        Core.BackgroundAudioSource.Stop();
        PlanesVisitedText.text = Core.GameState.PlanetsVisited.ToString();
    }
        
    // Update is called once per frame
    void Update()
    {

    }

    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
}
