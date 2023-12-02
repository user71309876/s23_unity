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
    public struct Sound{
        public Slider Slider; // volume slider
        public Button Icon; // a icon to the left of the slider
        public Image XIcon; // a icon similar in shape to an 'X'
        [HideInInspector] public string key; // hash key
    }
    [SerializeField] Sound BGM;
    [SerializeField] Sound SFX;

    void Awake() {
        // use singleton
        if(SettingPrefabController.instance == null){
            SettingPrefabController.instance = this;
        }

        //set key of sound volume value(use hashkey)
        BGM.key="BGMVolume";
        SFX.key="SFXVolume";

        // change volume when move slider
        // BGM.Slider.onValueChanged.AddListener(SoundManager.instance.ChangeBGMVolume);
        BGM.Slider.onValueChanged.AddListener(ChangeBGMVolume);
        SFX.Slider.onValueChanged.AddListener(ChangeSFXVolume);

        // change volume when click music icons
        BGM.Icon.onClick.AddListener(() => ToggleButton(BGM));
        SFX.Icon.onClick.AddListener(() => ToggleButton(SFX));
    }

    void Start(){
        // set last saved value
        BGM.Slider.value=PlayerPrefs.GetFloat(BGM.key);
        SFX.Slider.value=PlayerPrefs.GetFloat(SFX.key);
    }

    // change BGM Volume
    private void ChangeBGMVolume(float volume){
        if(BGM.XIcon.enabled==false){
            PlayerPrefs.SetFloat(BGM.key, volume);
        }
        // when Volume is 0%
        if(BGM.Slider.value==0.0001f){
            BGM.XIcon.enabled=true;
        }
        //when Volume is not 0%
        else{
            BGM.XIcon.enabled=false;
        }
        SoundManager.instance.ChangeBGMVolume(volume);
    }

    // change SFX Volume
    private void ChangeSFXVolume(float volume){
        if(SFX.XIcon.enabled==false){
            PlayerPrefs.SetFloat(SFX.key, volume);
        }
        // when Volume is 0%
        if(SFX.Slider.value==0.0001f){
            SFX.XIcon.enabled=true;
        }
        //when Volume is not 0%
        else{
            SFX.XIcon.enabled=false;
        }
        SoundManager.instance.ChangeSFXVolume(volume);
    }

    // sound on/off switch
    public void ToggleButton(Sound sound){
        // when Volume is 0%
        if(sound.Slider.value==0.0001f){
            sound.Slider.value=PlayerPrefs.GetFloat(sound.key);
        }
        //when Volume is not 0%
        else{
            sound.Slider.value=0.0001f;
        }
    }

    public void OpenSettingWindow(){
        SFXManager.instance.playSFXSound("SettingOpen");
        PauseGameAndOpenSettingWindow();
    }

    public void CloseSettingWindow(){
        SFXManager.instance.playSFXSound("SettingClose");
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
        SFXManager.instance.playSFXSound("Button");
        Screen.SetResolution(1920, 1080, false);
    }

    // set full screen mode
    private void SetFullScreen(){
        SFXManager.instance.playSFXSound("Button");
        Screen.SetResolution(1920, 1080, true);
    }

    void OnApplicationQuit(){
        
    }
}
