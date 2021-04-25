using Assets.Scripts;
using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu;
    public GameObject gameView;

    void Start()
    {
        Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }




    public void doNothin()
    {
        
     
    }

    public void Quit()
    {
        Core.ChangeScene(SceneNames.MainMenu);
    }

    public void ToggleMenu()
    {
        if (menu.activeSelf == true)
        {
            Hide();
        } else
        {
            Show();
        }
    }

    public void Hide()
    {
        menu.SetActive(false);
        gameView.SetActive(true);
    }

    public void Show()
    {        
        CursorMode cursorMode = CursorMode.Auto;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        menu.SetActive(true);
        gameView.SetActive(false);
    }
}
