using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings
{
    public class GameplaySettingsManager : MonoBehaviour, ISettings
    {
        [Header("Gameplay Defaults")]
        public bool defaultBloodAndGore = true;

        [Header("Setting Keys")]
        public string bloodAndGoreKey = "BloodAndGore";

        private bool _bloodAndGore;

        // Start is called before the first frame update
        private void Start()
        {

        }

        public bool GetBlooodAndGore()
        {
            return _bloodAndGore;
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt(bloodAndGoreKey, Convert.ToInt32(_bloodAndGore));
        }

        public void LoadSettings()
        {
                _bloodAndGore = SettingsUtils.LoadBoolSetting(bloodAndGoreKey, defaultBloodAndGore);
        }

        public void InitSettings()
        {

        }

        public void ApplySettings()
        {
            UpdateBloodAndGore();
        }

        public void SetBloodAndGore(bool bloodAndGoreToSet)
        {
            _bloodAndGore = bloodAndGoreToSet;
            UpdateBloodAndGore();
        }

        private void UpdateBloodAndGore()
        {

        }
    }
}