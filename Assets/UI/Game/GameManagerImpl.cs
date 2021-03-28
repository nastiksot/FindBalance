using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerImpl : MonoBehaviour
{
    [SerializeField] private GameObject gamePanelPrefab;
    [SerializeField] private GameObject gameTennisPanelPrefab;
    [SerializeField] private GameObject startGameCanvasPrefab;
    [SerializeField] private GameObject restartGameCanvasPrefab;
    [SerializeField] private GameObject stopWatchPrefab;

    private RestartCanvasPanel restartCanvasPanel;
    private StartCanvasPanel startCanvasPanel;
    private GamePanel gamePanel;
    private StopWatch stopWatch;
    private bool isRestart;
    private bool newStatus;

    public void Start()
    {
        Init();
    }

    void Init()
    {
        Time.timeScale = 0;

        GameObject gamePanelObject = null;
        GameObject restartGameCanvasObject = null;
        GameObject stopWatchObjects = null;
        GameObject startGameCanvasObject = null;

        stopWatchObjects = Instantiate(stopWatchPrefab, transform);
        stopWatch = stopWatchObjects.GetComponentInChildren<StopWatchImpl>();

        if (!isRestart)
        {
            startGameCanvasObject = Instantiate(startGameCanvasPrefab, transform);
            startCanvasPanel = startGameCanvasObject.GetComponentInParent<StartCanvasPanelImpl>();
            startCanvasPanel.Init();
            startCanvasPanel.OnButtonClick(RunGame);
        }
        else
        {
            RunGame();
        }

        startCanvasPanel.OnChangeSkin(() =>
        {
            startCanvasPanel.GetGamePrefabStatus(status =>
            {
                bool changeStatus = !status;
                newStatus = changeStatus;
                startCanvasPanel.SetGamePrefabStatus(changeStatus);
                Init();
                DestroyAll(startGameCanvasObject, gamePanelObject, restartGameCanvasObject, stopWatchObjects);
            });
        });

        gamePanelObject = Instantiate(newStatus ? gamePanelPrefab : gameTennisPanelPrefab, transform);
        gamePanel = gamePanelObject.GetComponent<GamePanelImpl>();
        gamePanel.Init();

        restartGameCanvasObject = Instantiate(restartGameCanvasPrefab, transform);
        restartCanvasPanel = restartGameCanvasObject.GetComponent<RestartCanvasPanelImpl>();
        restartCanvasPanel.Init();
        restartGameCanvasObject.SetActive(false);

        gamePanel.OnBallFallDown(() =>
        {
            restartGameCanvasObject.SetActive(true);
            stopWatch.StopTimer();
        });

        restartCanvasPanel.OnBackToMenuButtonClick(() =>
        {
            isRestart = false;
            Init();
            DestroyAll(startGameCanvasObject, gamePanelObject, restartGameCanvasObject, stopWatchObjects);
        });

        restartCanvasPanel.OnButtonClick(() =>
        {
            isRestart = true;
            Init();
            DestroyAll(startGameCanvasObject, gamePanelObject, restartGameCanvasObject, stopWatchObjects);
        });
    }

    private void RunGame()
    {
        Time.timeScale = 1;
        stopWatch.BeginTimer();
    }

    private static void DestroyAll(GameObject startGameCanvasObject, GameObject gamePanelObject, GameObject restartGameCanvasObject, GameObject stopWatchObjects)
    {
        Destroy(startGameCanvasObject);
        Destroy(gamePanelObject);
        Destroy(restartGameCanvasObject);
        Destroy(stopWatchObjects);
    }
}