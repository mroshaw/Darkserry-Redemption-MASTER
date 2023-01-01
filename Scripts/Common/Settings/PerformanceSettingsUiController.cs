using DaftAppleGames.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class PerformanceSettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Toggle perfModeToggle;

        [Header("Settings Model")]
        private PerformanceSettingsManager _performanceSettingsManager;

        /// <summary>
        /// Initialise the Settings Component
        /// </summary>
        public override void Start()
        {
            _performanceSettingsManager = GetComponent<PerformanceSettingsManager>();
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
            perfModeToggle.onValueChanged.RemoveAllListeners();

            // Configure the Audio setting sliders
            perfModeToggle.onValueChanged.AddListener(UpdatePerfMode);
        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void ConfigureSettingsControls()
        {
            perfModeToggle.SetIsOnWithoutNotify(_performanceSettingsManager.GetPerfMode());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdatePerfMode(bool fullScreenValue)
        {
            
        }
    }
}