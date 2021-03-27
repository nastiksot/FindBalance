using System;
using UnityEngine;

public class BallBehaviourImpl : MonoBehaviour, BallBehaviour
{
    private Action ballPositionListener;

    private void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            Destroy(this.gameObject);
            ballPositionListener.Invoke();
        }
    }


    public void OnBallFall(Action ballPositionListener)
    {
        this.ballPositionListener = ballPositionListener;
    }
}