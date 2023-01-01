using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings
{
    public class PerformanceSettingsManager : MonoBehaviour, ISettings
    {
        [Header("Performance Defaults")]
        public bool defaultPerfMode = true;

        [Header("Setting Keys")]
        public string perfModeKey = "PerfMode";

        private bool _perfMode;

        // Start is called before the first frame update
        private void Start()
        {

        }

        public bool GetPerfMode()
        {
            return _perfMode;
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt(perfModeKey, Convert.ToInt32(_perfMode));
        }

        public void LoadSettings()
        {
                _perfMode = SettingsUtils.LoadBoolSetting(perfModeKey, defaultPerfMode);
        }

        public void InitSettings()
        {

        }

        public void ApplySettings()
        {
            UpdatePerfMode();
        }

        public void SetPerfMode(bool perfModeToSet)
        {
            _perfMode = perfModeToSet;
            UpdatePerfMode();
        }

        /// <summary>
        /// Set the Master Volume
        /// </summary>
        private void UpdatePerfMode()
        {

        }
    }
}