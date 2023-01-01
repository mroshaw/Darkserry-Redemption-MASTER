using UnityEngine;

namespace DaftAppleGames
{
    /// <summary>
    /// Simple debug behaviour to allow us to quit the game when running debug scenes.
    /// </summary>
    public class TestGameQuitter : MonoBehaviour
    {
        [Header("Configuration")]
        public KeyCode quitKey = KeyCode.Escape;

        /// <summary>
        /// Check for keypress then quit
        /// </summary>
        void Update()
        {
            if(Input.GetKeyDown(quitKey))
            {
                Application.Quit();
            }
        }
    }
}
