using System;

public interface RestartCanvasPanel
{
    void Init();
    void OnButtonClick(Action onButtonClick);
    void OnBackToMenuButtonClick(Action onBackToMenuButtonClick);
}