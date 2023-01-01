using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class CapsuleColliderAutoEditor : BaseAutoEditor
    {
        [MenuItem("Window/Buildings/Capsule Collider Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(CapsuleColliderAutoEditor));
        }

        /// <summary>
        /// Override base class to apply Editor specific Configuration
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Processing: {gameObject.name}";
            AddCapsuleCollider(gameObject);
        }

        /// <summary>
        /// Add missing colliders
        /// </summary>
        private void AddCapsuleCollider(GameObject gameObject)
        {
            if (!gameObject.GetComponent<CapsuleCollider>())
            {
                Debug.Log($"Adding Collider to: {gameObject.name}");
                if (!reportOnly)
                {
                    gameObject.AddComponent<CapsuleCollider>();
                }
                Debug.Log($"Added Collider to: {gameObject.name}");
            }
        }
    }
}
