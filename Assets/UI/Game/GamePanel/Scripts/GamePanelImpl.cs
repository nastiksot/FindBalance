using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelImpl : MonoBehaviour, GamePanel
{
    [SerializeField] private GameObject joystickObject; 
    [SerializeField] private GameObject ballObject;
    [SerializeField] private GameObject platformObject;
    
    private PlatformControllerImpl platformController;
    private BallBehaviour ballBehaviour;
    private Action onBallFallDownListener;

    public void Init()
    { 
        platformController = platformObject.GetComponent<PlatformControllerImpl>();
        ballBehaviour = ballObject.GetComponent<BallBehaviourImpl>();
        ballBehaviour.OnBallFall(() =>
        {
            onBallFallDownListener.Invoke();
        });
    }

    public void SetStartCondition()
    {
        platformController.SetStartCondition(true);
    }

    public void OnBallFallDown(Action onBallFallDownListener)
    {
        this.onBallFallDownListener = onBallFallDownListener;
    }

}