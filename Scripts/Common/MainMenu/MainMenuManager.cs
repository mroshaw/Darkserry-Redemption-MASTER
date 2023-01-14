using DafeAppleGames.UI;
using DaftAppleGames.GameControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DaftAppleGames.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        /// <summary>
        /// Initialise setting controllers
        /// </summary>
        private void Start()
        {

        }

        /// <summary>
        /// Start a new game
        /// </summary>
        public void StartNewGame()
        {
            GameController.LoadMainGameScene();
        }

        /// <summary>
        /// Exit to Desktop
        /// </summary>
        public void ExitToDesktop()
        {
            Application.Quit();
        }

        /// <summary>
        /// Set the Selected Character as Emily
        /// </summary>
        public void SetSelectedCharEmily()
        {
            GameController.Instance.SelectedCharacter = CharSelection.Emily;
        }

        /// <summary>
        /// Set the Selected Character as Callum
        /// </summary>
        public void SetSelectedCharCallum()
        {
            GameController.Instance.SelectedCharacter = CharSelection.Callum;
        }


    }
}