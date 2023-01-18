using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Common.UI
{
    public class SceneFader : MonoBehaviour
    {
        [Header("Control")]
        public bool fadeInOnStart = true;

        [Header("Canvas Fade")]
        public float delayBeforeScreenFadeIn = 2.0f;
        public float delayBeforeScreenFadeOut = 0.0f;
        public float sceneFadeInDuration = 5.0f;
        public float sceneFadeOutDuration = 5.0f;

        private Canvas _fadeCanvas;
        private GameObject _fadeCanvasGameObject;
        private CanvasGroup _fadeCanvasGroup;

        [Header("Audio Fade")]
        public bool fadeAudio = true;
        public float delayBeforeAudioFadeIn = 0.0f;
        public float delayBeforeAudioFadeOut = 0.0f;
        public float audioFadeInDuration = 5.0f;
        public float audioFadeOutDuration = 5.0f;
        public AudioMixer audioMixer;

        private bool _isFading = false;
        public bool IsFading { get { return _isFading; } }

        private float _volumeSetting;

        /// <summary>
        /// Register with OnSceneLoad
        /// </summary>
        public void Awake()
        {
            _fadeCanvas = GetComponentInChildren<Canvas>(true);
            _fadeCanvasGameObject = _fadeCanvas.gameObject;

            // Enable the black canvas
            _fadeCanvasGameObject.SetActive(true);

            // Get the Canvas group for fading
            _fadeCanvasGroup = GetComponentInChildren<CanvasGroup>(true);
        }

        /// <summary>
        /// Begin fade, if enabled
        /// </summary>
        private void Start()
        {
            if (fadeInOnStart)
            {
                audioMixer.GetFloat("MasterVolume", out _volumeSetting);
                audioMixer.SetFloat("MasterVolume", -80.0f);
                FadeIn();
            }
        }

        /// <summary>
        /// Public method to fade in
        /// </summary>
        public void FadeIn()
        {
            _fadeCanvasGameObject.SetActive(true);
            _fadeCanvasGroup.alpha = 1.0f;
            _isFading = true;
            FadeInAudio();
            FadeInCanvas();
        }

        /// <summary>
        /// Public method to fade out
        /// </summary>
        public void FadeOut()
        {
            _fadeCanvasGameObject.SetActive(true);
            _fadeCanvasGroup.alpha = 0.0f;
            _isFading = true;
            FadeOutCanvas();
            FadeOutAudio();
        }

        /// <summary>
        /// Fade in audio over time
        /// </summary>
        private void FadeInAudio()
        {
            StartCoroutine(FadeAudioWithDelay(_volumeSetting, audioFadeInDuration, delayBeforeAudioFadeIn));
        }

        /// <summary>
        /// Fade out audio over time
        /// </summary>
        private void FadeOutAudio()
        {
            StartCoroutine(FadeAudioWithDelay(-80.0f, audioFadeOutDuration, delayBeforeAudioFadeOut));
        }

        /// <summary>
        /// Fade in the Audio Mixer over time
        /// </summary>
        /// <returns></returns>
        private IEnumerator FadeAudioWithDelay(float targetVolume, float fadeDuration, float fadeDelay)
        {
            // Wait for the delay period
            yield return new WaitForSeconds(fadeDelay);

            float newVolume;
            float _currentVolume;
            float currTime = 0.0f;
            audioMixer.GetFloat("MasterVolume", out _currentVolume);
            while (currTime < fadeDuration)
            {
                currTime += Time.deltaTime;
                newVolume = Mathf.Lerp(_currentVolume, targetVolume, currTime / fadeDuration);
                audioMixer.SetFloat("MasterVolume", newVolume);
                yield return null;
            }
            audioMixer.SetFloat("MasterVolume", targetVolume);
            yield break;
        }

        /// <summary>
        /// Fade to black
        /// </summary>
        private void FadeOutCanvas()
        {
            StartCoroutine(FadeCanvasAsync(0.0f, 1.0f, sceneFadeOutDuration, delayBeforeScreenFadeOut, true));
        }

        /// <summary>
        /// Fade in from black
        /// </summary>
        private void FadeInCanvas()
        {
            StartCoroutine(FadeCanvasAsync(1.0f, 0.0f, sceneFadeInDuration, delayBeforeScreenFadeIn, false));
        }
        
        /// <summary>
        /// Fade the Canvcas to Black over time
        /// </summary>
        /// <returns></returns>
        private IEnumerator FadeCanvasAsync(float start, float target, float fadeDuration, float fadeDelay, bool endCanvasState)
        {
            // Wait for the delay period
            yield return new WaitForSeconds(fadeDelay);

            float timeElapsed = 0;
            float alphaValue;

            while (timeElapsed < fadeDuration)
            {
                alphaValue = Mathf.Lerp(start, target, timeElapsed / fadeDuration);
                _fadeCanvasGroup.alpha = alphaValue;
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            _fadeCanvasGroup.alpha = target;
            _fadeCanvasGameObject.SetActive(endCanvasState);
            _isFading = false;
        }
    }
}