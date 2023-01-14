using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.Debugging
{
    public class DebugManager : MonoBehaviour
    {
        [Header("Debugger UI")]
        public GameObject uiGameObject;
        public GameObject debugPanel;
        public GameObject buttonTemplatePrefab;

        public KeyCode debugToggleKey = KeyCode.Keypad5;

        private bool _isUiOpen;

        [SerializeField]
        private List<DebugModuleListItem> debugModuleItems = new List<DebugModuleListItem>();

        /// <summary>
        /// Initiatlise the Debug Manager
        /// </summary>
        private void Start()
        {
            _isUiOpen = false;
            uiGameObject.SetActive(false);
        }

        /// <summary>
        /// Listen out for Debug keypress
        /// </summary>
        private void Update()
        {
            if(Input.GetKeyDown(debugToggleKey))
            {
                if(!_isUiOpen)
                {
                    _isUiOpen = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    uiGameObject.SetActive(true);
                    ShowAllModules();
                }
                else
                {
                    _isUiOpen = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    uiGameObject.SetActive(false);
                    HideAllModules();
                }             
            }
        }

        /// <summary>
        /// Show all module UIs
        /// </summary>
        private void ShowAllModules()
        {
            foreach(DebugModuleListItem moduleItem in debugModuleItems)
            {
                moduleItem.ShowUI();
            }
        }

        /// <summary>
        /// Hide all module UIs
        /// </summary>
        private void HideAllModules()
        {
            foreach (DebugModuleListItem moduleItem in debugModuleItems)
            {
                moduleItem.HideUI();
            }
        }

        /// <summary>
        /// Register a new Debug Module
        /// </summary>
        /// <param name="debugModule"></param>
        public void RegisterModule(IDebugModule debugModule)
        {
            // Add a button to the debug canvas
            GameObject newButtonGameObject = Instantiate(buttonTemplatePrefab);
            newButtonGameObject.name = debugModule.ModuleName();
            newButtonGameObject.transform.SetParent(debugPanel.transform);
            Button newButton = newButtonGameObject.GetComponent<Button>();
            TextMeshProUGUI label = newButtonGameObject.GetComponentInChildren<TextMeshProUGUI>();
            label.text = debugModule.ModuleName();
            newButton.onClick.AddListener(debugModule.ToggleUI);

            // Add a new instance to the list
            DebugModuleListItem newModuleItem = new DebugModuleListItem(debugModule, newButton);
            debugModuleItems.Add(newModuleItem);
        }

        /// <summary>
        /// Internal class to store modules and associated buttons
        /// </summary>
        private class DebugModuleListItem
        {
            private IDebugModule Module;
            private Button UiButton;

            internal DebugModuleListItem(IDebugModule module, Button uiButton)
            {
                this.Module = module;
                this.UiButton = uiButton;
            }

            public void HideUI()
            {
                Module.HideUI();
            }

            public void ShowUI()
            {
                Module.ShowUI();
            }
        }

    }
}
