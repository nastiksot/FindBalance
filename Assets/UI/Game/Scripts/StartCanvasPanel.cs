using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Scripts
{
    public class StartCanvasPanel : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button changeSkinButton;

        private string SKIN_VERSION = "skin";
        private Action onGameStarted;
        private Action onChangeSkin;

        public event Action OnGameStarted
        {
            add => onGameStarted += value;
            remove => onGameStarted -= value;
        }

        public event Action OnChangeSkin
        {
            add => onChangeSkin += value;
            remove => onChangeSkin -= value;
        }

        public void Start()
        {
            startGameButton.onClick.AddListener(() =>
            {
                onGameStarted?.Invoke();
                Destroy(gameObject);
            });

            changeSkinButton.onClick.AddListener(() => { onChangeSkin?.Invoke(); });
        }

        /// <summary>
        /// Get active game platform prefab
        /// </summary>
        /// <param name="action"></param>
        public void GetGamePrefabStatus(Action<bool> action)
        {
            action.Invoke(PlayerPrefs.GetInt(SKIN_VERSION, 0) != 0);
        }

        /// <summary>
        /// Set active game platform prefab
        /// </summary>
        /// <param name="status"></param>
        public void SetGamePrefabStatus(bool status)
        {
            PlayerPrefs.SetInt(SKIN_VERSION, !status ? 0 : 1);
        }

        /// <summary>
        /// Destroy start canvas panel
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}