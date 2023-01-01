using UnityEngine;

namespace DaftAppleGames.Common.Ui
{
    [CreateAssetMenu(fileName = "UiSoundSettings", menuName = "Settings/UiSound", order = 1)]
    public class UiSoundSettings : ScriptableObject
    {
        [Header("UI Sound Clips")]
        public AudioClip clickClip;
        public AudioClip bigClickClip;
        public AudioClip cancelClickClip;
    }
}