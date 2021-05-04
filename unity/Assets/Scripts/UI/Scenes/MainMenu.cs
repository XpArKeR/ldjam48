
using System;
using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Audio;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public BackgroundManager BackgroundManager;
    public ForegroundManager ForegroundManager;
    public GameObject MainMenuContainer;
    public GameObject LoadSavegameContainer;
    public GameObject OptionsContainer;
    public GameObject CreditsContainer;
    public Button loadGameButton;
    public GameObject QuitButton;
    public GameObject BackButton;

    public List<SaveGameSlotMenu> SavegameSlots;

    public Text VersionText;
    public Image sunShader;
    private Vector3 rotationAxis = new Vector3(0, 0, 1);
    private static readonly float angle = 5f;

    private void Start()
    {
        EventTrigger tooltip = loadGameButton.GetComponent<EventTrigger>();

        if (Core.IsFileAccessPossible)
        {
            tooltip.enabled = false;
        }
        else
        {
            loadGameButton.interactable = false;
            tooltip.enabled = true;
        }

        this.VersionText.text = String.Format("Version: {0}", Application.version);

        if (Core.BackgroundMusicManager == default)
        {
            Core.BackgroundMusicManager = this.BackgroundManager;
            Core.BackgroundMusicManager.Initialize();            
        }

        if (Core.ForegroundMusicManager == default)
        {
            Core.ForegroundMusicManager = this.ForegroundManager;
            Core.ForegroundMusicManager.Initialize();
        }

        if (!Core.BackgroundMusicManager.IsPlaying)
        {
            Core.BackgroundMusicManager.Resume();
        }
        else
        {
            Core.BackgroundMusicManager.Unmute();
        }
    }

    private void OnApplicationQuit()
    {
        Core.OnClose();
    }

    private void Update()
    {
        sunShader.transform.Rotate(rotationAxis, angle * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    public void StartGame()
    {
        Core.StartGame();
    }

    public void ShowMainMenu()
    {
        SetVisible(mainMenu: true);
    }

    public void ShowLoadSavegame()
    {
        if (Core.IsFileAccessPossible)
        {
            for (int i = 0; i < this.SavegameSlots.Count; i++)
            {
                var savegameSlot = this.SavegameSlots[i];

                savegameSlot.Savegame = Core.Savegames[i];
            }
        }

        SetVisible(loadSavegameContainer: true);
    }

    public void LoadGameState(SaveGameSlotMenu saveGameSlotMenu)
    {
        if (saveGameSlotMenu.Savegame != default)
        {
            var gameState = UnityEngine.JsonUtility.FromJson<GameState>(saveGameSlotMenu.Savegame.RawSource);

            Core.StartGame(gameState);
        }
    }

    public void ShowOptions()
    {
        SetVisible(optionsContainer: true);
    }

    public void ShowCredits()
    {
        SetVisible(creditsConatiner: true);
    }

    private void SetVisible(Boolean mainMenu = false, Boolean loadSavegameContainer = false, Boolean optionsContainer = false, Boolean creditsConatiner = false)
    {
        this.MainMenuContainer.SetActive(mainMenu);

        if (mainMenu)
        {
            this.QuitButton.SetActive(true);
            this.BackButton.SetActive(false);
        }
        else
        {
            this.QuitButton.SetActive(false);
            this.BackButton.SetActive(true);
        }

        this.LoadSavegameContainer.SetActive(loadSavegameContainer);
        this.OptionsContainer.SetActive(optionsContainer);
        this.CreditsContainer.SetActive(creditsConatiner);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
