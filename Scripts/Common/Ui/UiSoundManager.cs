using UnityEngine;
using UnityEngine.UIElements;

namespace DaftAppleGames.Common.Ui
{


    public class UiSoundManager : MonoBehaviour
    {
        [Header("Sound Clip Settings")]
        [SerializeField]
        public UiSoundSettings uiSoundSettings;

        private static AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            if (!_audioSource)
            {
                Debug.LogError("UiSound: Can't find AudioSource! Check your GameObject!");
            }
        }

        private void PlayClickSound()
        {
            _audioSource.PlayOneShot(uiSoundSettings.clickClip);
        }

        private void PlayBigClickClipSound()
        {
            _audioSource.PlayOneShot(uiSoundSettings.bigClickClip);
        }

        public void PlayerCancelClickClip()
        {
            _audioSource.PlayOneShot(uiSoundSettings.cancelClickClip);
        }
    }
}