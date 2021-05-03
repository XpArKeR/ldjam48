using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Constants;

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
    public GameObject BackButton;
    public GameObject ContinueButton;

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

    public void ShowSavegames()
    {
        for (int i = 0; i < this.SavegameSlots.Count; i++)
        {
            var savegameSlot = this.SavegameSlots[i];

            savegameSlot.Savegame = Core.Savegames[i];
        }

        this.SetVisible(savegames: true);
    }

    public void ShowOptions()
    {
        this.SetVisible(options: true);
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

        SetVisible(pauseMenu: true);
    }

    public void Quit()
    {
        Core.CloseGamestate();
        Core.ChangeScene(SceneNames.MainMenu);
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

        SetVisible(pauseMenu: true);

        menu.SetActive(true);
        gameView.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        SetVisible(pauseMenu: true);
    }

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

    private void SetVisible(Boolean pauseMenu = false, Boolean savegames = false, Boolean options = false)
    {
        this.menuArea.SetActive(pauseMenu);
        this.optionsArea.SetActive(options);
        this.saveArea.SetActive(savegames);

        this.ContinueButton.SetActive(pauseMenu);
        this.BackButton.SetActive(!pauseMenu);
    }
}
