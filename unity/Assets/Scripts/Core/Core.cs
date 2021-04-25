using System;
using System.IO;

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
            LoadConsumptionRates();

            PlanetGenerator.LoadPlanetTypes();
            ShipGenerator.LoadShipTypes();
        }

        private static void LoadConsumptionRates()
        {
            var consumptionRates = JsonUtility.FromJson<ConsumptionRates>(Path.Combine(Application.streamingAssetsPath, "Core", "ConsumptionRates.json"));

            GameState.ConsumptionRates = consumptionRates;
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
