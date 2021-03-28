using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerImpl : MonoBehaviour
{
    [SerializeField] private GameObject gamePanelPrefab;
    [SerializeField] private GameObject startGameCanvasPrefab;
    [SerializeField] private GameObject restartGameCanvasPrefab;
    [SerializeField] private GameObject stopWatchPrefab;
  
    private RestartCanvasPanel restartCanvasPanel;
    private StartCanvasPanel startCanvasPanel;
    private GamePanel gamePanel;
    private StopWatch stopWatch;
    private bool isRestart;

    public void Start()
    {
        Init(); 
    }

    void Init()
    {
        Time.timeScale = 0;
        GameObject gamePanelObject;
        GameObject restartGameCanvasObject;
        GameObject stopWatchObjects;
        GameObject startGameCanvasObject;
        gamePanelObject = Instantiate(gamePanelPrefab, transform);
        gamePanel = gamePanelObject.GetComponent<GamePanelImpl>();
        gamePanel.Init();
        
        stopWatchObjects = Instantiate(stopWatchPrefab, transform);
        stopWatch = stopWatchObjects.GetComponentInChildren<StopWatchImpl>();
        
        if (!isRestart)
        {
            startGameCanvasObject = Instantiate(startGameCanvasPrefab, transform);
            startCanvasPanel = startGameCanvasObject.GetComponentInParent<StartCanvasPanelImpl>();
            startCanvasPanel.Init();
            startCanvasPanel.OnButtonClick(() =>
            {
                Time.timeScale = 1;
                Destroy(startGameCanvasObject);
                gamePanel.SetJoystickCondition(true);
                stopWatch.BeginTimer();
            });
        }
        else
        {
            Time.timeScale = 1;
            gamePanel.SetJoystickCondition(true);
            stopWatch.BeginTimer();
        } 
        
        restartGameCanvasObject = Instantiate(restartGameCanvasPrefab, transform);
        restartCanvasPanel = restartGameCanvasObject.GetComponent<RestartCanvasPanelImpl>();
        restartCanvasPanel.Init();
        restartGameCanvasObject.SetActive(false);
 
        gamePanel.OnBallFallDown(() =>
        {
            gamePanel.SetJoystickCondition(false);
            restartGameCanvasObject.SetActive(true);
            stopWatch.ResetTimer();
        });

        restartCanvasPanel.OnButtonClick(() =>
        {
            isRestart = true;
            Init();
            Destroy(gamePanelObject); 
            Destroy(restartGameCanvasObject);
            Destroy(stopWatchObjects);
        });
    }
}