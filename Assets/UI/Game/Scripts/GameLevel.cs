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
                ResetPosition().SetJoystickVisibility(false);
            };
        }

        /// <summary>
        /// Cache platform and ball position on start
        /// </summary>
        private void CachePosition()
        {
            ballPosition = ballBehaviour.transform.position;
            platformPosition = platformTransform.position;
        }

        /// <summary>
        /// Reset joystick and ball position
        /// </summary>
        /// <returns></returns>
        private GameLevel ResetPosition()
        {
            joystickHolder.ResetJoystickCenter();
            ballBehaviour.ResetBallRigidbody();
            ballBehaviour.transform.position = ballPosition;
            return this;
        }

        /// <summary>
        /// Set joystick canvas visibility
        /// </summary>
        /// <param name="state"></param>
        public void SetJoystickVisibility(bool state)
        {
            var joystickCanvas = joystickHolder.JoystickCanvas;
            CanvasTool.State(ref joystickCanvas, state);
        } 
        
        /// <summary>
        /// Destroy level platform
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}