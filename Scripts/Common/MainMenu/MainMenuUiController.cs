using DaftAppleGames.Settings;
using DaftAppleGames.Ui;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.MainMenu
{
    public class MainMenuUiController : UiController, IUiController
    {
        [Header("UI Configuration")]
        public Button newGameButton;
        public Button optionsButton;
        public Button loadGameButton;
        public Button exitToDesktopButton;
        public TextMeshProUGUI versionText;

        [Header("Game Scene")]
        public string gameSceneName;
        
        [Header("Game Settings Menu")]
        public GameSettingsUiController gameSettingsUiController;

        private MainMenuManager _mainMenuManager;

        /// <summary>
        /// Init the UI
        /// </summary>
        public override void Start()
        {
            _mainMenuManager = GetComponent<MainMenuManager>();
            InitControls();
            SetVersion();
            base.Start();
        }

        /// <summary>
        /// Implementation of InitControls
        /// </summary>
        public void InitControls()
        {
            newGameButton.onClick.RemoveAllListeners();
            newGameButton.onClick.AddListener(NewGame);

            optionsButton.onClick.RemoveAllListeners();
            optionsButton.onClick.AddListener(ShowOptions);

            loadGameButton.onClick.RemoveAllListeners();
            loadGameButton.onClick.AddListener(LoadGame);

            exitToDesktopButton.onClick.RemoveAllListeners();
            exitToDesktopButton.onClick.AddListener(ExitToDesktop);
        }

        private void NewGame()
        {

        }

        private void ShowOptions()
        {
            // Show the Game Settings UI
            HideUi();
            gameSettingsUiController.ShowUi(this);
        }

        private void LoadGame()
        {

        }

        /// <summary>
        /// Handle Exit to Desktop button click
        /// </summary>
        private void ExitToDesktop()
        {
            _mainMenuManager.ExitToDesktop();
        }

        /// <summary>
        /// Sets the version control in the Ui
        /// </summary>
        private void SetVersion()
        {
            string version = Application.version;
            versionText.text = version;
        }
    }
}