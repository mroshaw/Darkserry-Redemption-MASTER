using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DaftAppleGames.MainMenu
{


    public class RotateCameraAroundObject : MonoBehaviour
    {
        [Header("Settings")]
        public Transform targetTransform;
        public float rotateSpeed = 1.0f;
        public float cameraDistance = 2.0f;
        public float cameraHeight = 1.0f;

        private Camera _camera;

        /// <summary>
        /// Initiatlise the Camera
        /// </summary>
        private void Start()
        {
            _camera = GetComponent<Camera>();
            if(!_camera)
            {
                Debug.LogError("RotateCameraAroundObject: No Camera! Check your GameObject!");
            }
            AlignCamera();
        }

        // Update is called once per frame
        void Update()
        {
            AlignAndRotate();
        }

        /// <summary>
        /// Rotates the camera and re-aligns to look at the model transform
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="charModel"></param>
        private void AlignAndRotate()
        {
            _camera.transform.Translate(Vector3.right * Time.deltaTime);
            _camera.transform.LookAt(targetTransform);
        }

        /// <summary>
        /// Aligns our cameras for Character Selection screen
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="charModel"></param>
        private void AlignCamera()
        {
            _camera.transform.position = targetTransform.position + (Vector3.back * cameraDistance) + (Vector3.up * cameraHeight);
            _camera.transform.LookAt(targetTransform);
        }

    }
}