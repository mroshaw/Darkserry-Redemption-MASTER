using DaftAppleGames.Common.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Common.Settings
{
    public class GameplaySettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Toggle bloodAndGoreToggle;

        [Header("Settings Model")]
        public GameplaySettingsManager gameplaySettingsManager;

        /// <summary>
        /// Initialise the Settings Component
        /// </summary>
        public override void Start()
        {
            InitControls();
            RefreshControlState();
            base.Start();
        }

        /// <summary>
        /// Override ShowUi to refresh controls
        /// </summary>
        public override void ShowUi()
        {
            RefreshControlState();
            base.ShowUi();
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
        public void RefreshControlState()
        {
            bloodAndGoreToggle.SetIsOnWithoutNotify(gameplaySettingsManager.GetBlooodAndGore());
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