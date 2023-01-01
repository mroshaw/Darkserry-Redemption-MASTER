using DaftAppleGames.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class GameplaySettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Toggle bloodAndGoreToggle;

        [Header("Settings Model")]
        private GameplaySettingsManager _gameplaySettingsManager;

        /// <summary>
        /// Initialise the Settings Component
        /// </summary>
        public override void Start()
        {
            _gameplaySettingsManager = GetComponent<GameplaySettingsManager>();
            InitControls();
            ConfigureSettingsControls();
            base.Start();
        }

        /// <summary>
        /// Configure the UI control handlers to call public methods
        /// </summary>
        private void InitControls()
        {
            // Remove all listeners, to prevent doubling up.
            bloodAndGoreToggle.onValueChanged.RemoveAllListeners();

            // Configure the Gameplay setting controls
            bloodAndGoreToggle.onValueChanged.AddListener(UpdateBloodAndGore);
        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void ConfigureSettingsControls()
        {
            bloodAndGoreToggle.SetIsOnWithoutNotify(_gameplaySettingsManager.GetBlooodAndGore());
        }

        /// <summary>
        /// UI controller method to manage "Blood and Gore" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateBloodAndGore(bool bloodAndGoreValue)
        {
            
        }
    }
}