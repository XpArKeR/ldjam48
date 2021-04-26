using System;
using System.Collections.Generic;

using Assets.Scripts.Ships;

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

        public Guid id;
        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

        public Boolean isVictorious;
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

        public Planet currentTarget;
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

        public String currentScene;
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

        public ConsumptionRates consumptionRates;
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

        public List<Planet> planets = new List<Planet>();
        public List<Planet> Planets
        {
            get
            {
                return this.planets;
            }
        }

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

        public Int32 planetsVisited;
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

        public GameStateOptions options;
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

        public Scene ActiveScene
        {
            get
            {
                return SceneManager.GetActiveScene();
            }
        }


    }
}
