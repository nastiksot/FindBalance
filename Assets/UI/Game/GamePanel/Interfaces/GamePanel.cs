using System;

public interface GamePanel
{
    void OnBallFallDown(Action onBallFallDownListener);
    void SetJoystickCondition(bool state);
    
    void Init();
}