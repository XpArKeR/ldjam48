using System;

using Assets.Scripts.Ships;
using UnityEngine;

namespace Assets.Scripts
{
    public class Core
    {
        private readonly static ResourceCache resourceCache = new ResourceCache();
        public static ResourceCache ResourceCache
        {
            get
            {
                return resourceCache;
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


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {
            PlanetGenerator.LoadPlanetTypes();
        }

    }
}
