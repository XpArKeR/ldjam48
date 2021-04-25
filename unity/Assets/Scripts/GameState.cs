using System;
using System.Collections.Generic;

using Assets.Scripts.Ships;

using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameState
    {
        public Boolean IsVictorious { get; set; }

        public Planet CurrentTarget { get; set; }

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
    }
}
