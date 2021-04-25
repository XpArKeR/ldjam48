
using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Core.BackgroundAudioSource.Stop();
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
