using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvasPanelImpl : MonoBehaviour, StartCanvasPanel
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