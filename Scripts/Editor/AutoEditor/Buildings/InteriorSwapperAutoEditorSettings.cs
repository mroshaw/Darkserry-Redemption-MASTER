using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    /// <summary>
    /// Scriptable Object to store Editor usable instances of the Player Character Configuration
    /// </summary>
    [CreateAssetMenu(fileName = "InteriorSwapperAutoEditorSettings", menuName = "Settings/Buildings/InteriorSwapperAutoEditor", order = 1)]
    public class InteriorSwapperEditorSettings : BaseAutoEditorSettings
    {
        [Header("Interior Swapper Editor Settings")]
        public string[] sourceMaterials;
        public string[] targetMaterials;
    }
}