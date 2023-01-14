using UnityEngine;

namespace DaftAppleGames.Settings
{
    public class GameSettingsManager : MonoBehaviour
    {
        private AudioSettingsManager _audioSettingsManager;
        private DisplaySettingsManager _displaySettingsManager;
        private GameplaySettingsManager _gameplaySettingsManager;
        private PerformanceSettingsManager _performanceSettingsManager;

        /// <summary>
        /// Initialise setting controllers
        /// </summary>
        private void Start()
        {
            _audioSettingsManager = GetComponentInChildren<AudioSettingsManager>(true);
            _displaySettingsManager = GetComponentInChildren<DisplaySettingsManager>(true);
            _gameplaySettingsManager = GetComponentInChildren<GameplaySettingsManager>(true);
            _performanceSettingsManager = GetComponentInChildren<PerformanceSettingsManager>(true);
        }

        /// <summary>
        /// Save all settings
        /// </summary>
        public void SaveSettings()
        {
            _audioSettingsManager.SaveSettings();
            _displaySettingsManager.SaveSettings();
            _gameplaySettingsManager.SaveSettings();
            _performanceSettingsManager.SaveSettings();
        }

        /// <summary>
        /// Load all settings
        /// </summary>
        public void LoadSettings()
        {
            _audioSettingsManager.LoadSettings();
            _displaySettingsManager.LoadSettings();
            _gameplaySettingsManager.LoadSettings();
            _performanceSettingsManager.LoadSettings();
        }
    }
}