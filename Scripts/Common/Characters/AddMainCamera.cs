#if INVECTOR_SHOOTER
using DaftAppleGames.Common.GameControllers;
using Invector.vCamera;
using UnityEngine;

namespace DaftAppleGames.Common.Characters
{



    public class AddMainCamera : MonoBehaviour
    {

        private vThirdPersonCamera vCamera;
        /// <summary>
        /// Add the Main Camera game object as a child
        /// </summary>
        private void Start()
        {
            GameObject cameraGameObject = GameController.GetMainCameraGameObject();
            if (!cameraGameObject)
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

            cameraGameObject.transform.SetParent(transform, false);
            cameraGameObject.transform.localPosition = new Vector3(0, 0, 0);
            cameraGameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

    }
}
#endif