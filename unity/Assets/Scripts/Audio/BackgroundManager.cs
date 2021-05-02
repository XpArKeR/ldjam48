
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class BackgroundManager : Manager
    {
        public List<AudioClip> clips;

        private Int32 toggle = 0;
        private Double nextStartTime;

        public override float Volume
        {
            get
            {
                return Core.Options.BackgroundVolume;
            }
            set
            {
                if (Core.Options.BackgroundVolume != value)
                {
                    Core.Options.BackgroundVolume = value;

                    SetVolume(value);
                }
            }
        }

        public override void Resume()
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

        // Start is called before the first frame update
        protected override void Start()
        {
            StartAudio();
        }

        // Update is called once per frame
        protected override void Update()
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
}
