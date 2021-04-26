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

        public Boolean IsVictorious { get; set; }
        public Planet CurrentTarget { get; set; }
        public string CurrentScene { get; set; }
        public ConsumptionRates ConsumptionRates { get; set; }

        public List<Planet> Planets { get; } = new List<Planet>();

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

        public Int32 PlanetsVisited { get; set; }
        public Scene ActiveScene
        {
            get
            {
                return SceneManager.GetActiveScene();
            }
        }


        public GameStateOptions Options { get; internal set; }
    }
}
