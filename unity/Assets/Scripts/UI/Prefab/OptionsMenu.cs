
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider ForegroundVolumeSlider;
    public Slider BackgroundVolumeSlider;
    public Toggle AnimationEnabledToggle;

    private void Start()
    {
        this.UpdateValues();
    }

    private void FixedUpdate()
    {
        this.UpdateValues();
    }

    public void OnForegroundSliderChanged()
    {
        Core.ForegroundMusicManager.Volume = ForegroundVolumeSlider.value;
    }

    public void OnBackgroundSliderChanged()
    {
        Core.BackgroundMusicManager.Volume = BackgroundVolumeSlider.value;
    }

    public void OnAnimationEnabledToggleValueChanged()
    {
        Core.Options.AreAnimationsEnabled = this.AnimationEnabledToggle.isOn;
    }

    public void OnRestoreDefaultsClick()
    {
        Core.ForegroundMusicManager.Volume = 1f;
        Core.BackgroundMusicManager.Volume = 0.125f;
        Core.Options.AreAnimationsEnabled = true;
    }

    private void UpdateValues()
    {
        if (Core.Options != default)
        {
            if (this.ForegroundVolumeSlider.value != Core.Options.ForegroundVolume)
            {
                this.ForegroundVolumeSlider.value = Core.Options.ForegroundVolume;
            }

            if (this.BackgroundVolumeSlider.value != Core.Options.BackgroundVolume)
            {
                this.BackgroundVolumeSlider.value = Core.Options.BackgroundVolume;
            }

            if (this.AnimationEnabledToggle.isOn != Core.Options.AreAnimationsEnabled)
            {
                this.AnimationEnabledToggle.isOn = Core.Options.AreAnimationsEnabled;
            }
        }
    }
}
