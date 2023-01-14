using DaftAppleGames.Ui;
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
        public AudioSettingsManager audioSettingsManager;

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
        public void RefreshControlState()
        {
            masterVolumeSlider.SetValueWithoutNotify(audioSettingsManager.GetMasterVolume());
            musicVolumeSlider.SetValueWithoutNotify(audioSettingsManager.GetMusicVolume());
            soundFxVolumeSlider.SetValueWithoutNotify(audioSettingsManager.GetSoundFxVolume());
            ambientFxVolumeSlider.SetValueWithoutNotify(audioSettingsManager.GetAmbientFxVolume());
        }

        /// <summary>
        /// UI controller method to manage "Master Volume" UI changes
        /// </summary>
        /// <param name="masterVolumeValue"></param>
        public void UpdateMasterVolume(float masterVolumeValue)
        {
            audioSettingsManager.SetMasterVolume(masterVolumeValue);
        }

        public void UpdateMusicVolume(float musicVolumeValue)
        {
            audioSettingsManager.SetMusicVolume(musicVolumeValue);
        }

        public void UpdateSoundFxVolume(float soundFxVolumeValue)
        {
            audioSettingsManager.SetSoundFxVolume(soundFxVolumeValue);
        }

        public void UpdateAmbientVolume(float ambientVolumeValue)
        {
            audioSettingsManager.SetAmbientVolume(ambientVolumeValue);
        }
    }
}