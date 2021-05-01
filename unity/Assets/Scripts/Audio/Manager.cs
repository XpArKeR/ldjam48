
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Manager : MonoBehaviour
    {
        protected float? oldVolume;

        public UnityEvent<Boolean> PauseToggled = new UnityEvent<Boolean>();
        public List<AudioSource> AudioSources;

        private Boolean isPlaying;
        public Boolean IsPlaying
        {
            get
            {
                return this.isPlaying;
            }
            protected set
            {
                if (isPlaying != value)
                {
                    isPlaying = value;
                }
            }
        }

        public float Volume
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

        public virtual void Pause()
        {
            this.PauseToggled?.Invoke(true);
        }

        public virtual void Stop()
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

        public virtual void Resume()
        {
        }

        public virtual void Mute()
        {
            if (this.Volume > 0)
            {
                this.oldVolume = this.Volume;
                this.Volume = 0;
            }
        }

        public virtual void Unmute()
        {
            if (this.oldVolume.HasValue)
            {
                this.Volume = this.oldVolume.Value;
                this.oldVolume = default;
            }
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        public virtual void SetVolume(float backgroundVolume)
        {
            foreach (var audioSource in this.AudioSources)
            {
                audioSource.volume = backgroundVolume;
            }
        }
    }
}
