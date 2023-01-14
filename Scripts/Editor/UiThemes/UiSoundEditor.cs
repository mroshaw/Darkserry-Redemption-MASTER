using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using DaftAppleGames.Common.Ui;
using System.Linq;
using System;
using UnityEditor.Events;
using UnityEngine.Events;

namespace DaftAppleGames.Editor.UiThemes
{
    public class UiSoundEditor : OdinEditorWindow
    {
        [Header("UI Sound Settings")]
        [SerializeField]
        public UiSoundEditorSettings uiSoundSettings;

        [Header("Target UI Game Object")]
        public GameObject targetUiGameObject;

        public bool reportOnly = false;

        private UiSoundManager _soundManager;

        [Multiline(10)]
        [PropertyOrder(2)]
        [Tooltip("Summary reporting data will be shown here. Refer to the console for more detailed output.")]
        public string outputArea = "";

        [MenuItem("Window/UI Config/Apply UI Sounds")]
        public static void ShowWindow()
        {
            GetWindow(typeof(UiSoundEditor));
        }

        /// <summary>
        /// Configure button
        /// </summary>
        [Button("Configure")]
        [Tooltip("Run the editor configuration process.")]
        private void ConfigureClick()
        {
            if (!uiSoundSettings)
            {
                Debug.LogError("Please load a theme settings file!");
                return;
            }

            if(!targetUiGameObject)
            {
                Debug.LogError("Please select a root UI based Game Object to process.");
                return;
            }

            ApplyUiSounds();
        }

        /// <summary>
        /// Apply the selected Theme scriptable object
        /// to all Themeable UI
        /// </summary>
        private void ApplyUiSounds()
        {
            int count = 0;

            // Add a new Ui Sound controller to the Game Object, if required
            _soundManager = targetUiGameObject.GetComponent<UiSoundManager>();
            if(!_soundManager)
            {
                _soundManager = targetUiGameObject.AddComponent<UiSoundManager>();
            }

            // Configure Sound Manager
            _soundManager.clickClip = uiSoundSettings.clickSound;
            _soundManager.backClip = uiSoundSettings.backClickSound;
            _soundManager.cancelClip = uiSoundSettings.cancelClickSound;
            _soundManager.bigClickClip = uiSoundSettings.bigClickSound;

            // Add a new AudioSource, if required.
            AudioSource audioSource = targetUiGameObject.GetComponent<AudioSource>();
            if (!audioSource)
            {
                audioSource = targetUiGameObject.AddComponent<AudioSource>();
            }

            // Configure / reconfigure the AudioSource
            audioSource.outputAudioMixerGroup = uiSoundSettings.uiSoundAudioMixerGroup;
            audioSource.playOnAwake = false;

            // Find all Themable UI elements
            // Buttons

            Button[] allButtons = targetUiGameObject.GetComponentsInChildren<Button>(true);

            // Iterate over buttons
            foreach (Button currentButton in allButtons)
            {
                GameObject buttonGameObject = currentButton.gameObject;
                count++;

                // Match back click pattern
                if (uiSoundSettings.backButtonClickIdentifiers.Any(buttonGameObject.name.Contains))
                {
                    outputArea += $"Adding Back Clip to {buttonGameObject.name}.\n";
                    if (!reportOnly)
                    {
                        AddDelegateToButtonEvent(buttonGameObject, typeof(Button), currentButton.onClick, _soundManager.PlayBack);
                    }
                    continue;
                }

                // Match cancel pattern
                if (uiSoundSettings.cancelButtonClickIdentifiers.Any(buttonGameObject.name.Contains))
                {
                    outputArea += $"Adding Cancel Clip to {buttonGameObject.name}.\n";
                    if (!reportOnly)
                    {
                        AddDelegateToButtonEvent(buttonGameObject, typeof(Button), currentButton.onClick, _soundManager.PlayCancel);
                    }
                    continue;
                }

                // Match big click pattern
                if (uiSoundSettings.bigButtonClickIdentifiers.Any(buttonGameObject.name.Contains))
                {
                    outputArea += $"Adding Big Clip to {buttonGameObject.name}.\n";
                    if (!reportOnly)
                    {
                        AddDelegateToButtonEvent(buttonGameObject, typeof(Button), currentButton.onClick, _soundManager.PlayBig);
                    }
                    continue;
                }

                // Match remaining standard clicks
                if (uiSoundSettings.buttonClickIdentifiers.Length == 0 ||
                    uiSoundSettings.buttonClickIdentifiers.Any(buttonGameObject.name.Contains))
                {
                    outputArea += $"Adding Click Clip to {buttonGameObject.name}.\n";
                    if (!reportOnly)
                    {
                        AddDelegateToButtonEvent(buttonGameObject, typeof(Button), currentButton.onClick, _soundManager.PlayClick);
                    }
                    continue;
                }

                outputArea += $"\nButton {buttonGameObject.name} processed: ";
            }
            outputArea += $"\n{count} processed.";
        }

        /// <summary>
        /// Adds a Persistent (visible in Inspector) event listener
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <param name="delegateAction"></param>
        private void AddDelegateToButtonEvent(GameObject uiControlGameObject, Type uiControlType, UnityEvent eventHandler, Action delegateAction)
        {
            string delegateMethodName = delegateAction.Method.Name;
            var targetInfo = UnityEvent.GetValidMethodInfo(_soundManager, delegateMethodName, new Type[0]);
            UnityAction methodDelegate = Delegate.CreateDelegate(typeof(UnityAction), _soundManager, targetInfo) as UnityAction;
            UnityEventTools.RemovePersistentListener(eventHandler, methodDelegate);
            UnityEventTools.AddPersistentListener(eventHandler, methodDelegate);
            eventHandler.SetPersistentListenerState(0, UnityEventCallState.RuntimeOnly);
            EditorUtility.SetDirty(uiControlGameObject);
        }
    }
}