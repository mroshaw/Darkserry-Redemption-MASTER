using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class BoxColliderAutoEditor : BaseAutoEditor
    {
        [MenuItem("Window/Buildings/Box Collider Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(BoxColliderAutoEditor));
        }

        /// <summary>
        /// Override base class to apply Editor specific Configuration
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Processing: {gameObject.name}";
            AddBoxCollider(gameObject);
        }

        /// <summary>
        /// Add missing colliders
        /// </summary>
        private void AddBoxCollider(GameObject gameObject)
        {
            if (!gameObject.GetComponent<BoxCollider>())
            {
                Debug.Log($"Adding Collider to: {gameObject.name}");
                if (!reportOnly)
                {
                    gameObject.AddComponent<BoxCollider>();
                }
                Debug.Log($"Added Collider to: {gameObject.name}");
            }
        }
    }
}
