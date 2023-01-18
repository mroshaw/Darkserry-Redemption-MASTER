using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Common.Settings
{
    public class AudioSettingsManager : MonoBehaviour, ISettings
    {
        [Header("Audio Mixer Configuration")]
        public AudioMixer audioMixer;
        public string masterVolumeName = "MasterVolume";
        public string musicVolumeName = "MusicVolume";
        public string soundFxVolumeName = "SoundFxVolume";
        public string ambientFxVolumeName = "AmbientVolume";

        [Header("Audio Volume Defaults")]
        public float defaultMasterVolume = 1.0f;
        public float defaultMusicVolume = 1.0f;
        public float defaultSoundFxVolume = 1.0f;
        public float defaultAmbientVolume = 1.0f;

        [Header("Setting Keys")]
        public string masterVolumeKey = "MasterVolume";
        public string musicVolumeKey = "MusicVolume";
        public string soundFxVolumeKey = "SoundFxVolume";
        public string ambientVolumeKey = "AmbientVolume";

        private float _masterVolume = 1.0f;
        private float _musicVolume = 1.0f;
        private float _soundFxVolume = 1.0f;
        private float _ambientVolume = 1.0f;


        /// <summary>
        /// Initialise the component
        /// </summary>
        private void Awake()
        {
            InitSettings();
            LoadSettings();
            ApplySettings();
        }

        /// <summary>
        /// Save settings to Player Prefs
        /// </summary>
        public void SaveSettings()
        {
            PlayerPrefs.SetFloat(masterVolumeKey, _masterVolume);
            PlayerPrefs.SetFloat(musicVolumeKey, _musicVolume);
            PlayerPrefs.SetFloat(soundFxVolumeKey, _soundFxVolume);
            PlayerPrefs.SetFloat(ambientVolumeKey, _ambientVolume);
        }

        /// <summary>
        /// Load settings from Player prefs
        /// </summary>
        public void LoadSettings()
        {
            _masterVolume = SettingsUtils.LoadFloatSetting(masterVolumeKey, defaultMasterVolume);
            _musicVolume = SettingsUtils.LoadFloatSetting(musicVolumeKey, defaultMusicVolume);
            _soundFxVolume = SettingsUtils.LoadFloatSetting(soundFxVolumeKey, defaultSoundFxVolume);
            _ambientVolume = SettingsUtils.LoadFloatSetting(ambientVolumeKey, defaultMusicVolume);
        }

        /// <summary>
        /// Init lists or arrays
        /// </summary>
        public void InitSettings()
        {

        }

        /// <summary>
        /// Apply all current settings
        /// </summary>
        public void ApplySettings()
        {
            ApplyMasterVolume();
            ApplyMusicVolume();
            ApplySoundFxVolume();
            ApplyAmbientVolume();
        }

        /// <summary>
        /// Set the Master Volume
        /// </summary>
        /// <param name="volumeToSet"></param>
        public void SetMasterVolume(float volumeToSet)
        {
            _masterVolume = volumeToSet;
            ApplyMasterVolume();
        }

        /// <summary>
        /// Set the Music Volume
        /// </summary>
        /// <param name="volumeToSet"></param>
        public void SetMusicVolume(float volumeToSet)
        {
            _musicVolume = volumeToSet;
            ApplyMusicVolume();
        }

        /// <summary>
        /// Set the Sound FX volume
        /// </summary>
        /// <param name="volumeToSet"></param>
        public void SetSoundFxVolume(float volumeToSet)
        {
            _soundFxVolume = volumeToSet;
            ApplySoundFxVolume();
        }

        /// <summary>
        /// Get the current Ambient FX volume
        /// </summary>
        /// <param name="volumeToSet"></param>
        public void SetAmbientVolume(float volumeToSet)
        {
            _ambientVolume = volumeToSet;
            ApplyAmbientVolume();
        }

        /// <summary>
        /// Get the current Master Volume
        /// </summary>
        /// <returns></returns>
        public float GetMasterVolume()
        {
            return _masterVolume;
        }

        /// <summary>
        /// Public getter for Music Volume
        /// </summary>
        /// <returns></returns>
        public float GetMusicVolume()
        {
            return _musicVolume;
        }

        /// <summary>
        /// Public getter for SoundFx volume
        /// </summary>
        /// <returns></returns>
        public float GetSoundFxVolume()
        {
            return _soundFxVolume;
        }

        /// <summary>
        /// Public getter for AmbientFx volume
        /// </summary>
        /// <returns></returns>
        public float GetAmbientFxVolume()
        {
            return _ambientVolume;
        }

        /// <summary>
        /// Apply the current Master Volume
        /// </summary>
        private void ApplyMasterVolume()
        {
            audioMixer.SetFloat(masterVolumeName, _masterVolume);
        }

        /// <summary>
        /// Apply the current Sound FX Volume
        /// </summary>
        private void ApplySoundFxVolume()
        {
            audioMixer.SetFloat(soundFxVolumeName, _soundFxVolume);
        }

        /// <summary>
        /// Apply the current Music Volume
        /// </summary>
        private void ApplyMusicVolume()
        {
            audioMixer.SetFloat(musicVolumeName, _musicVolume);
        }

        /// <summary>
        /// Apply the current Ambient FX Volume
        /// </summary>
        private void ApplyAmbientVolume()
        {
            audioMixer.SetFloat(ambientFxVolumeName, _ambientVolume);
        }
    }
}