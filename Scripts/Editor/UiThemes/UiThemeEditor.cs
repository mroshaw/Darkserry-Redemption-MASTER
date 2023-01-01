using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;

namespace DaftAppleGames.Editor.UiThemes
{
    public class UiThemeEditor : OdinEditorWindow
    {
        [SerializeField]
        public UiThemeEditorSettings themeSettings;

        public bool reportOnly = false;

        [Multiline(10)]
        [PropertyOrder(2)]
        [Tooltip("Summary reporting data will be shown here. Refer to the console for more detailed output.")]
        public string outputArea = "";

        [MenuItem("Window/UI Config/Apply UI Theme")]
        public static void ShowWindow()
        {
            GetWindow(typeof(UiThemeEditor));
        }

        /// <summary>
        /// Configure button
        /// </summary>
        [Button("Configure")]
        [Tooltip("Run the editor configuration process.")]
        private void ConfigureClick()
        {
            if (!themeSettings)
            {
                Debug.LogError("Please load a theme settings file!");
                return;
            }
            ApplyTheme();
        }

        /// <summary>
        /// Apply the selected Theme scriptable object
        /// to all Themeable UI
        /// </summary>
        private void ApplyTheme()
        {
            int count = 0;

            // Find all Themable UI elements
            Button[] allButtons = Resources.FindObjectsOfTypeAll(typeof(Button)) as Button[];
            ColorBlock newButtonColourBlock = new ColorBlock
            {
                normalColor = themeSettings.buttonNormalColour,
                selectedColor = themeSettings.buttonSelectedColour,
                disabledColor = themeSettings.buttonDisabledColour,
                pressedColor = themeSettings.buttonPressedColour,
                highlightedColor = themeSettings.buttonHighlightedColour,
                colorMultiplier = themeSettings.buttonColourMultiplier,
                fadeDuration = themeSettings.buttonFadeDuration
            };

            // Iterate over buttons
            foreach (Button currentButton in allButtons)
            {
                GameObject buttonGameObject = currentButton.gameObject;

                if (!reportOnly)
                {
                    currentButton.colors = newButtonColourBlock;
                    currentButton.GetComponent<Image>().sprite = themeSettings.buttonSourceImage;
                    TextMeshProUGUI buttonText = buttonGameObject.GetComponentInChildren<TextMeshProUGUI>();
                    buttonText.font = themeSettings.buttonFont;
                    buttonText.fontSize = themeSettings.buttonFontSize;
                    buttonText.color = themeSettings.buttonFontColour;
                }
                outputArea += $"\nButton {buttonGameObject.name} processed: ";
            }

            count++;
            outputArea += $"\n{count} processed.";
        }
    }
}