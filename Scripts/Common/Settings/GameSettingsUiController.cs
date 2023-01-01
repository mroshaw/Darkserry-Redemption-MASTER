using DaftAppleGames.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class GameSettingsUiController : UiController
    {
        [Header("UI Config - Header")]
        public Button audioHeaderButton;
        public Button displayHeaderButton;
        public Button gameplayHeaderButton;
        public Button performanceHeaderButton;

        [Header("UI Config - Buttons")]
        public Button saveSettingsButton;
        public Button cancelSettingsButton;

        private bool _isOpenedByOtherUi = false;
        private UiController _invokingUiController;

        private GameSettingsManager _gameSettingsManager;

        // All the settings Ui Controllers
        private AudioSettingsUiController _audioSettingsUiController;
        private DisplaySettingsUiController _displaySettingsUiController;
        private GameplaySettingsUiController _gameplaySettingsUiController;
        private PerformanceSettingsUiController _performanceSettingsUiController;

        private bool hasAudioSettings = false;
        private bool hasDisplaySettings = false;
        private bool hasGameplaySettings = false;
        private bool hasPerformanceSettings = false;

        /// <summary>
        /// Configure the UI
        /// </summary>
        public override void Start()
        {
            _gameSettingsManager = GetComponent<GameSettingsManager>();

            _audioSettingsUiController = GetComponentInChildren<AudioSettingsUiController>(true);
            if(_audioSettingsUiController)
            {
                hasAudioSettings = true;
            }

            _displaySettingsUiController = GetComponentInChildren<DisplaySettingsUiController>(true);
            if (_displaySettingsUiController)
            {
                hasDisplaySettings = true;
            }

            _gameplaySettingsUiController = GetComponentInChildren<GameplaySettingsUiController>(true);
            if (_gameplaySettingsUiController)
            {
                hasGameplaySettings = true;
            }

            _performanceSettingsUiController = GetComponentInChildren<PerformanceSettingsUiController>(true);
            if (_performanceSettingsUiController)
            {
                hasPerformanceSettings = true;
            }

            InitControls();
            base.Start();
        }

        /// <summary>
        /// Show the UI from within another UI Controller
        /// </summary>
        /// <param name="invokingUiController"></param>
        public void ShowUi(UiController invokingUiController)
        {
            _isOpenedByOtherUi = true;
            _invokingUiController = invokingUiController;
            invokingUiController.HideUi();
            base.ShowUi();
        }

        /// <summary>
        /// Show the UI
        /// </summary>
        public override void ShowUi()
        {
            _isOpenedByOtherUi = false;
            base.ShowUi();
        }

        /// <summary>
        /// Configures the button UI events
        /// </summary>
        private void InitControls()
        {
            audioHeaderButton.onClick.RemoveAllListeners();
            audioHeaderButton.onClick.AddListener(ShowAudioSettings);

            displayHeaderButton.onClick.RemoveAllListeners();
            displayHeaderButton.onClick.AddListener(ShowDisplaySettings);

            gameplayHeaderButton.onClick.RemoveAllListeners();
            gameplayHeaderButton.onClick.AddListener(ShowGameplaySettings);

            performanceHeaderButton.onClick.RemoveAllListeners();
            performanceHeaderButton.onClick.AddListener(ShowPerformanceSettings);

            saveSettingsButton.onClick.RemoveAllListeners();
            saveSettingsButton.onClick.AddListener(SaveSettings);

            cancelSettingsButton.onClick.RemoveAllListeners();
            cancelSettingsButton.onClick.AddListener(CancelSettings);
        }

        /// <summary>
        /// Show the Audio Settings UI panel
        /// </summary>
        public void ShowAudioSettings()
        {
            // Close other settings
            _displaySettingsUiController.HideUi();
            _gameplaySettingsUiController.HideUi();
            _performanceSettingsUiController.HideUi();

            // Open the Audio Settings
            _audioSettingsUiController.ShowUi();
        }

        /// <summary>
        /// Show the Display Settings UI panel
        /// </summary>
        public void ShowDisplaySettings()
        {
            // Hide other settings
            _audioSettingsUiController.HideUi();
            _gameplaySettingsUiController.HideUi();
            _performanceSettingsUiController.HideUi();

            // Show Display settings
            _displaySettingsUiController.ShowUi();
        }

        /// <summary>
        /// Show the Gameplay Settings UI panel
        /// </summary>
        public void ShowGameplaySettings()
        {
            // Hide other settings
            _audioSettingsUiController.HideUi();
            _performanceSettingsUiController.HideUi();
            _displaySettingsUiController.HideUi();

            // Show Gameplay settings
            _gameplaySettingsUiController.ShowUi();
        }

        /// <summary>
        /// Show the Performance Settings ui panel
        /// </summary>
        public void ShowPerformanceSettings()
        {
            // Hide other settings
            _audioSettingsUiController.HideUi();
            _gameplaySettingsUiController.HideUi();
            _performanceSettingsUiController.HideUi();
            _displaySettingsUiController.HideUi();

            // Show Performance settings
            _performanceSettingsUiController.ShowUi();
        }

        /// <summary>
        /// Calls the Save Settings method of the model
        /// </summary>
        public void SaveSettings()
        {
            _gameSettingsManager.SaveSettings();
            CloseUi();
        }

        /// <summary>
        /// Calls the Cancel Settings method of the model
        /// </summary>
        public void CancelSettings()
        {
            CloseUi();
        }

        /// <summary>
        /// Close the UI and open any invoking UI Controller
        /// </summary>
        private void CloseUi()
        {
            HideUi();
            if (_isOpenedByOtherUi)
            {
                _invokingUiController.ShowUi();
            }
        }
    }
}