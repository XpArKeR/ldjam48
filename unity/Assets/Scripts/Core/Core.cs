using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts.Constants;
using Assets.Scripts.Ships;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Core
    {
        private static Sprite currentBackground;
        private static ConsumptionRates consumptionRates;
                
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
            private set
            {
                if (gameState != value)
                {
                    gameState = value;

                    if (value?.Options != default)
                    {
                        MusicManager.SetVolume(value.Options.BackgroundVolume);
                    }
                }
            }
        }

        public static Sprite GetBackgroundSprite()
        {
            if ((currentBackground == default) && (!String.IsNullOrEmpty(GameState?.CurrentBackground)))
            {
                currentBackground = ResourceCache.GetSprite(GameState.CurrentBackground);
            }

            return currentBackground;
        }

        public static void SetCurrentBackground(Sprite background)
        {
            currentBackground = background;
            GameState.CurrentBackground = background.name;
        }

        public static MusicManager MusicManager { get; set; }
        public static List<Savegame> Savegames { get; private set; }

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
            var loadedConsumptionRates = JsonUtility.FromJson<ConsumptionRates>(Path.Combine(Application.streamingAssetsPath, "Core", "ConsumptionRates.json"));

            consumptionRates = loadedConsumptionRates;
        }

        public static void StartGame(GameState providedGameState = default)
        {
            var effectiveGameState = providedGameState;

            if (effectiveGameState == default)
            {
                effectiveGameState = new GameState()
                {
                    ConsumptionRates = consumptionRates,
                    Ship = ShipGenerator.GenerateShip(ShipGenerator.ShipTypes[0]),
                    Options = new GameStateOptions()
                    {
                        AreAnimationsEnabled = true,
                        BackgroundVolume = 0.125f
                    }
                };

                effectiveGameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
                effectiveGameState.CurrentScene = SceneNames.Far;
            }

            GameState = effectiveGameState;
            ChangeScene(effectiveGameState.CurrentScene);
        }

        private static void LoadSavegames()
        {
            Savegames = new List<Savegame>();

            var directoryPath = Path.Combine(Application.persistentDataPath, "SaveGames");

            if (Directory.Exists(directoryPath))
            {
                foreach (var savegameFile in Directory.EnumerateFiles(directoryPath, "Save*.nerds"))
                {
                    var gameStateJson = File.ReadAllText(savegameFile);

                    var loadedGameState = UnityEngine.JsonUtility.FromJson<GameState>(gameStateJson);

                    Savegames.Add(new Savegame()
                    {
                        PlanetsVisited = loadedGameState.PlanetsVisited,
                        SavedOn = loadedGameState.SavedOn,
                        RawSource = gameStateJson
                    });
                }
            }

            while (Savegames.Count < 3)
            {
                Savegames.Add(default);
            }
        }
    }
}
