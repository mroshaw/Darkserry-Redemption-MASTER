using DafeAppleGames.UI;
using DaftAppleGames.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DaftAppleGames.GameControllers
{
    public enum CharSelection { Callum, Emily }

    public class GameController : MonoBehaviour
    {
        [Header("Character Settings")]
        [SerializeField]
        private CharSelection _selectedCharacter = CharSelection.Emily;

        [Header("Scene Settings")]
        public static string mainMenuScene = "MainMenuScene";
        public static string mainGameScene = "GameWorldScene";
        public static string loadingScene = "LoadingScene";
        public static string gameCompleteScene = "GameCompleteScene";

        [Header("Camera")]
        [SerializeField]
        private static GameObject _mainCameraGameObject;

        [Header("Scene Fader")]
        private static SceneFader _sceneFader;

        public CharSelection SelectedCharacter { get => _selectedCharacter; set => _selectedCharacter = value; }

        private static GameController _instance;
        public static GameController Instance { get { return _instance; } }

        /// <summary>
        /// Initialise the GameController Singleton instance
        /// </summary>
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            SetCameraGameObject();
            SetSceneFader();
        }

        /// <summary>
        /// Static method to load the Main Menu
        /// </summary>
        public static void LoadMainMenuScene()
        {
            LoadSceneWithFadeOut(mainMenuScene);
        }

        /// <summary>
        /// Static method to load the Main Game
        /// </summary>
        public static void LoadMainGameScene()
        {
            LoadSceneWithFadeOut(mainGameScene);
        }

        /// <summary>
        /// Static methods to load the Game Complete
        /// </summary>
        public static void LoadGameCompleteScene()
        {
            LoadSceneWithFadeOut(gameCompleteScene);
        }

        /// <summary>
        /// Set the Scene Fader component
        /// </summary>
        private static void SetSceneFader()
        {
            _sceneFader = _instance.GetComponentInChildren<SceneFader>();
        }

        /// <summary>
        /// Looks for and sets the Main Camera.
        /// </summary>
        private static void SetCameraGameObject()
        {
            _mainCameraGameObject = GameUtils.FindMainCameraGameObject();
        }

        public static void LoadSceneWithFadeOut(string sceneName)
        {
            _instance.StartCoroutine(LoadSceneWithFadeOutAsync(sceneName));
        }

        private static IEnumerator LoadSceneWithFadeOutAsync(string sceneName)
        {
            _sceneFader.FadeOut();
            while(_sceneFader.IsFading)
            {
                yield return null;
            }
            LoadSceneWithLoadingScreen(sceneName);
        }

        public static void FadeOut()
        {
            _sceneFader.FadeOut();
        }

        /// <summary>
        /// Returns the Main Camera Game Object
        /// </summary>
        /// <returns></returns>
        public static GameObject GetMainCameraGameObject()
        {
            if(!_mainCameraGameObject)
            {
                SetCameraGameObject();
            }
            return _mainCameraGameObject;
        }

        /// <summary>
        /// Load the given scene with the loading scene
        /// </summary>
        /// <param name="sceneName"></param>
        public static void LoadSceneWithLoadingScreen(string sceneName)
        {
            LoadingData.SceneNameToLoad = sceneName;
            SceneManager.LoadScene(loadingScene);
        }
    }
}