using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    public class GameSettingsManager : MonoBehaviour
    {
        private AudioSettingsManager _audioSettingsManager;
        private DisplaySettingsManager _displaySettingsManager;
        private GameplaySettingsManager _gameplaySettingsManager;
        private PerformanceSettingsManager _performanceSettingsManager;

        public bool hasAudioSettings = false;
        public bool hasDisplaySettings = false;
        public bool hasGameplaySettings = false;
        public bool hasPerformanceSettings = false;

        /// <summary>
        /// Initialise setting controllers
        /// </summary>
        private void Start()
        {
            _audioSettingsManager = GetComponent<AudioSettingsManager>();
            if(_audioSettingsManager)
            {
                hasAudioSettings = true;
            }

            _displaySettingsManager = GetComponent<DisplaySettingsManager>();
            if (_displaySettingsManager)
            {
                hasDisplaySettings = true;
            }

            _gameplaySettingsManager = GetComponent<GameplaySettingsManager>();
            if (_gameplaySettingsManager)
            {
                hasGameplaySettings = true;
            }

            _performanceSettingsManager = GetComponent<PerformanceSettingsManager>();
            if (_performanceSettingsManager)
            {
                hasPerformanceSettings = true;
            }
        }

        public void SaveSettings()
        {
            if(hasAudioSettings)
            {
                _audioSettingsManager.SaveSettings();
            }

            if(hasDisplaySettings)
            {
                _displaySettingsManager.SaveSettings();
            }

            if(hasGameplaySettings)
            {
                _gameplaySettingsManager.SaveSettings();
            }

            if(hasPerformanceSettings)
            {
                _performanceSettingsManager.SaveSettings();
            }
        }

        public void LoadSettings()
        {
            if (hasAudioSettings)
            {
                _audioSettingsManager.LoadSettings();
            }

            if (hasDisplaySettings)
            {
                _displaySettingsManager.LoadSettings();
            }

            if (hasGameplaySettings)
            {
                _gameplaySettingsManager.LoadSettings();
            }

            if (hasPerformanceSettings)
            {
                _performanceSettingsManager.LoadSettings();
            }
        }
    }
}