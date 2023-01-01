using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings
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


        // Start is called before the first frame update
        private void Start()
        {

        }

        public void SaveSettings()
        {
            PlayerPrefs.SetFloat(masterVolumeKey, _masterVolume);
            PlayerPrefs.SetFloat(musicVolumeKey, _musicVolume);
            PlayerPrefs.SetFloat(soundFxVolumeKey, _soundFxVolume);
            PlayerPrefs.SetFloat(ambientVolumeKey, _ambientVolume);
        }

        public void LoadSettings()
        {
            if(PlayerPrefs.HasKey("MasterVolume"))
            {
                _masterVolume = SettingsUtils.LoadFloatSetting(masterVolumeKey, defaultMasterVolume);
                _musicVolume = SettingsUtils.LoadFloatSetting(musicVolumeKey, defaultMusicVolume);
                _soundFxVolume = SettingsUtils.LoadFloatSetting(soundFxVolumeKey, _soundFxVolume);
                _ambientVolume = SettingsUtils.LoadFloatSetting(ambientVolumeKey, _ambientVolume);
            }
        }

        public void InitSettings()
        {

        }

        public void ApplySettings()
        {
            UpdateMasterVolume();
            UpdateMusicVolume();
            UpdateSoundFxVolume();
            UpdateAmbientVolume();
        }

        public void SetMasterVolume(float volumeToSet)
        {
            _masterVolume = volumeToSet;
            UpdateMasterVolume();
        }

        public void SetMusicVolume(float volumeToSet)
        {
            _musicVolume = volumeToSet;
            UpdateMusicVolume();
        }

        public void SetSoundFxVolume(float volumeToSet)
        {
            _soundFxVolume = volumeToSet;
            UpdateSoundFxVolume();
        }

        public void SetAmbientVolume(float volumeToSet)
        {
            _ambientVolume = volumeToSet;
            UpdateAmbientVolume();
        }

        public float GetMasterVolume()
        {
            return _masterVolume;
        }

        /// <summary>
        /// Set the Master Volume
        /// </summary>
        private void UpdateMasterVolume()
        {
            audioMixer.SetFloat(masterVolumeName, _masterVolume);
        }

        private void UpdateSoundFxVolume()
        {
            audioMixer.SetFloat(soundFxVolumeName, _soundFxVolume);
        }

        private void UpdateMusicVolume()
        {
            audioMixer.SetFloat(masterVolumeName, _musicVolume);
        }

        private void UpdateAmbientVolume()
        {
            audioMixer.SetFloat(ambientFxVolumeName, _ambientVolume);
        }
    }
}