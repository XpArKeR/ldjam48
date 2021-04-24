using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneNames.Far);
    }

    public void LoadGame()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
