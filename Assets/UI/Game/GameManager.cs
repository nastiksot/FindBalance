using UI.Game.Scripts;
using UnityEngine;

namespace UI.Game
{
    public class GameManager : MonoBehaviour
    {
        [Header("Prefabs")] [SerializeField] private GameLevel gameLevelPrefab;
        [SerializeField] private GameLevel gameTennisLevelPrefab;

        [Space(3f), Header("Canvases")] [SerializeField]
        private StartCanvasPanel startGameCanvasPrefab;

        [SerializeField] private RestartCanvas restartGameCanvasPrefab;

        [Space(3f), Header("StopWatch")] [SerializeField]
        private StopWatch stopWatchPrefab;

        private StopWatch instantiatedStopWatch;
        private CanvasGroup instantiatedJoystick;
        private RestartCanvas instantiatedRestartCanvas;
        private StartCanvasPanel instantiatedStartCanvas;
        private GameLevel gameLevel;

        private bool isRestart;
        private bool newStatus;

        public void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Time.timeScale = 0;

            instantiatedStopWatch = Instantiate(stopWatchPrefab, transform);
            instantiatedStartCanvas = Instantiate(startGameCanvasPrefab, transform);
            gameLevel = Instantiate(newStatus ? gameLevelPrefab : gameTennisLevelPrefab, transform);

            instantiatedStartCanvas.OnGameStarted += StartGame;
            gameLevel.OnBallFall += StopGame;
            instantiatedStartCanvas.OnChangeSkin += OnChangeSkin;
 
        }

        private void OnChangeSkin()
        {
            instantiatedStartCanvas.GetGamePrefabStatus(status =>
            {
                DestroyOnChangeSkin(gameLevel, instantiatedStopWatch, instantiatedStartCanvas);
                var changeStatus = !status;
                newStatus = changeStatus;
                instantiatedStartCanvas.SetGamePrefabStatus(changeStatus);
                Initialize();
            });
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            instantiatedStopWatch.BeginTimer();
            gameLevel.SetJoystickVisibility(true);
        }

        private void StopGame()
        {
            Time.timeScale = 0;
            InitializeRestartCanvas();
            instantiatedStopWatch.StopTimer();
        }

        private void InitializeRestartCanvas()
        {
            instantiatedRestartCanvas = Instantiate(restartGameCanvasPrefab, transform);
            instantiatedRestartCanvas.OnRestart += StartGame;
            instantiatedRestartCanvas.OnBackToMenu += OnBackToMenu;
        }

        private void OnBackToMenu()
        {
            DestroyOnRestart(gameLevel, instantiatedStopWatch,instantiatedRestartCanvas);
            Initialize();
        }

        private void DestroyOnRestart(GameLevel gameLevelObject,  StopWatch stopWatchObjects, RestartCanvas restartGameCanvasObject)
        {
            gameLevelObject.Destroy();
            stopWatchObjects.Destroy();
            restartGameCanvasObject.Destroy();
        }

        private void DestroyOnChangeSkin(GameLevel gameLevelObject, StopWatch stopWatchObjects,StartCanvasPanel startCanvasPanel)
        {
            gameLevelObject.Destroy();
            stopWatchObjects.Destroy();
            startCanvasPanel.Destroy();
        }
    }
}