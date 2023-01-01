using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Linq;
using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor
{
    public class BaseAutoEditor : OdinEditorWindow
    {
        [Header("Object Identifier")]
        [Tooltip("Add strings to uniquely identify Game Objects to effect")]
        public string[] objectNameStrings;

        [Header("Configuration")]
        [Tooltip("Choose a root GameObject from the hierarchy. If left blank, the whole scene will be used.")]
        public GameObject rootGameObject;

        [Header("Reporting")]
        [Tooltip("Check this to only report the number of impacted objects, and log details to the console.")]
        public bool reportOnly = false;
        [SerializeField]
        private int updatedCount;

        [Multiline(10)]
        [PropertyOrder(2)]
        [Tooltip("Summary reporting data will be shown here. Refer to the console for more detailed output.")]
        public string outputArea = "";

        /// <summary>
        /// Configure button
        /// </summary>
        [Button("Configure")]
        [Tooltip("Run the editor configuration process.")]
        private void ConfigureClick()
        {
            if (string.IsNullOrEmpty(editorSettingsName))
            {
                Debug.LogError("Please load a config file!");
                return;
            }
            RunEditorConfiguration();
        }

        [Header("Settings")]
        [PropertyOrder(1)]
        public BaseAutoEditorSettings autoEditorSettings;
        [PropertyOrder(1)]
        public string editorSettingsName;

        /// <summary>
        /// Load Config button
        /// </summary>
        [Button("Load Settings")]
        [PropertyOrder(1)]
        private void LoadSettingsClick()
        {
            LoadSettings();
        }

        /// <summary>
        /// Load the default settings. Should be overridden in the parent class.
        /// </summary>
        public virtual void LoadSettings()
        {
            // Update config settings
            editorSettingsName = autoEditorSettings.settingsName;

            // Update object identifiers
            objectNameStrings = autoEditorSettings.objectNameStrings;
        }

        /// <summary>
        /// Runs the configuration. Should be overridden in the parent class.
        /// </summary>
        private void RunEditorConfiguration()
        {
            // Query all MeshFilter objects
            outputArea += $"Applying configuration {editorSettingsName}..\n";

            MeshFilter[] objects;

            if (!rootGameObject)
            {
                objects = FindObjectsOfType<MeshFilter>();
            }
            else
            {
                objects = rootGameObject.GetComponentsInChildren<MeshFilter>(true);
            }
            GameObject currentGameObject;
            string currentGameObjectName;

            // Reset counters
            updatedCount = 0;

            foreach (MeshFilter currentMesh in objects)
            {
                Debug.Log($"{currentMesh.name}...\n");

                currentGameObject = currentMesh.gameObject;
                currentGameObjectName = currentGameObject.name.ToLower();

                if (objectNameStrings.Any(currentMesh.name.Contains))
                {
                    Debug.Log($"Found matching object: {currentMesh.name}...\n");

                    // Don't process any further if "report only"
                    if (reportOnly)
                    {
                        updatedCount++;
                        continue;
                    }

                    // Configure the main component
                    Debug.Log($"Configuring: {currentMesh.name}...\n");
                    ConfigureGameObject(currentGameObject);
                    Debug.Log($"Configured successfully: {currentMesh.name}.\n");
                    updatedCount++;
                }
            }

            outputArea += $"Done processing objects.\nObjects updated: {updatedCount}\n";
        }

        /// <summary>
        /// Configure the main component
        /// </summary>
        /// <param name="gameObject"></param>
        public virtual void ConfigureGameObject(GameObject gameObject)
        {

        }
    }
}
