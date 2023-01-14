using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.Common.UI
{
    public class UiBackButton : UiObject
    {
        [Header("UI Settings")]
        private Button _button;
        public string gamePadBack = "Cancel";

        private void Start()
        {
            _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(gamePadBack))
            {
                return;

            }
            if (Input.GetButtonDown(gamePadBack))
            {
                _button.onClick.Invoke();
            }
        }
    }
}