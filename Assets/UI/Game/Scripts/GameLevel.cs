using System;
using UI.Game.Scripts.Extensions;
using UI.Game.Scripts.Joystick;
using UnityEngine;

namespace UI.Game.Scripts
{
    public class GameLevel : MonoBehaviour
    {
        [SerializeField] private BallBehaviour ballBehaviour;
        [SerializeField] private Transform platformTransform;
        [SerializeField] private JoystickHolder joystickHolder;
        
        private Vector3 ballPosition;
        private Vector3 platformPosition;

        public event Action OnBallFall
        {
            add => ballBehaviour.OnBallFall += value;
            remove => ballBehaviour.OnBallFall -= value;
        }

        public void Start()
        {
            CachePosition();
            SetJoystickVisibility(false);
            ballBehaviour.OnBallFall += () =>
            { 
                ResetGameLevel().SetJoystickVisibility(false);
            };
        }

        public void CachePosition()
        {
            ballPosition = ballBehaviour.transform.position;
            platformPosition = platformTransform.position;
        }

        public GameLevel ResetGameLevel()
        {
            joystickHolder.ResetJoystickCenter();
            ballBehaviour.ResetBallRigidbody();
            ballBehaviour.transform.position = ballPosition;
            return this;
        }

 
        public void SetJoystickVisibility(bool state)
        {
            var joystickCanvas = joystickHolder.JoystickCanvas;
            CanvasTool.State(ref joystickCanvas, state);
        } 
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}