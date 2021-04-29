using System;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public UnityEvent<Boolean> PauseToggled = new UnityEvent<Boolean>();

    public List<AudioSource> AudioSources;
    public List<AudioClip> clips;

    private Int32 toggle = 0;
    private Double nextStartTime;

    private float? oldVolume;

    public float Volume
    {
        get
        {
            return Core.GameState.Options.backgroundVolume;
        }
        set
        {
            if (Core.GameState.Options.backgroundVolume != value)
            {
                Core.GameState.Options.backgroundVolume = value;

                SetVolume(value);
            }
        }
    }

    public Boolean IsPlaying { get; private set; }

    public void Pause()
    {
        this.PauseToggled?.Invoke(true);
    }

    public void Stop()
    {
        if (IsPlaying)
        {
            IsPlaying = false;

            foreach (var audioSource in this.AudioSources)
            {
                audioSource.Stop();
            }
        }
    }

    public void Resume()
    {
        if (!IsPlaying)
        {
            this.StartAudio();
        }
        else
        {
            this.PauseToggled?.Invoke(false);

            if (this.oldVolume.HasValue)
            {
                this.Unmute();
            }
        }
    }

    internal void SetVolume(float backgroundVolume)
    {
        foreach (var audioSource in this.AudioSources)
        {
            audioSource.volume = backgroundVolume;
        }
    }

    public void Mute()
    {
        if (this.Volume > 0)
        {
            this.oldVolume = this.Volume;
            this.Volume = 0;
        }
    }

    public void Unmute()
    {
        if (this.oldVolume.HasValue)
        {
            this.Volume = this.oldVolume.Value;
            this.oldVolume = default;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioSettings.dspTime > nextStartTime)
        {
            QueueAudio();
        }
    }

    private void StartAudio()
    {
        PlayNow();
        QueueAudio();
    }

    private void PlayNow()
    {
        var clip = GetRandomClip();

        var audioSource = AudioSources[toggle];

        var duration = (Double)clip.samples / clip.frequency;

        nextStartTime = AudioSettings.dspTime + 0.2d;

        audioSource.clip = clip;

        Debug.Log(String.Format("Now Playing: {0} at {1} on AudioSource {2}. Duration: {3}", clip.name, AudioSettings.dspTime, toggle, duration));
        audioSource.PlayScheduled(nextStartTime);

        toggle = 1 - toggle;

        IsPlaying = true;
    }

    private void QueueAudio()
    {
        var clip = GetRandomClip();

        var audioSource = AudioSources[toggle];

        var duration = (Double)clip.samples / clip.frequency;

        nextStartTime = nextStartTime + duration;

        audioSource.clip = clip;

        Debug.Log(String.Format("Queued: {0} at {1} on AudioSource {2}. Duration: {3}", clip.name, nextStartTime, toggle, duration));
        audioSource.PlayScheduled(nextStartTime);

        IsPlaying = true;

        toggle = 1 - toggle;
    }

    private AudioClip GetRandomClip()
    {
        var clip = default(AudioClip);

        if (clips.Count > 0)
        {
            clip = clips[UnityEngine.Random.Range(0, clips.Count)];
        }

        return clip;
    }
}
