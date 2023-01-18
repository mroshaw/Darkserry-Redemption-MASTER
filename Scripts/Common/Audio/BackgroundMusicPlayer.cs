using System.Collections;
using UnityEngine;
using Time = UnityEngine.Time;

namespace DaftAppleGames.Common.Audio
{
    public class BackgroundMusicPlayer : MonoBehaviour
    {
        [Header("Audio Settings")]
        public AudioClip[] backgroundMusicClips;
        public int startWithClipNumber = 0;
        public float fadeInTime = 2.0f;

        [Header("On Start Settings")]
        public bool playOnStart = true;

        [Header("Multi Audio Settings")]
        public bool cycleAllClips = true;
        public float swapWhenSecondsLeft = 2.0f;

        [Header("Debug")]
        [SerializeField]
        private int _currentClip = 0;
        [SerializeField]
        private float _currentClipLength;
        [SerializeField]
        private float _playedSoFar;
        [SerializeField]
        private bool _inFade = false;

        private int _totalClips;

        private AudioSource _audioSource;

        // Start is called before the first frame update
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();

            _totalClips = backgroundMusicClips.Length;

            if (playOnStart)
            {
                Play();
            }
        }

        /// <summary>
        /// Wait until clip is almost finished, fade out and fade in next
        /// </summary>
        private void Update()
        {
            _playedSoFar = _audioSource.time;

            if (_audioSource.time + swapWhenSecondsLeft >= _currentClipLength && !_inFade)
            {
                _inFade = true;
                int nextClip = _currentClip++;
                if(nextClip > _totalClips)
                {
                    nextClip = 0;
                }
                _currentClip = nextClip;
                FadeOut(true);
            }
        }

        /// <summary>
        /// Start playing the default clip
        /// </summary>
        public void Play()
        {
            _currentClip = startWithClipNumber;
            FadeIn();
        }

        /// <summary>
        /// Fade in the current clip
        /// </summary>
        private void FadeIn()
        {
            StartCoroutine(FadeInAsync());
        }

        /// <summary>
        /// Async coroutine to fade in an audiosource fromn 0 volume.
        /// </summary>
        /// <param name="audioClip"></param>
        /// <param name="fadePeriod"></param>
        /// <returns></returns>
        private IEnumerator FadeInAsync()
        {
            _audioSource.Stop();
            _audioSource.volume = 0;
            _audioSource.clip = backgroundMusicClips[_currentClip];
            _currentClipLength = _audioSource.clip.length;
            _audioSource.Play();

            float time = 0.0f;

            // Lerp up to target volume
            while (time < fadeInTime)
            {
                _audioSource.volume = Mathf.Lerp(0, 1.0f, time / fadeInTime);
                time += Time.deltaTime;
                yield return null;
            }

            _audioSource.volume = 1.0f;
            _inFade = false;
        }

        /// <summary>
        /// Fade out the current clip and start a new one, if specified.
        /// </summary>
        /// <param name="newClip"></param>
        private void FadeOut(bool playNext)
        {
            StartCoroutine(FadeOutAsync(playNext));
        }

        /// <summary>
        /// Async Coroutine to fade an audiosource to 0 volume over time
        /// and start a new clip, if specified
        /// </summary>
        /// <param name="newClip"></param>
        /// <returns></returns>
        private IEnumerator FadeOutAsync(bool playNext)
        {
            float startVolume = _audioSource.volume;

            float time = 0.0f;

            // Lerp in volume
            while (time < fadeInTime)
            {
                _audioSource.volume = Mathf.Lerp(1.0f, 0.0f, time / fadeInTime);
                time += Time.deltaTime;
                yield return null;
            }

            // Fade in the new clip, if specified
            if(playNext)
            {
                _currentClip++;
                if(_currentClip == _totalClips)
                {
                    _currentClip = 0;
                }
                FadeIn();
            }
            _inFade = false;
        }
    }
}