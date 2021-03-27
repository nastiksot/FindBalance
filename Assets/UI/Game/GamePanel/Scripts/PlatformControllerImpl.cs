using UnityEngine;

public class PlatformControllerImpl : MonoBehaviour
{
    [SerializeField] private JoystickController joystickController;
    private const float abstractSpeed = 0.1f;
    private bool isStarted = false;

    void Update()
    {
        if (isStarted)
        {
            Vector3 qa = new Vector3();
            qa.x = joystickController.Vertical * abstractSpeed;
            qa.y = joystickController.Horizontal * abstractSpeed;
            Quaternion translate = new Quaternion(qa.x, 0.0f, qa.y, 1f);
            transform.rotation = translate;
        }
    }

    public void SetStartCondition(bool condition)
    {
        isStarted = condition;
    }
}