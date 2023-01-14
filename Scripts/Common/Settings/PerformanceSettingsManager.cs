using System.Collections;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    public class PerformanceSettingsManager : MonoBehaviour, ISettings
    {
        [Header("Performance Defaults")]
        public int defaultTextureResolutionIndex = 0;
        public int defaultAntiAliasingIndex = 0;
        public int defaultQualityPresetIndex = 0;

        [Header("Setting Keys")]
        public string textureResolutionIndexKey = "TextureResolution";
        public string antiAliasingIndexKey = "AntiAliasing";
        public string qualityPresetIndexKey = "QualityPreset";

        private int _textureResolutionIndex;
        private int _antiAliasingIndex;
        private int _qualityPresetIndex;

        private Camera _mainCamera;

        /// <summary>
        /// Setup the component
        /// </summary>
        private void Start()
        {
            InitSettings();
            LoadSettings();
            ApplySettings();
        }

        /// <summary>
        /// Getting for Texture Resolution
        /// </summary>
        /// <returns></returns>
        public int GetTextureResolutionIndex()
        {
            return _textureResolutionIndex;
        }

        /// <summary>
        /// Getter for Anti Aliasing
        /// </summary>
        /// <returns></returns>
        public int GetAntiAliasingIndex()
        {
            return _antiAliasingIndex;
        }

        /// <summary>
        /// Getter for Quality Preset
        /// </summary>
        /// <returns></returns>
        public int GetQualityPresetIndex()
        {
            return _qualityPresetIndex;
        }

        /// <summary>
        /// Save settings to PlayerPrefs
        /// </summary>
        public void SaveSettings()
        {
            PlayerPrefs.SetInt(textureResolutionIndexKey, _textureResolutionIndex);
            PlayerPrefs.SetInt(antiAliasingIndexKey, _antiAliasingIndex);
            PlayerPrefs.SetInt(qualityPresetIndexKey, _qualityPresetIndex);
        }

        /// <summary>
        /// Load settings from PlayerPrefs
        /// </summary>
        public void LoadSettings()
        {
            _textureResolutionIndex = SettingsUtils.LoadIntSetting(textureResolutionIndexKey, defaultTextureResolutionIndex);
            _antiAliasingIndex = SettingsUtils.LoadIntSetting(antiAliasingIndexKey, defaultAntiAliasingIndex);
            _qualityPresetIndex = SettingsUtils.LoadIntSetting(qualityPresetIndexKey, defaultQualityPresetIndex);
        }

        /// <summary>
        /// Initialise the settings
        /// </summary>
        public void InitSettings()
        {
            _mainCamera = GameUtils.FindMainCameraGameObject().GetComponent<Camera>();
        }

        /// <summary>
        /// Updates and applies the Texture Resolution
        /// </summary>
        /// <param name="indexToSet"></param>
        public void SetTextureResolution(int indexToSet)
        {
            _textureResolutionIndex = indexToSet;
            ApplyTextureResolution();
        }

        /// <summary>
        /// Updates and applies Anti Aliasing
        /// </summary>
        /// <param name="indexToSet"></param>
        public void SetAntiAliasing(int indexToSet)
        {
            _antiAliasingIndex = indexToSet;
            ApplyAntiAliasing();
        }

        /// <summary>
        /// Updates and applies Quality Preset
        /// </summary>
        /// <param name="indexToSet"></param>
        public void SetQualityPreset(int indexToSet)
        {
            _qualityPresetIndex = indexToSet;
            ApplyQualityPresets();
        }

        /// <summary>
        /// Apply all current settings
        /// </summary>
        private void ApplySettings()
        {
            ApplyTextureResolution();
            ApplyAntiAliasing();
            ApplyQualityPresets();
        }

        /// <summary>
        /// Apply the Texture Resolution
        /// </summary>
        private void ApplyTextureResolution()
        {
            QualitySettings.masterTextureLimit = _textureResolutionIndex;
        }

        /// <summary>
        /// Apply the Anti Aliasing
        /// </summary>
        private void ApplyAntiAliasing()
        {
            switch(_antiAliasingIndex)
            {
                case 0:
                    QualitySettings.antiAliasing = 8;
                    break;
                case 1:
                    QualitySettings.antiAliasing = 4;
                    break;
                case 2:
                    QualitySettings.antiAliasing = 0;
                    break;
            }
        }

        /// <summary>
        /// Apply the Quality Presets
        /// </summary>
        private void ApplyQualityPresets()
        {
            QualitySettings.SetQualityLevel(_qualityPresetIndex, true);
        }
    }
}