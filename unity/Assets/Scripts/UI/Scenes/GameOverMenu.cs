
using Assets.Scripts;
using Assets.Scripts.Constants;

using TMPro;

using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI PlanesVisitedText;
    // Start is called before the first frame update
    void Start()
    {
        Core.MusicManager.Stop();
        PlanesVisitedText.text = Core.GameState.PlanetsVisited.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBackToMainMenu()
    {
        Core.ChangeScene(SceneNames.MainMenu);
    }
}
