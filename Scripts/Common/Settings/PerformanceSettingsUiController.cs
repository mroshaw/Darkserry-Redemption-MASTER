using DaftAppleGames.Common.Ui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Common.Settings
{
    public class PerformanceSettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public TMP_Dropdown textureResDropdown;
        public TMP_Dropdown antiAliasingDropdown;
        public TMP_Dropdown qualityPresetDropdown;

        [Header("Settings Model")]
        public PerformanceSettingsManager performanceSettingsManager;

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
            textureResDropdown.onValueChanged.RemoveAllListeners();
            antiAliasingDropdown.onValueChanged.RemoveAllListeners();
            qualityPresetDropdown.onValueChanged.RemoveAllListeners();

            // Configure the Audio setting sliders
            textureResDropdown.onValueChanged.AddListener(UpdateTextureResolution);
            antiAliasingDropdown.onValueChanged.AddListener(UpdateAntiAliasing);
            qualityPresetDropdown.onValueChanged.AddListener(UpdateQualityPreset);
        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void RefreshControlState()
        {
            textureResDropdown.SetValueWithoutNotify(performanceSettingsManager.GetTextureResolutionIndex());
            antiAliasingDropdown.SetValueWithoutNotify(performanceSettingsManager.GetAntiAliasingIndex());
            qualityPresetDropdown.SetValueWithoutNotify(performanceSettingsManager.GetQualityPresetIndex());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateTextureResolution(int textureResIndex)
        {
            performanceSettingsManager.SetTextureResolution(textureResIndex);
        }

        /// <summary>
        /// Handle Anti Aliasing value change
        /// </summary>
        /// <param name="antiAliasingIndex"></param>
        public void UpdateAntiAliasing(int antiAliasingIndex)
        {
            performanceSettingsManager.SetAntiAliasing(antiAliasingIndex);
        }

        /// <summary>
        /// Handle Quality Preset value changed
        /// </summary>
        /// <param name="qualityPresetIndex"></param>
        public void UpdateQualityPreset(int qualityPresetIndex)
        {
            performanceSettingsManager.SetQualityPreset(qualityPresetIndex);
        }
    }
}