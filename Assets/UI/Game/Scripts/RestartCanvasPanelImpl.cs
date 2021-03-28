using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartCanvasPanelImpl : MonoBehaviour, RestartCanvasPanel
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Button backToMenuGameButton;
    private Action onButtonClick;
    private Action onBackToMenuButtonClick;

    public void Init()
    {
        restartGameButton.onClick.AddListener(() =>
        {
            onButtonClick.Invoke();
            Destroy(gameObject);
        });
        
        exitGameButton.onClick.AddListener(Application.Quit);

        backToMenuGameButton.onClick.AddListener(() =>
        {
            onBackToMenuButtonClick.Invoke();
        });
    }

    public void OnButtonClick(Action onButtonClick)
    {
        this.onButtonClick = onButtonClick;
    }

    public void OnBackToMenuButtonClick(Action onBackToMenuButtonClick)
    {
        this.onBackToMenuButtonClick = onBackToMenuButtonClick;
    }
}