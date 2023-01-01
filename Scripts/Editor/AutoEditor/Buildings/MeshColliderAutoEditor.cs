using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class MeshColliderAutoEditor : BaseAutoEditor
    {
        [MenuItem("Window/Buildings/Mesh Collider Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(MeshColliderAutoEditor));
        }

        /// <summary>
        /// Override base class to apply Editor specific Configuration
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Processing: {gameObject.name}";
            AddMeshCollider(gameObject);
        }

        /// <summary>
        /// Add missing colliders
        /// </summary>
        private void AddMeshCollider(GameObject gameObject)
        {
            if (!gameObject.GetComponent<CapsuleCollider>())
            {
                Debug.Log($"Adding Collider to: {gameObject.name}");
                if (!reportOnly)
                {
                    gameObject.AddComponent<MeshCollider>();
                }
                Debug.Log($"Added Collider to: {gameObject.name}");
            }
        }
    }
}
