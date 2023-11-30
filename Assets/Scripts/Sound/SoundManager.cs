using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// set to be included in only one object because this class is a singleton class
[DisallowMultipleComponent]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioMixer MasterMixer;

    private float BGM_Volume;
    private float SFX_Volume;


    // music persists when switching scene
    void Awake(){
        // use singleton
        if(SoundManager.instance == null){
            SoundManager.instance = this;
        }
    }

    // change BGM 
    public void ChangeBGMVolume(float volume){
        MasterMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        MasterMixer.GetFloat("BGM",out BGM_Volume);
    }

    public void ChangeSFXVolume(float volume){
        MasterMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        MasterMixer.GetFloat("SFX",out BGM_Volume);
    }
}
/*
게임 오브젝트에 audio source를 만듬
그리고 output을 audio mixer의 SFX에게 보냄
SoundManager에서 받은 후 SettingPrefabController에서 컨트롤

//Todo : datamanager, 타워,미사일 효과음
*/