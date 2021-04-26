
using System;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MusicPlayer;
    public GameObject MainMenuContainer;
    public GameObject LoadSavegameContainer;
    public GameObject OptionsContainer;
    public GameObject CreditsContainer;

    public List<SaveGameSlotMenu> SavegameSlots;

    public Slider BackgroundVolumeSlider;
    public Toggle AnimationEnabledToggle;
    public Image sunShader;
    private Vector3 rotationAxis = new Vector3(0, 0, 1);
    private static readonly float angle = 5f;

    private void Start()
    {
        if (Core.MusicManager == default)
        {
            Core.MusicManager = this.MusicPlayer.GetComponent<MusicManager>();
        }

        if (!Core.MusicManager.IsPlaying)
        {
            Core.MusicManager.Resume();
        }
    }

    private void Update()
    {
        sunShader.transform.Rotate(rotationAxis, angle * Time.deltaTime);
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
        for (int i = 0; i < this.SavegameSlots.Count; i++)
        {
            var savegameSlot = this.SavegameSlots[i];

            savegameSlot.Savegame = Core.Savegames[i];
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
        this.BackgroundVolumeSlider.value = Core.MusicManager.Volume;
        this.AnimationEnabledToggle.isOn = Core.GameState.Options.AreAnimationsEnabled;

        SetVisible(optionsContainer: true);
    }

    public void OnBackgroundSliderChanged()
    {
        Core.MusicManager.Volume = BackgroundVolumeSlider.value;
    }

    public void OnAnimationEnabledToggleValueChanged()
    {
        Core.GameState.Options.AreAnimationsEnabled = this.AnimationEnabledToggle.isOn;
    }

    public void ShowCredits()
    {
        SetVisible(creditsConatiner: true);
    }

    private void SetVisible(Boolean mainMenu = false, Boolean loadSavegameContainer = false, Boolean optionsContainer = false, Boolean creditsConatiner = false)
    {
        this.MainMenuContainer.SetActive(mainMenu);
        this.LoadSavegameContainer.SetActive(loadSavegameContainer);
        this.OptionsContainer.SetActive(optionsContainer);
        this.CreditsContainer.SetActive(creditsConatiner);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
