using System;
using System.Collections;
using UnityEngine;

namespace UI.Game.Scripts.Extensions
{
    public static class CanvasTool
    {
        /// <summary>
        /// Changing CanvasGroup state between visible and not visible
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="isVisible"></param>
        public static void State(ref CanvasGroup canvas, bool isVisible)
        {
            canvas.alpha = isVisible ? 1 : 0;
            canvas.interactable = isVisible;
            canvas.blocksRaycasts = isVisible;
        }

        /// <summary>
        /// Changing CanvasGroup state between visible and not visible
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="canvas"></param>
        /// <param name="isVisible"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerator State(CanvasGroup canvas, bool isVisible, float delay,
            Action<CanvasGroup> action = null)
        {
            canvas.alpha = isVisible ? 1 : 0;
            canvas.blocksRaycasts = isVisible;
            yield return new WaitForSeconds(delay);
            canvas.interactable = isVisible;
            action?.Invoke(canvas);
        }

        /// <summary>
        /// Changing CanvasGroup state between intractable and not intractable, and setting alpha
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="isVisible"></param>
        /// <param name="alpha"></param>
        public static void State(ref CanvasGroup canvas, bool isVisible, float alpha)
        {
            canvas.alpha = alpha;
            canvas.interactable = isVisible;
            canvas.blocksRaycasts = isVisible;
        }
    }
}