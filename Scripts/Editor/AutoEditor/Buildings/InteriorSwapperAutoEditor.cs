using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class InteriorSwapperEditor : BaseAutoEditor
    {
        [Header("Interiror Swapper Editor Configuration")]
        public string[] sourceMaterials;
        public string[] targetMaterials;

        [MenuItem("Window/Buildings/Interior Swapper Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(InteriorSwapperEditor));
        }

        /// <summary>
        /// Load settings from Scriptable Object instance
        /// </summary>
        public override void LoadSettings()
        {
            base.LoadSettings();
            InteriorSwapperEditorSettings interiorSwapperEditorSettings = autoEditorSettings as InteriorSwapperEditorSettings;

            // Update editor specific config settings
            sourceMaterials = interiorSwapperEditorSettings.sourceMaterials;
            targetMaterials = interiorSwapperEditorSettings.targetMaterials;
        }

        /// <summary>
        /// Configure the main component
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Example processing: {gameObject.name}";
        }


        private void ReplaceParts(GameObject sourceGameObject)
        {
            /*
            // Instantiate a new target part
            GameObject newGameObject = Instantiate(targetPartsList[index]);

            // Position the target part over the source
            newGameObject.transform.position = renderer.gameObject.transform.position;
            newGameObject.transform.rotation = renderer.gameObject.transform.rotation;
            newGameObject.transform.SetParent(renderer.gameObject.transform.parent);

            // Rename, to remove the "clone" part and allow reversion
            newGameObject.name = targetPartsList[index].name;

            // Delete or disable the source
            if (destroySourceGameObjects)
            {
                DestroyImmediate(renderer.gameObject, true);
            }
            else
            {
                renderer.gameObject.SetActive(false);
            }
            */
        }

        /// <summary>
        /// Swaps the source and target parts
        /// </summary>
        public void SwapPartsLists()
        {
            /*
            for (int index = 0; index < sourcePartsList.Length; index++)
            {
                GameObject temp = sourcePartsList[index];
                sourcePartsList[index] = targetPartsList[index];
                targetPartsList[index] = temp;
            }
            */
        }
    }
}
