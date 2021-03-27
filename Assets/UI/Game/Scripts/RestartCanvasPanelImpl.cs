using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartCanvasPanelImpl : MonoBehaviour, RestartCanvasPanel
{
    [SerializeField] private Button startGameButton;
    private Action onButtonClick;

    public void Init()
    {
        startGameButton.onClick.AddListener(() =>
        {
            onButtonClick.Invoke();
            Destroy(gameObject);
        });
    }

    public void OnButtonClick(Action onButtonClick)
    {
        this.onButtonClick = onButtonClick;
    }
}