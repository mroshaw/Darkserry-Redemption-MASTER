using DaftAppleGames.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    public class AudioSettingsUiController : UiController
    {
        [Header("UI Configuration")]
        public Slider masterVolumeSlider;
        public Slider musicVolumeSlider;
        public Slider soundFxVolumeSlider;
        public Slider ambientFxVolumeSlider;

        [Header("Settings Model")]
        private AudioSettingsManager _audioSettingsManager;

        /// <summary>
        /// Initialise the Settings Component
        /// </summary>
        public override void Start()
        {
            _audioSettingsManager = GetComponent<AudioSettingsManager>();
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
            masterVolumeSlider.onValueChanged.RemoveAllListeners();
            musicVolumeSlider.onValueChanged.RemoveAllListeners();
            soundFxVolumeSlider.onValueChanged.RemoveAllListeners();
            ambientFxVolumeSlider.onValueChanged.RemoveAllListeners();

            // Configure the Audio setting sliders
            masterVolumeSlider.onValueChanged.AddListener(UpdateMasterVolume);
            musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
            soundFxVolumeSlider.onValueChanged.AddListener(UpdateSoundFxVolume);
            ambientFxVolumeSlider.onValueChanged.AddListener(UpdateAmbientVolume);
        }

        /// <summary>
        /// Initiatlise the controls with current settings
        /// </summary>
        public void ConfigureSettingsControls()
        {
            masterVolumeSlider.SetValueWithoutNotify(_audioSettingsManager.GetMasterVolume());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateMasterVolume(float masterVolumeValue)
        {
            _audioSettingsManager.SetMasterVolume(masterVolumeValue);
        }

        public void UpdateMusicVolume(float musicVolumeValue)
        {
            _audioSettingsManager.SetMusicVolume(musicVolumeValue);
        }

        public void UpdateSoundFxVolume(float soundFxVolumeValue)
        {
            _audioSettingsManager.SetSoundFxVolume(soundFxVolumeValue);
        }

        public void UpdateAmbientVolume(float ambientVolumeValue)
        {
            _audioSettingsManager.SetAmbientVolume(ambientVolumeValue);
        }
    }
}