using System;

public interface GamePanel
{
    void OnBallFallDown(Action onBallFallDownListener);
    void Init();
}