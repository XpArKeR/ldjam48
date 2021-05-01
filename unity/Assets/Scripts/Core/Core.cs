using Assets.Scripts.Audio;
using Assets.Scripts.Constants;
using Assets.Scripts.Ships;

using System;
using System.Collections.Generic;
using System.IO;

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

        private static PlayerOptions options;
        public static PlayerOptions Options
        {
            get
            {
                return options;
            }
            private set
            {
                if (options != value)
                {
                    options = value;
                }
            }
        }

        private static GameState gameState;
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
                }
            }
        }

        private static BackgroundManager backgroundMusicManager;
        public static BackgroundManager BackgroundMusicManager
        {
            get
            {
                return backgroundMusicManager;
            }
            set
            {
                if (backgroundMusicManager != value)
                {
                    backgroundMusicManager = value;
                }
            }
        }

        private static ForegroundManager foregroundMusicManager;
        public static ForegroundManager ForegroundMusicManager
        {
            get
            {
                return foregroundMusicManager;
            }
            set
            {
                if (foregroundMusicManager != value)
                {
                    foregroundMusicManager = value;
                }
            }
        }

        public static List<Savegame> Savegames { get; } = new List<Savegame>();

        private static Boolean isFileAccessPossible;
        public static Boolean IsFileAccessPossible
        {
            get
            {
                return isFileAccessPossible;
            }
            private set
            {
                if (isFileAccessPossible != value)
                {
                    isFileAccessPossible = value;
                }
            }
        }

        public static void OnClose()
        {
            SavePlayerOptions();
        }

        public static Sprite GetBackgroundSprite()
        {
            if ((currentBackground == default) && (!String.IsNullOrEmpty(GameState?.CurrentBackground)))
            {
                currentBackground = ResourceCache.GetSprite(Path.Combine("UI", "Sprites", GameState.CurrentBackground));
            }

            return currentBackground;
        }

        public static void SetCurrentBackground(Sprite background)
        {
            currentBackground = background;
            GameState.CurrentBackground = background.name;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitGame()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.Android)
            {
                IsFileAccessPossible = false;
            }
            else
            {
                IsFileAccessPossible = true;
            }

            LoadPlayerOptions();
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
            var loadedConsumptionRates = default(ConsumptionRates);

            if (IsFileAccessPossible)
            {
                loadedConsumptionRates = JsonUtility.FromJson<ConsumptionRates>(Path.Combine(Application.streamingAssetsPath, "Core", "ConsumptionRates.json"));
            }
            else
            {
                loadedConsumptionRates = Constants.Defaults.ConsumptionRates;
            }

            if (loadedConsumptionRates == default)
            {
                throw new MissingComponentException("Consumption");
            }

            consumptionRates = loadedConsumptionRates;
        }

        public static void StartGame(GameState providedGameState = default)
        {
            var effectiveGameState = providedGameState;

            if (effectiveGameState == default)
            {
                effectiveGameState = new GameState();
                effectiveGameState.ConsumptionRates = consumptionRates;
                effectiveGameState.Ship = ShipGenerator.GenerateShip(ShipGenerator.ShipTypes[0]);
                //{
                //    ConsumptionRates = consumptionRates,
                //    Ship = ShipGenerator.GenerateShip(ShipGenerator.ShipTypes[0]),
                //    Options = new GameStateOptions()
                //    {
                //        AreAnimationsEnabled = true,
                //        BackgroundVolume = 0.125f
                //    }
                //};

                effectiveGameState.Planets.AddRange(PlanetGenerator.GeneratePlanets(4));
                effectiveGameState.CurrentScene = SceneNames.Far;
            }

            GameState = effectiveGameState;
            ChangeScene(effectiveGameState.CurrentScene);
        }

        private static void LoadPlayerOptions()
        {
            var configString = PlayerPrefs.GetString("PlayerOptions");

            Options = UnityEngine.JsonUtility.FromJson<PlayerOptions>(configString);

            if (Options == default)
            {
                Debug.Log("Failed to load PlayerOptions.");
                Options = new PlayerOptions()
                {
                    AreAnimationsEnabled = true,
                    BackgroundVolume = 0.125f,
                    ForegroundVolume = 1f
                };
            }
        }

        private static void SavePlayerOptions()
        {
            var optionsString = UnityEngine.JsonUtility.ToJson(Options);

            PlayerPrefs.SetString("PlayerOptions", optionsString);
        }

        private static void LoadSavegames()
        {
            if (IsFileAccessPossible)
            {
                var directoryPath = Path.Combine(Application.persistentDataPath, "Savegames");

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
}
