using UnityEngine;

namespace DaftAppleGames.PauseGame
{
    /// <summary>
    /// Implementation of the Pause Game functionality
    /// </summary>
    public class PauseGameManager : MonoBehaviour
    {
        public bool isPaused = false;

        /// <summary>
        /// Toggle the current pause state
        /// </summary>
        /// <returns></returns>
        public bool TogglePauseGame()
        {
            if(isPaused)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            }
            return isPaused;
        }

        /// <summary>
        /// Pause the game
        /// </summary>
        public void PauseGame()
        {
            isPaused = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
        }

        /// <summary>
        /// Unpause the game
        /// </summary>
        public void UnPauseGame()
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Exit To Desktop
        /// </summary>
        public void ExitToDesktop()
        {
            Application.Quit();
        }
    }
}