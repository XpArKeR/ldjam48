using Assets.Scripts.Ships;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameState
    {

        public Planet CurrentTarget { get; set; }

        public List<Planet> Planets { get; } = new List<Planet>();
      

        private SpaceShip ship = new SpaceShip()
        {
            MaxOxygenLevel = 1000f,
            OxygenLevel = 1000f,
            OxygenConsumption = 100f,
            MaxFoodLevel = 100f,
            FoodLevel = 100f,
            FoodConsumption = 10f,
            MaxFuelLevel = 1000f,
            FuelLevel = 500f,
            FuelConsumtion = 100f,
        };
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

        public Int32 CurrentTurn { get; set; }
        public Scene ActiveScene
        {
            get
            {
                return SceneManager.GetActiveScene();
            }
        }
    }
}
