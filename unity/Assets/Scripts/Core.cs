using System;

using Assets.Scripts.Ships;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public static MusicManager MusicManager{ get; set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {
            PlanetGenerator.LoadPlanetTypes();
            ShipGenerator.LoadShipTypes();
        }

        public static void ChangeScene(String sceneName)
        {
            CursorMode cursorMode = CursorMode.Auto;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            gameState.CurrentScene = sceneName;
            SceneManager.LoadScene(sceneName);
        }
    }
}
