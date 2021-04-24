using System;

using Assets.Scripts.Ships;

namespace Assets.Scripts
{
    public class Core
    {

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
