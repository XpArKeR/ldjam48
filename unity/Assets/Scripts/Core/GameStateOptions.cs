using System;

namespace Assets.Scripts
{
    [Serializable]
    public class GameStateOptions
    {
        public Boolean areAnimationsEnabled;
        public Boolean AreAnimationsEnabled
        {
            get
            {
                return this.areAnimationsEnabled;
            }
            set
            {
                if (this.areAnimationsEnabled != value)
                {
                    this.areAnimationsEnabled = value;
                }
            }
        }

        public float backgroundVolume;
        public float BackgroundVolume
        {
            get
            {
                return this.backgroundVolume;
            }
            set
            {
                if (this.backgroundVolume != value)
                {
                    this.backgroundVolume = value;
                }
            }
        }
    }
}