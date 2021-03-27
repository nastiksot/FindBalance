using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartCanvasPanelImpl : MonoBehaviour, RestartCanvasPanel
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button exitGameButton;
    private Action onButtonClick;

    public void Init()
    {
        restartGameButton.onClick.AddListener(() =>
        {
            onButtonClick.Invoke();
            Destroy(gameObject);
        });
        exitGameButton.onClick.AddListener(Application.Quit);
    }

    public void OnButtonClick(Action onButtonClick)
    {
        this.onButtonClick = onButtonClick;
    }
}