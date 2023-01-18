using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DaftAppleGames.Common.Ui
{
    public class UiController : MonoBehaviour
    {

        [Header("UI Settings")]
        public GameObject uiPanel;
        public bool startWithUiOpen = false;
        public GameObject startSelectedGameObject;

        public bool isUiOpen = false;

        /// <summary>
        /// Init the UI
        /// </summary>
        public virtual void Start()
        {
            // Start with UI in specified state
            SetUiState(startWithUiOpen);
        }

        /// <summary>
        /// Display the options UI
        /// </summary>
        public virtual void ShowUi()
        {
            uiPanel.SetActive(true);
            isUiOpen = true;
            EventSystem.current.SetSelectedGameObject(startSelectedGameObject);
        }

        /// <summary>
        /// Hide the options UI
        /// </summary>
        public virtual void HideUi()
        {
            uiPanel.SetActive(false);
            isUiOpen = false;
        }

        /// <summary>
        /// Sets the appropriate UI state
        /// </summary>
        /// <param name="state"></param>
        private void SetUiState(bool state)
        {
            uiPanel.SetActive(state);
        }
    }
}