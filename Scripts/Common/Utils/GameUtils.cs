using UnityEngine;

namespace DaftAppleGames.Common.Utils
{
    public static class GameUtils
    {
        public static GameObject FindMainCameraGameObject()
        {
            GameObject cameraGameObject = GameObject.FindGameObjectWithTag("MainCamera");
            if (!cameraGameObject)
            {
                Debug.LogError("GameUtils.FindMainCamera: Can't find 'MainCamera' game object!");
                return null;
            }
            Camera cameraComponent = cameraGameObject.GetComponent<Camera>();
            if (!cameraComponent)
            {
                Debug.LogError("GameUtils.FindMainCamera: Can't find 'Camera' component on 'MainCamera' game object!");
                return null;
            }
            return cameraGameObject;
        }

        public static GameObject FindPlayerGameObject()
        {
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            if (!playerGameObject)
            {
                Debug.LogError("GameUtils.FindPlayerGameObject: Can't find 'Player' game object!");
                return null;
            }

            return playerGameObject;
        }
    }
}