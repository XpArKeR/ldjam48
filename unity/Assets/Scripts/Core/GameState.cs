using Assets.Scripts.Ships;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class GameState
    {
        public GameState()
        {
            id = Guid.NewGuid();
        }

        [SerializeField]
        private Guid id;
        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

        [SerializeField]
        private Boolean isVictorious;
        public Boolean IsVictorious
        {
            get
            {
                return isVictorious;
            }
            set
            {
                if (isVictorious != value)
                {
                    isVictorious = value;
                }
            }
        }

        [SerializeField]
        private Planet currentTarget;
        public Planet CurrentTarget
        {
            get
            {
                return currentTarget;
            }
            set
            {
                if (currentTarget != value)
                {
                    currentTarget = value;
                }
            }
        }

        [SerializeField]
        private String currentScene;
        public String CurrentScene
        {
            get
            {
                return currentScene;
            }
            set
            {
                if (currentScene != value)
                {
                    currentScene = value;
                }
            }
        }

        [SerializeField]
        private ConsumptionRates consumptionRates;
        public ConsumptionRates ConsumptionRates
        {
            get
            {
                return consumptionRates;
            }
            set
            {
                if (consumptionRates != value)
                {
                    consumptionRates = value;
                }
            }
        }

        [SerializeField]
        private List<Planet> planets = new List<Planet>();
        public List<Planet> Planets
        {
            get
            {
                return this.planets;
            }
        }

        [SerializeField]
        private SpaceShip ship;
        public SpaceShip Ship
        {
            get
            {
                return ship;
            }
            set
            {
                if (ship != value)
                {
                    ship = value;
                }
            }
        }

        private Starmap starmap;
        public Starmap Starmap
        {
            get
            {
                return starmap;
            }
        }

        [SerializeField]
        private Int32 planetsVisited;
        public Int32 PlanetsVisited
        {
            get
            {
                return planetsVisited;
            }
            set
            {
                if (planetsVisited != value)
                {
                    planetsVisited = value;
                }
            }
        }

        [SerializeField]
        private Int64 savedOnTicks;
        private DateTime? savedOn;
        public DateTime SavedOn
        {
            get
            {
                if ((!savedOn.HasValue) && (savedOnTicks > 0))
                {
                    savedOn = new DateTime(savedOnTicks);
                }

                return savedOn.GetValueOrDefault();
            }
            set
            {
                if (savedOn != value)
                {
                    savedOn = value;
                    savedOnTicks = value.Ticks;
                }
            }
        }

        [SerializeField]
        private String currentBackground;
        public String CurrentBackground
        {
            get
            {
                return this.currentBackground;
            }
            set
            {
                if (this.currentBackground != value)
                {
                    this.currentBackground = value;
                }
            }
        }
    }
}
