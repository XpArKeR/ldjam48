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
        if (Core.Options != default)
        {
            this.ForegroundVolumeSlider.value = Core.Options.ForegroundVolume;
            this.BackgroundVolumeSlider.value = Core.Options.BackgroundVolume;
            this.AnimationEnabledToggle.isOn = Core.Options.AreAnimationsEnabled;
        }
    }

    private void FixedUpdate()
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
}
