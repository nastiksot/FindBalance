using System;

public interface GamePanel
{
    void OnBallFallDown(Action onBallFallDownListener);
    void SetStartCondition();
    void Init();
}