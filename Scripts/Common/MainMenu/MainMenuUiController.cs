using DaftAppleGames.Settings;
using DaftAppleGames.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        public GameObject mainMenuFirstSelected;

        [Header("Main Camera Settings")]
        public RotateCameraAroundObject mainCameraRotation;

        [Header("Char Select Ui Configuration")]
        public GameObject charSelectUi;
        public Button selectEmilyButton;
        public Button selectCallumButton;
        public Button charSelectStartGameButton;
        public Button charSelectBackButton;
        public GameObject charSelectFirstSelected;
        
        [Header("Game Settings Menu")]
        public GameSettingsUiController gameSettingsUiController;

        private MainMenuManager _mainMenuManager;

        /// <summary>
        /// Init the UI
        /// </summary>
        public override void Start()
        {
            base.Start();
            _mainMenuManager = GetComponent<MainMenuManager>();
            InitControls();
            SetVersion();
            charSelectUi.SetActive(false);
            EventSystem.current.firstSelectedGameObject = mainMenuFirstSelected;
            ShowUi();
        }

        /// <summary>
        /// Implementation of InitControls
        /// </summary>
        public void InitControls()
        {
            newGameButton.onClick.RemoveAllListeners();
            newGameButton.onClick.AddListener(ShowCharSelect);

            optionsButton.onClick.RemoveAllListeners();
            optionsButton.onClick.AddListener(ShowOptions);

            loadGameButton.onClick.RemoveAllListeners();
            loadGameButton.onClick.AddListener(LoadGame);

            exitToDesktopButton.onClick.RemoveAllListeners();
            exitToDesktopButton.onClick.AddListener(ExitToDesktop);

            charSelectStartGameButton.onClick.RemoveAllListeners();
            charSelectStartGameButton.onClick.AddListener(StartGame);

            charSelectBackButton.onClick.RemoveAllListeners();
            charSelectBackButton.onClick.AddListener(CharSelectBack);

            selectEmilyButton.onClick.RemoveAllListeners();
            selectEmilyButton.onClick.AddListener(SelectEmily);

            selectCallumButton.onClick.RemoveAllListeners();
            selectCallumButton.onClick.AddListener(SelectCallum);

        }

        /// <summary>
        /// ShowUi override
        /// </summary>
        public override void ShowUi()
        {
            base.ShowUi();
            EventSystem.current.SetSelectedGameObject(mainMenuFirstSelected);
            mainCameraRotation.Resume();
        }

        /// <summary>
        /// HideUi override
        /// </summary>
        public override void HideUi()
        {
            mainCameraRotation.Pause();
            base.HideUi();
        }

        /// <summary>
        /// Show the Character Select UI
        /// </summary>
        private void ShowCharSelect()
        {
            HideUi();
            charSelectUi.SetActive(true);
            EventSystem.current.SetSelectedGameObject(charSelectFirstSelected);
        }

        /// <summary>
        /// Handle the "Select Emily" char select button
        /// </summary>
        private void SelectEmily()
        {
            _mainMenuManager.SetSelectedCharEmily();
        }

        /// <summary>
        /// Handle the "Select Callum" char select button
        /// </summary>
        private void SelectCallum()
        {
            _mainMenuManager.SetSelectedCharCallum();
        }

        /// <summary>
        /// Handle the Start Game button click
        /// </summary>
        private void StartGame()
        {
            _mainMenuManager.StartNewGame();
        }

        /// <summary>
        /// Handle the Back button click
        /// </summary>
        public void CharSelectBack()
        {
            charSelectUi.SetActive(false);
            ShowUi();
        }

        /// <summary>
        /// Handle the Show UI button click
        /// </summary>
        private void ShowOptions()
        {
            // Show the Game Settings UI
            HideUi();
            gameSettingsUiController.ShowUi(this);
        }

        /// <summary>
        /// Handle the Load Game button click
        /// </summary>
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