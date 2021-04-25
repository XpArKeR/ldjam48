
using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriousMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Core.MusicManager.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnContinuePlaying()
    {
        Core.MusicManager.Resume();
        SceneManager.LoadScene(SceneNames.Planet);
    }
    
    public void OnBackToMainMenu()
    {
        Core.ChangeScene(SceneNames.MainMenu);
    }
}
