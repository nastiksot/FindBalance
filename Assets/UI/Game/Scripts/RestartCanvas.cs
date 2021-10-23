using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Scripts
{
    public class RestartCanvas : MonoBehaviour
    {
        [SerializeField] private Button restartGameButton;
        [SerializeField] private Button exitGameButton;
        [SerializeField] private Button backToMenuGameButton;

        private Action onRestart;
        private Action onBackToMenu;

        public event Action OnRestart
        {
            add => onRestart += value;
            remove => onRestart -= value;
        }

        public event Action OnBackToMenu
        {
            add => onBackToMenu += value;
            remove => onBackToMenu -= value;
        }

        public void Start()
        {
            restartGameButton.onClick.AddListener(() =>
            {
                onRestart?.Invoke();
                Destroy(gameObject);
            });

            backToMenuGameButton.onClick.AddListener(() => { onBackToMenu?.Invoke(); });

            exitGameButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR && UNITY_ANDROID
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            });
        }

        /// <summary>
        /// Destroy reset canvas
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}