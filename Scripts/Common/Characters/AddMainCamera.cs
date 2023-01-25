#if ASMDEF
#if INVECTOR_SHOOTER
using DaftAppleGames.Common.GameControllers;
using Invector.vCamera;
using UnityEngine;

namespace DaftAppleGames.Common.Characters
{
    public class AddMainCamera : MonoBehaviour
    {
        private vThirdPersonCamera vCamera;
        private GameObject _mainCameraGameObject;
        /// <summary>
        /// Add the Main Camera game object as a child
        /// </summary>
        private void Start()
        {
            _mainCameraGameObject = GameController.GetMainCameraGameObject();
            if (!_mainCameraGameObject)
            {
                Debug.LogError("AddMainCamera: Can't find 'MainCamera' game object!!!");
                return;
            }

            vCamera = GetComponent<vThirdPersonCamera>();

            if (!vCamera)
            {
                Debug.LogError("AddMainCamera: Can't find 'vThirdPersonCamera' component!!!");
                return;
            }

            // Update the main camera
            UpdateMainCamera();
        }

        /// <summary>
        /// Set the Main Camera as child
        /// </summary>
        public void UpdateMainCamera()
        {
            _mainCameraGameObject.transform.SetParent(transform, false);
            _mainCameraGameObject.transform.localPosition = new Vector3(0, 0, 0);
            _mainCameraGameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
#endif
#endif