
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
