using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvasPanelImpl : MonoBehaviour, StartCanvasPanel
{
    private string SKIN_VERSION = "skin";
    [SerializeField] private Button startGameButton; 
    [SerializeField] private Button changeSkinButton; 
    private Action onButtonClick;
    private Action onChangeSkin; 
    

    public void Init()
    {
        startGameButton.onClick.AddListener(() =>
        {
            onButtonClick.Invoke();
            Destroy(gameObject);
        });   
        
        changeSkinButton.onClick.AddListener(() =>
        {
            onChangeSkin.Invoke(); 
        });   
      
    }

    public void OnButtonClick(Action onButtonClick)
    {
        this.onButtonClick = onButtonClick;
    }

    public void OnChangeSkin(Action onChangeSkin)
    {
        this.onChangeSkin = onChangeSkin;
    }

    public void GetGamePrefabStatus(Action<bool> action)
    {
        action.Invoke(PlayerPrefs.GetInt(SKIN_VERSION, 0) == 0 ? false : true);
    }
    public void SetGamePrefabStatus(bool status)
    {
        PlayerPrefs.SetInt(SKIN_VERSION, !status ? 0 : 1);
    }
}