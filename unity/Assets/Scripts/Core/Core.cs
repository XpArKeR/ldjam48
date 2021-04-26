using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Core
    {
        internal static Sprite currentBackground;

        private readonly static ResourceCache resourceCache = new ResourceCache();
        public static ResourceCache ResourceCache
        {
            get
            {
                return resourceCache;
            }
        }

        private static GameState gameState = new GameState()
        {
            Options = new GameStateOptions()
            {
                AreAnimationsEnabled = true,
                BackgroundVolume = 0.125f
            }
        };
        public static GameState GameState
        {
            get
            {
                return gameState;
            }
        }

        public static MusicManager MusicManager { get; set; }
        public static List<GameState> Savegames { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {
            LoadConsumptionRates();
            LoadSavegames();

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

        private static void LoadConsumptionRates()
        {
            var consumptionRates = JsonUtility.FromJson<ConsumptionRates>(Path.Combine(Application.streamingAssetsPath, "Core", "ConsumptionRates.json"));

            GameState.ConsumptionRates = consumptionRates;
        }

        private static void LoadSavegames()
        {
            Savegames = new List<GameState>();

            var directoryPath = Path.Combine(Application.persistentDataPath, "SaveGames");

            if (Directory.Exists(directoryPath))
            {
                foreach (var savegameFile in Directory.EnumerateFiles(directoryPath, "Save*.nerds"))
                {
                    var loadedGameState = UnityEngine.JsonUtility.FromJson<GameState>(File.ReadAllText(savegameFile));

                    Savegames.Add(loadedGameState);
                }
            }

            while (Savegames.Count < 3)
            {
                Savegames.Add(default);
            }
        }
    }
}
