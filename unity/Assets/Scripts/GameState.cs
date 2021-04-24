using System;

using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameState
    {
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
