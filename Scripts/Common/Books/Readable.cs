#if ASMDEF
#if BOOK
using DaftAppleGames.Common.GameControllers;
using echo17.EndlessBook;
using Invector.vCamera;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.Common.Books
{
    public class Readable : MonoBehaviour
    {
        [Header("Settings")]
        public GameObject actionTextGameObject;
        public string playerLayer;
        public string playerTag;
        public BookController bookController;

        [Header("Action Settings")]
        public KeyCode actionKey = KeyCode.E;

        [Header("Events")]
        public UnityEvent OnEnterTriggerArea;
        public UnityEvent OnExitTriggerArea;

        private GameObject _bookControllerGameObject;
        private GameObject _cameraGameObject;
        private vThirdPersonCamera _vCamera;
        private vThirdPersonInput _vThirdPersonInput;

        private bool _isShown;

        private StateChangedDelegate onStateCompleted;

        // Start is called before the first frame update
        private void Awake()
        {
            _bookControllerGameObject = bookController.gameObject;
            _bookControllerGameObject.SetActive(false);
            actionTextGameObject.SetActive(false);
            _isShown = false;

            _cameraGameObject = GameController.GetMainCameraGameObject();
            GameObject vCameraGameObject = GameController.GetInvectorCameraGameObject();
            if(vCameraGameObject)
            {
                _vCamera = vCameraGameObject.GetComponent<vThirdPersonCamera>();
            }

            GameObject playerGameObject = GameController.GetPlayerGameObject();
            if(playerGameObject)
            {
                _vThirdPersonInput = playerGameObject.GetComponent<vThirdPersonInput>();
            }

            onStateCompleted = HideBookGameObjectDelegate;
        }

        /// <summary>
        /// Brings the interactive book up to the camera
        /// </summary>
        public void ShowBook()
        {
            if(!_vCamera)
            {
                _vCamera = GameController.GetInvectorCameraGameObject().GetComponent<vThirdPersonCamera>();
            }

            if(!_vThirdPersonInput)
            {
                _vThirdPersonInput = GameController.GetPlayerGameObject().GetComponent<vThirdPersonInput>();
            }

            _vCamera.FreezeCamera();
            _vThirdPersonInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _bookControllerGameObject.SetActive(true);
            bookController.MoveBookToCamera();
            _isShown = true;
        }

        /// <summary>
        /// Hides the interactive book
        /// </summary>
        public void HideBook()
        {
            bookController.ResetBook(onStateCompleted);
        }

        /// <summary>
        /// Hides the book
        /// </summary>
        private void HideBookGameObjectDelegate(EndlessBook.StateEnum fromState, EndlessBook.StateEnum toState, int pageNumber)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _vCamera.UnFreezeCamera();

            _vThirdPersonInput.enabled = true;
            _isShown = false;
            _bookControllerGameObject.SetActive(false);
        }

        /// <summary>
        /// Handle action text when player walks into action trigger
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(playerLayer))
            {
                actionTextGameObject.SetActive(true);
                OnEnterTriggerArea.Invoke();
            }
        }

        /// <summary>
        /// Handle action text when player walks leaves action trigger
        /// </summary>
        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(playerLayer))
            {
                actionTextGameObject.SetActive(false);
                OnExitTriggerArea.Invoke();
            }
        }

        /// <summary>
        /// Handle action key press while in action trigger
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(playerLayer))
            {
                if(Input.GetKeyDown(actionKey))
                {
                    if(_isShown)
                    {
                        HideBook();
                    }
                    else
                    {
                        ShowBook();
                    }
                }
            }
        }
    }
}
#endif
#endif