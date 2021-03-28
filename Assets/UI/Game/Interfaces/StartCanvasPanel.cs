 using System;

 public interface StartCanvasPanel
 {
     void Init();
     void OnButtonClick(Action onButtonClick);
     void OnChangeSkin(Action onChangeSkin);
     void GetGamePrefabStatus(Action<bool> status);
     void SetGamePrefabStatus(bool status);
 }
 