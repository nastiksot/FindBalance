using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerImpl : MonoBehaviour
{
    [SerializeField] private GameObject gamePanelObject;
    [SerializeField] private GameObject startGameCanvasObject;
    [SerializeField] private GameObject restartGameCanvasObject;
    [SerializeField] private GameObject restartSetActive;
    [SerializeField] private GameObject stopWatchObjects;

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
        gamePanel = gamePanelObject.GetComponent<GamePanelImpl>();
        gamePanel.Init();
        
        startCanvasPanel = startGameCanvasObject.GetComponentInParent<StartCanvasPanelImpl>();
        startCanvasPanel.Init();
         
        restartCanvasPanel = restartGameCanvasObject.GetComponent<RestartCanvasPanelImpl>();
        restartCanvasPanel.Init(); 
       
        stopWatch = stopWatchObjects.GetComponent<StopWatchImpl>();

        startCanvasPanel.OnButtonClick(() =>
        {
            gamePanel.SetStartCondition();
            stopWatch.BeginTimer();
        });

        restartCanvasPanel.OnButtonClick(() =>
        {
            
        });
        
        gamePanel.OnBallFallDown(() =>
        {
            restartSetActive.SetActive(true);
            stopWatch.ResetTimer();
        });
      
    }
}