using UnityEngine;

public class PlatformControllerImpl : MonoBehaviour
{
    [SerializeField] private JoystickController joystickController;
    private const float abstractSpeed = 0.05f;

    void Update()
    {
        Vector3 qa = new Vector3();
        qa.x = joystickController.Vertical * abstractSpeed;
        qa.y = joystickController.Horizontal * abstractSpeed;
        Quaternion translate = new Quaternion(qa.x, 0, qa.y, 1f);
        transform.rotation = translate;
    }
}