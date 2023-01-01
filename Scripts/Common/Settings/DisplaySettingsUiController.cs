using DaftAppleGames.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class DisplaySettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Toggle fullScreenToggle;
        public Slider brightnessSlider;

        [Header("Settings Model")]
        private DisplaySettingsManager _displaySettingsManager;

        /// <summary>
        /// Initialise the Settings Component
        /// </summary>
        public override void Start()
        {
            _displaySettingsManager = GetComponent<DisplaySettingsManager>();
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
            fullScreenToggle.onValueChanged.RemoveAllListeners();
            brightnessSlider.onValueChanged.RemoveAllListeners();

            // Configure the Audio setting sliders
            fullScreenToggle.onValueChanged.AddListener(UpdateFullScreen);
            brightnessSlider.onValueChanged.AddListener(UpdateBrightness);

        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void ConfigureSettingsControls()
        {
            fullScreenToggle.SetIsOnWithoutNotify(_displaySettingsManager.GetFullScreen());
            brightnessSlider.SetValueWithoutNotify(_displaySettingsManager.GetScreenBrightness());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateFullScreen(bool fullScreenValue)
        {
            
        }

        public void UpdateBrightness(float brightnessValue)
        {
 
        }
    }
}