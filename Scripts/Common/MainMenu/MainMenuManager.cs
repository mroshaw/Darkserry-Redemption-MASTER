
using DaftAppleGames.Common.GameControllers;
using UnityEngine;
using DaftAppleGames.Common.Books;

namespace DaftAppleGames.Common.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
#if ASMDEF
#if BOOK
        [Header("Intro Settings")]
        public BookController introBookController;
#endif
#endif
        /// <summary>
        /// Initialise setting controllers
        /// </summary>
        private void Start()
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /// <summary>
        /// Show the Intro book
        /// </summary>
        public void ShowIntro()
        {
#if ASMDEF
#if BOOK
            introBookController.gameObject.SetActive(true);
#endif
#endif
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
