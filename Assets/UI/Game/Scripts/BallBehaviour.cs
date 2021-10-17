using System;
using UnityEngine;

namespace UI.Game.Scripts
{
    public class BallBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody ballRigidbody;
        private Action onBallFall;
        public event Action OnBallFall
        {
            add => onBallFall += value;
            remove => onBallFall -= value;
        }

        private void Update()
        {
            if (!(gameObject.transform.position.y < -20)) return;
            onBallFall?.Invoke(); 
        }

        /// <summary>
        /// Reset ball rigidbody
        /// </summary>
        public void ResetBallRigidbody()
        {
            ballRigidbody.velocity = Vector3.zero;
        }
    }
}