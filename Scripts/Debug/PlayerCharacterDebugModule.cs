#if INVECTOR_SHOOTER
using Invector.vCharacterController;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Debugging
{
    public class PlayerCharacterDebugModule : DebugModule
    {
        [Header("Player Debug Module Config")]
        public string playerName;

        [Header("UI Buttons")]
        public Button toggleInvincibilityButton;

        private vThirdPersonController _playerController;
        private bool _isInvincible;
        private TextMeshProUGUI _isInvincibleLabel;
        private const string _invincibilityOn = "Invinsibility (ON)";
        private const string _invincibilityOff = "Invinsibility (OFF)";

        public override void Start()
        {
            base.Start();
            _playerController = FindObjectOfType<vThirdPersonController>();
            if(!_playerController)
            {
                return;
            }
            _isInvincible = false;
            _isInvincibleLabel = toggleInvincibilityButton.GetComponentInChildren<TextMeshProUGUI>();
            SetToggleButtonText(_isInvincible, _isInvincibleLabel, _invincibilityOn, _invincibilityOff);
            toggleInvincibilityButton.onClick.AddListener(ToggleIsInvincible);
        }

        /// <summary>
        /// Toggle immortality
        /// </summary>
        public void ToggleIsInvincible()
        {
            _isInvincible = !_isInvincible;
            SetToggleButtonText(_isInvincible, _isInvincibleLabel, _invincibilityOn, _invincibilityOff);
            _playerController.isImmortal = _isInvincible;
        }
    }

}
#endif