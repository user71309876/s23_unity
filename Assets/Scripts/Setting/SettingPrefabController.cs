using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class SettingPrefabController : MonoBehaviour
{
    public static SettingPrefabController instance;

    public GameObject darkPanel;    // dark background image
    public RectTransform settingWindowObejcts;   // setting window position

    [Serializable]
    public class Sound{
        public Slider Slider;
        public Button Icon;
        public Image XIcon;
    }
    [SerializeField] Sound BGM;
    [SerializeField] Sound SFX;

    void Awake() {
        // use singleton
        if(SettingPrefabController.instance == null){
            SettingPrefabController.instance = this;
        }

        // change volume when move slider
        BGM.Slider.onValueChanged.AddListener(SoundManager.instance.ChangeVolume);
        SFX.Slider.onValueChanged.AddListener(SoundManager.instance.ChangeVolume);

        // change volume when click music icons
        BGM.Icon.onClick.AddListener(() => ToggleButton(BGM));
        SFX.Icon.onClick.AddListener(() => ToggleButton(SFX));
    }

    // sound on/off switch
    public void ToggleButton(Sound sound){
        if(sound.Slider.value==0.0001f){
            sound.XIcon.enabled=false;
            sound.Slider.value=1f;
        }
        else{
            sound.XIcon.enabled=true;
            sound.Slider.value=0.0001f;
        }
    }

    public void OpenSettingWindow(){
        PauseGameAndOpenSettingWindow();
    }

    public void CloseSettingWindow(){
        RestartGameAndCloseSettingWindow();
    }

    // pause game and open setting window
    private void PauseGameAndOpenSettingWindow()
    {
        // pause game
        Time.timeScale = 0f;
        //isGamePaused = true;

        // background color set dacker
        darkPanel.SetActive(true);
        darkPanel.GetComponent<Image>().DOFade(0.7f, 1f).SetUpdate(true);

        // setting window open
        SettingWindowMove(new Vector3(0, -1080, 0));
    }

    // restart game, close setting window
    private void RestartGameAndCloseSettingWindow()
    {   
        // restart game
        Time.timeScale = 1f;
        //isGamePaused = false;

        // background color set bright
        darkPanel.GetComponent<Image>().DOFade(0f, 1f).OnComplete(() => darkPanel.SetActive(false));

        // setting window close
        SettingWindowMove(new Vector3(0, 0, 0));
    }

    // setting window move
    private void SettingWindowMove(Vector3 targetPosition)
    {
        settingWindowObejcts.DOAnchorPosY(targetPosition.y, 1f).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    // set window screen mode 
    private void SetWindowScreen(){
        Screen.SetResolution(1920, 1080, false);
    }

    // set full screen mode
    private void SetFullScreen(){
        Screen.SetResolution(1920, 1080, true);
    }
}
