using System;

using Assets.Scripts.Ships;

namespace Assets.Scripts
{
    public class Core
    {
        private static SpaceShip ship;
        public static SpaceShip Ship
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

        private static GameState gameState = new GameState();
        public static GameState GameState
        {
            get
            {
                return gameState;
            }
        }
    }
}
