using UnityEngine;

namespace DaftAppleGames.Common.Ui
{
    public class UiSoundManager : MonoBehaviour
    {
        [Header("Sound Clip Settings")]
        public AudioClip clickClip;
        public AudioClip bigClickClip;
        public AudioClip cancelClip;
        public AudioClip backClip;

        private static AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            if (!_audioSource)
            {
                Debug.LogError("UiSound: Can't find AudioSource! Check your GameObject!");
            }
        }

        /// <summary>
        /// Public method to play Clip click
        /// </summary>
        public void PlayClick()
        {
            _audioSource.PlayOneShot(clickClip);
        }

        /// <summary>
        /// Public method to play Big Click clip
        /// </summary>
        public void PlayBig()
        {
            _audioSource.PlayOneShot(bigClickClip);
        }

        /// <summary>
        /// Public method to play Cancel clip
        /// </summary>
        public void PlayCancel()
        {
            _audioSource.PlayOneShot(cancelClip);
        }

        /// <summary>
        /// Public method to play Back clip
        /// </summary>
        public void PlayBack()
        {
            _audioSource.PlayOneShot(backClip);
        }
    }
}