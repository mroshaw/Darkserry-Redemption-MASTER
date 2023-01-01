using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Audio
{

    public class BackgroundMusicPlayer : MonoBehaviour
    {
        [Header("Audio Config")]
        public AudioClip backgroundMusicClip;

        [Header("Behaviour")]
        public bool playOnStart = true;

        private AudioSource _audioSource;

        // Start is called before the first frame update
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = backgroundMusicClip;

            if (playOnStart)
            {
                _audioSource.Play();
            }
        }
    }
}