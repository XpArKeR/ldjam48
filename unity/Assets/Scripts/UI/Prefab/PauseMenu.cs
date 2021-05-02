using Assets.Scripts;
using Assets.Scripts.Constants;

using System;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public List<SaveGameSlotMenu> SavegameSlots;

    public GameObject menu;
    public GameObject gameView;
    public GameObject menuArea;
    public GameObject saveArea;
    public GameObject optionsArea;
    public Button saveGameButton;

    void Start()
    {
        EventTrigger tooltip = saveGameButton.GetComponent<EventTrigger>();

        if (Core.IsFileAccessPossible)
        {
            tooltip.enabled = false;
        }
        else
        {
            saveGameButton.interactable = false;
            tooltip.enabled = true;
        }

        Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (menu.activeSelf == true)
        {
            Hide();

            Time.timeScale = 1;
            Core.BackgroundMusicManager.Resume();
        }
        else
        {
            Time.timeScale = 0;
            Core.BackgroundMusicManager.Pause();

            Show();
        }
    }

    public void ToggleSaveGameVisible()
    {
        if (menuArea.activeSelf)
        {
            ShowSaveGameArea();
        }
        else
        {
            HideSaveGameArea();
        }
    }

    public void ToggleOptionsVisible()
    {
        if (optionsArea.activeSelf)
        {
            HideOptionsGameArea();
        }
        else
        {
            ShowOptionsGameArea();
        }
    }

    public void SaveGameSlotSelected(SaveGameSlotMenu slot)
    {
        Core.GameState.SavedOn = DateTime.Now;

        var gameStateString = UnityEngine.JsonUtility.ToJson(Core.GameState, true);

        var directoryPath = Path.Combine(Application.persistentDataPath, "Savegames");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var slotIndex = SavegameSlots.IndexOf(slot);

        var fileName = Path.Combine(directoryPath, String.Format("Save{0}.nerds", slotIndex));

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        File.WriteAllText(fileName, gameStateString);

        Core.Savegames[slotIndex] = new Savegame()
        {
            PlanetsVisited = Core.GameState.PlanetsVisited,
            SavedOn = Core.GameState.SavedOn,
            RawSource = gameStateString
        };

        this.HideSaveGameArea();
    }

    public void Quit()
    {
        Core.ChangeScene(SceneNames.MainMenu);
    }

    public void Hide()
    {
        if (menuArea.activeSelf)
        {
            this.HideSaveGameArea();
        }

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

    private void ShowOptionsGameArea()
    {
        menuArea.SetActive(false);
        optionsArea.SetActive(true);
    }

    private void HideOptionsGameArea()
    {
        menuArea.SetActive(true);
        optionsArea.SetActive(false);
    }


    private void ShowSaveGameArea()
    {
        menuArea.SetActive(false);
        saveArea.SetActive(true);

        for (int i = 0; i < this.SavegameSlots.Count; i++)
        {
            var savegameSlot = this.SavegameSlots[i];

            savegameSlot.Savegame = Core.Savegames[i];
        }
    }

    private void HideSaveGameArea()
    {
        menuArea.SetActive(true);
        saveArea.SetActive(false);
    }
}
