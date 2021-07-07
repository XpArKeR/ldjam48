using System;

namespace Balancer.Model.Planets
{
    public class Planet : NotifyingObject
    {
        public Planet()
        {
            this.ID = Guid.NewGuid();
        }

        private Guid id;
        public Guid ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                SetProperty(ref this.id, value);
            }
        }

        private PlanetType type;
        public PlanetType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                SetProperty(ref this.type, value);
            }
        }

        private Boolean scanned;
        public Boolean Scanned
        {
            get
            {
                return this.scanned;
            }
            set
            {
                SetProperty(ref this.scanned, value);
            }
        }

        private PlanetResources resources;
        public PlanetResources Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                SetProperty(ref this.resources, value);
            }
        }

        private UnityColor baseColor;
        public UnityColor BaseColor
        {
            get
            {
                return this.baseColor;
            }
            set
            {
                SetProperty(ref this.baseColor, value);
            }
        }

        public UnityColor landColor;
        public UnityColor LandColor
        {
            get
            {
                return this.landColor;
            }
            set
            {
                SetProperty(ref this.landColor, value);
            }
        }

        private UnityColor cloudColor;
        public UnityColor CloudColor
        {
            get
            {
                return this.cloudColor;
            }
            set
            {
                SetProperty(ref this.cloudColor, value);
            }
        }

        private String landSprite;
        public String LandSprite
        {
            get
            {
                return this.landSprite;
            }
            set
            {
                SetProperty(ref this.landSprite, value);
            }
        }

        private String cloudSprite;
        public String CloudSprite
        {
            get
            {
                return this.cloudSprite;
            }
            set
            {
                SetProperty(ref this.cloudSprite, value);
            }
        }
    }
}
