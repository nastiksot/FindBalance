using System;
using TMPro;
using UnityEngine;

namespace UI.Game.Scripts
{
    public class StopWatch : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerTextMeshObject;
 
        private float elapsedRunningTime = 0f;
        private float runningStartTime = 0f;
        private float pauseStartTime = 0f;
        private float elapsedPausedTime = 0f;
        private float totalElapsedPausedTime = 0f;
        private bool isStarted = false;
        private bool isPaused = true;

        float elapsedSeconds;
        float elapsedMinutes;
        float elapsedMilliseconds;

        float milliseconds;
        float seconds;
        float minutes;

        private void Update()
        {
            switch (isStarted)
            {
                case true:
                {
                    elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;
                    UpdateTime();
                    CalculateTime();
                    if (milliseconds.ToString().Length < 2) return;
                    timerTextMeshObject.text = (minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + milliseconds.ToString().Substring(0, 2));
                    break;
                }
                case false:
                    elapsedPausedTime = Time.time - pauseStartTime;
                    break;
            }
        }

        /// <summary>
        /// Update time
        /// </summary>
        private void UpdateTime()
        {
            elapsedMilliseconds = GetMilliseconds();
            elapsedSeconds = GetSeconds();
            elapsedMinutes = GetMinutes();
            milliseconds = elapsedMilliseconds * 1000;
        }

        /// <summary>
        /// Calculate time
        /// </summary>
        private void CalculateTime()
        {
            if (elapsedSeconds >= 60)
            {
                seconds = elapsedSeconds % 60;
            }
            else
            {
                seconds = elapsedSeconds;
            }

            if (elapsedMinutes >= 3600)
            {
                minutes = elapsedMinutes % 3600;
            }
            else
            {
                minutes = elapsedMinutes;
            }
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        public void StopTimer()
        {
            elapsedRunningTime = 0f;
            runningStartTime = 0f;
            pauseStartTime = 0f;
            elapsedPausedTime = 0f;
            totalElapsedPausedTime = 0f;
            isStarted = false;
        }

        /// <summary>
        /// Get minutes
        /// </summary>
        /// <returns></returns>
        private int GetMinutes()
        {
            return (int) (elapsedRunningTime / 60f);
        }

        /// <summary>
        /// Get seconds
        /// </summary>
        /// <returns></returns>
        private int GetSeconds()
        {
            return (int) (elapsedRunningTime);
        }

        /// <summary>
        /// Get milliseconds
        /// </summary>
        /// <returns></returns>
        private float GetMilliseconds()
        {
            return (float) (elapsedRunningTime - Math.Truncate(elapsedRunningTime));
        }

        /// <summary>
        /// Begin timer
        /// </summary>
        public void BeginTimer()
        {
            if (isStarted) return;
            runningStartTime = Time.time;
            isStarted = true;
        }
        
        /// <summary>
        /// Destroy stopWatch prefab 
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}