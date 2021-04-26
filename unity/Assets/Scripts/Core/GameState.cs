using System;
using System.Collections.Generic;

using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.SceneManagement;

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
        private GameStateOptions options;
        public GameStateOptions Options
        {
            get
            {
                return options;
            }
            set
            {
                if (options != value)
                {
                    options = value;
                }
            }
        }

        [SerializeField]
        private string savedOnString;
        private DateTime? savedOn;
        public DateTime SavedOn
        {
            get
            {
                if ((!savedOn.HasValue) && (!String.IsNullOrEmpty(savedOnString)))
                {
                    savedOn = Convert.ToDateTime(savedOnString);
                }

                return savedOn.GetValueOrDefault();
            }
            set
            {
                if (savedOn != value)
                {
                    savedOn = value;
                    savedOnString = Convert.ToString(value);
                }
            }
        }

        public Scene ActiveScene
        {
            get
            {
                return SceneManager.GetActiveScene();
            }
        }
    }
}
