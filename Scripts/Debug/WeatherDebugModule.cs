using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Debugging
{
    public class WeatherDebugModule : DebugModule
    {
        [Header("Weather Debug Module Config")]

        [Header("UI Buttons")]
        public Button rainButton;
        public Button snowButton;

        public override void Start()
        {
            base.Start();
            rainButton.onClick.AddListener(StartRain);
            snowButton.onClick.AddListener(StartSnow);
        }

        /// <summary>
        /// Toggle immortality
        /// </summary>
        public void StartRain()
        {

        }

        public void StartSnow()
        {

        }
    }

}
