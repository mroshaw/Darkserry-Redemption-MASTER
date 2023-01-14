using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DaftAppleGames.Debugging
{
    public class DebugModule : MonoBehaviour, IDebugModule
    {
        [Header("Debug Module Config")]
        public string moduleName;
        public GameObject uiGameObject;

        private bool _uiIsOpen;
        private DebugManager _debugManager;

        /// <summary>
        /// 
        /// </summary>
        public virtual void Start()
        {
            // Hide the UI
            _uiIsOpen = false;
            uiGameObject.SetActive(false);

            // Find the debug manager and register
            _debugManager = gameObject.GetComponentInParent<DebugManager>();
            if (!_debugManager)
            {
                Debug.LogError("Can't find DebugManager!");
                return;
            }
            Register(_debugManager);
        }

        /// <summary>
        /// Returns the module name
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string ModuleName()
        {
            return moduleName;
        }

        /// <summary>
        /// Hide the UI
        /// </summary>
        public void HideUI()
        {
            uiGameObject.SetActive(false);
        }

        /// <summary>
        /// Register with the Debug Manager
        /// </summary>
        /// <param name="debugManager"></param>
        public void Register(DebugManager debugManager)
        {
            debugManager.RegisterModule(this);
        }

        /// <summary>
        /// Show the UI
        /// </summary>
        public void ShowUI()
        {
            uiGameObject.SetActive(true);
        }

        /// <summary>
        /// Toggle the UI
        /// </summary>
        public void ToggleUI()
        {
            _uiIsOpen = !_uiIsOpen;
            uiGameObject.SetActive(_uiIsOpen);
        }


        /// <summary>
        /// Set the Invincibility button text
        /// </summary>
        public virtual void SetToggleButtonText(bool toggleState, TextMeshProUGUI label, string onLabelText, string offLabelText)
        {
            if (toggleState)
            {
                label.text = onLabelText;
            }
            else
            {
                label.text = offLabelText;
            }
        }
    }
}
