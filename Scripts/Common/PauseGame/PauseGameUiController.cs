using DaftAppleGames.Common.GameControllers;
using DaftAppleGames.Common.Settings;
using DaftAppleGames.Common.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Common.PauseGame
{
    public class PauseGameUiController : UiController
    {
        [Header("Pause Key Settings")]
        public KeyCode pauseKey = KeyCode.Escape;
        public KeyCode altPauseKey = KeyCode.P;

        [Header("UI Settings")]
        public Button continueButton;
        public Button optionsButton;
        public Button loadButton;
        public Button saveButton;
        public Button mainMenuButton;
        public Button exitDesktopButton;

        private PauseGameManager _pauseGameManager;

        public GameSettingsUiController gameSettingsUiController;

        /// <summary>
        /// Initialise the manager
        /// </summary>
        public override void Start()
        {
            _pauseGameManager = GetComponent<PauseGameManager>();

            InitControls();
            base.Start();
        }

        /// <summary>
        /// Set up button control event listeners
        /// </summary>
        private void InitControls()
        {
            // Options / Game Settings
            optionsButton.onClick.RemoveAllListeners();
            optionsButton.onClick.AddListener(ShowOptions);

            // Continue
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(Continue);

            // Main Menu
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(GoToMainMenu);

            // Exit to Desktop
            exitDesktopButton.onClick.RemoveAllListeners();
            exitDesktopButton.onClick.AddListener(ExitToDesktop);
        }

        /// <summary>
        /// Handle Continue click
        /// </summary>
        public void Continue()
        {
            _pauseGameManager.UnPauseGame();
            HideUi();
        }

        /// <summary>
        /// Handle Show Options click
        /// </summary>
        public void ShowOptions()
        {
            HideUi();
            gameSettingsUiController.ShowUi(this);
        }

        /// <summary>
        /// Handle Exit to Desktop click
        /// </summary>
        public void ExitToDesktop()
        {
            _pauseGameManager.ExitToDesktop();
        }

        /// <summary>
        /// Fade back to the Main Menu scene
        /// </summary>
        public void GoToMainMenu()
        {
            _pauseGameManager.GotoMainMenu();
        }

        /// <summary>
        /// Wait for the pause key
        /// </summary>
        private void Update()
        {
            if(Input.GetKeyDown(pauseKey) || Input.GetKeyDown(altPauseKey))
            {
                bool isPaused = _pauseGameManager.isPaused;

                // Only pause if not paused
                if(!isPaused)
                {
                    _pauseGameManager.PauseGame();
                    ShowUi();
                    return;
                }

                // Only unpause if not in settings UI
                if (isPaused && !gameSettingsUiController.isUiOpen)
                {
                    _pauseGameManager.UnPauseGame();
                    HideUi();
                }
            }
        }
    }
}