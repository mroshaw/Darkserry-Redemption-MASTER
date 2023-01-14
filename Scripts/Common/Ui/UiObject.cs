using UnityEngine;
using UnityEngine.EventSystems;

namespace DaftAppleGames.Common.UI
{
    public class UiObject : MonoBehaviour, ISelectHandler, IDeselectHandler, ICancelHandler
    {
        public GameObject selectFrame;

        /// <summary>
        /// Enable UI object frame when selected
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSelect(BaseEventData eventData)
        {
            if(selectFrame != null)
            {
                selectFrame.SetActive(true);
            }
        }

        /// <summary>
        /// Disable UI object frame when deselected
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDeselect(BaseEventData eventData)
        {
            if (selectFrame != null)
            {
                selectFrame.SetActive(false);
            }
        }

        /// <summary>
        /// Disable UI object frame when canelled
        /// </summary>
        /// <param name="eventData"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void OnCancel(BaseEventData eventData)
        {
            if (selectFrame != null)
            {
                selectFrame.SetActive(false);
            }
        }

        /// <summary>
        /// Disable UI object frame if disabled
        /// </summary>
        public void OnDisable()
        {
            if (selectFrame != null)
            {
                selectFrame.SetActive(false);
            }
        }
    }
}