using DaftAppleGames.Ui;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class DisplaySettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Toggle fullScreenToggle;
        public Slider brightnessSlider;
        public TMP_Dropdown displayResDropDown;

        [Header("Settings Model")]
        public DisplaySettingsManager displaySettingsManager;

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
            fullScreenToggle.onValueChanged.RemoveAllListeners();
            brightnessSlider.onValueChanged.RemoveAllListeners();
            displayResDropDown.onValueChanged.RemoveAllListeners();

            // Configure the Audio setting sliders
            fullScreenToggle.onValueChanged.AddListener(UpdateFullScreen);
            brightnessSlider.onValueChanged.AddListener(UpdateBrightness);
            displayResDropDown.onValueChanged.AddListener(UpdateDisplayResolution);

            // Populate drop downs
            PopulateDisplayResDropDown();
        }

        /// <summary>
        /// Populate the Display Resoluitions drop down with available resolutions
        /// </summary>
        private void PopulateDisplayResDropDown()
        {
            Resolution[] displayResolutionArray = displaySettingsManager.GetDisplayResArray();
            List<string> displayResOptions = new List<string>();

            for (int currRes = 0; currRes < displayResolutionArray.Length; currRes++)
            {
                // Add the resolution option
                string option = $"{displayResolutionArray[currRes].width}x{displayResolutionArray[currRes].height}({displayResolutionArray[currRes].refreshRate}Hz)";
                displayResOptions.Add(option);
            }

            // Configure the Drop Down
            displayResDropDown.ClearOptions();
            displayResDropDown.AddOptions(displayResOptions);
            displayResDropDown.SetValueWithoutNotify(displaySettingsManager.GetCurrentResolutionIndex());
            displayResDropDown.RefreshShownValue();
        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void RefreshControlState()
        {
            fullScreenToggle.SetIsOnWithoutNotify(displaySettingsManager.GetFullScreen());
            brightnessSlider.SetValueWithoutNotify(displaySettingsManager.GetScreenBrightness());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateFullScreen(bool fullScreenValue)
        {
            displaySettingsManager.SetFullScreen(fullScreenValue);
        }

        public void UpdateBrightness(float brightnessValue)
        {
 
        }

        public void UpdateDisplayResolution(int displayResIndexValue)
        {
            displaySettingsManager.SetDisplayResIndex(displayResIndexValue);
        }
    }
}