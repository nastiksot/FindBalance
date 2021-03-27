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

    public void Start()
    {
        Init();
    }

    void Init()
    {
        GameObject gamePanelObject;
        GameObject startGameCanvasObject;
        GameObject restartGameCanvasObject; 
        GameObject stopWatchObjects;
        
        gamePanelObject = Instantiate(gamePanelPrefab, transform);
        gamePanel = gamePanelObject.GetComponent<GamePanelImpl>();
        gamePanel.Init();

        startGameCanvasObject = Instantiate(startGameCanvasPrefab, transform);
        startCanvasPanel = startGameCanvasObject.GetComponentInParent<StartCanvasPanelImpl>();
        startCanvasPanel.Init();

        stopWatchObjects = Instantiate(stopWatchPrefab, transform);
        stopWatch = stopWatchObjects.GetComponentInChildren<StopWatchImpl>();

        restartGameCanvasObject = Instantiate(restartGameCanvasPrefab, transform);
        restartCanvasPanel = restartGameCanvasObject.GetComponent<RestartCanvasPanelImpl>();
        restartCanvasPanel.Init();
        restartGameCanvasObject.SetActive(false);

        startCanvasPanel.OnButtonClick(() =>
        {
            gamePanel.SetJoystickCondition(true);
            stopWatch.BeginTimer();
        });

        gamePanel.OnBallFallDown(() =>
        {
            gamePanel.SetJoystickCondition(false);
            restartGameCanvasObject.SetActive(true);
            stopWatch.ResetTimer();
        });

        restartCanvasPanel.OnButtonClick(() =>
        {
            gamePanel.SetJoystickCondition(true);
            
            Init();  
            Destroy(gamePanelObject);
            Destroy(startGameCanvasObject);
            Destroy(restartGameCanvasObject); 
            Destroy(stopWatchObjects);
        });
    }
}