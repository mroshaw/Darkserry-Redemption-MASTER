using UnityEngine;
using UnityEngine.EventSystems;

namespace DaftAppleGames.Ui
{
    public class UiController : MonoBehaviour
    {

        [Header("UI Configuration")]
        public GameObject uiPanel;
        public bool startWithUiOpen = false;
        public GameObject startSelectedGameObject;

        public bool isUiOpen = false;

        /// <summary>
        /// Init the UI
        /// </summary>
        public virtual void Start()
        {
            // Set the selected game object in Event System
            if(startSelectedGameObject)
            {
                EventSystem.current.firstSelectedGameObject = startSelectedGameObject;
            }

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