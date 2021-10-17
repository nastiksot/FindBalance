using Plugins.JoystickUtils.Core;
using UnityEngine;

namespace UI.Game.Scripts
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private JoystickController joystickController;
        private const float abstractSpeed = 0.05f;

        private void Update()
        { 
            var qa = new Vector3
            {
                x = joystickController.Vertical * abstractSpeed, 
                y = joystickController.Horizontal * abstractSpeed
            };
            var translate = new Quaternion(qa.x, 0, qa.y, 1f);
            transform.rotation = translate;
        }
    }
}