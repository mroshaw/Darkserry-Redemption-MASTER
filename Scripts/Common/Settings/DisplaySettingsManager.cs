using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings
{
    public class DisplaySettingsManager : MonoBehaviour, ISettings
    {
        [Header("Screen Defaults")]
        public float defaultScreenBrightness = 1.0f;
        public bool defaultFullScreen = true;

        [Header("Setting Keys")]
        public string screenBrightnessKey = "ScreenBrightness";
        public string fullScreenKey = "FullScreen";

        private float _screenBrightness;
        private bool _fullScreen;

        // Start is called before the first frame update
        private void Start()
        {

        }

        public bool GetFullScreen()
        {
            return _fullScreen;
        }

        public float GetScreenBrightness()
        {
            return _screenBrightness;
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetFloat(screenBrightnessKey, _screenBrightness);
            PlayerPrefs.SetInt(fullScreenKey, Convert.ToInt32(_fullScreen));
        }

        public void LoadSettings()
        {
                _screenBrightness = SettingsUtils.LoadFloatSetting(screenBrightnessKey, defaultScreenBrightness);
                _fullScreen = SettingsUtils.LoadBoolSetting(fullScreenKey, defaultFullScreen);
        }

        public void InitSettings()
        {

        }

        public void ApplySettings()
        {
            UpdateScreenBrightness();
            UpdateFullScreen();
        }

        public void SetScreenBrightness(float screenBrightnessToSet)
        {
            _screenBrightness = screenBrightnessToSet;
            UpdateScreenBrightness();
        }

        public void SetFullScreen(bool fullScreenToSet)
        {
            _fullScreen = fullScreenToSet;
            UpdateFullScreen();
        }

        /// <summary>
        /// Set the Master Volume
        /// </summary>
        private void UpdateScreenBrightness()
        {

        }

        private void UpdateFullScreen()
        {

        }
    }
}