using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioMixer BGM_Mixer;

    private float BGM_Volume;


    // music persists when switching scene
    void Awake(){
        // use singleton
        if(SoundManager.instance == null){
            SoundManager.instance = this;
        }
    }

    // change volume
    public void ChangeVolume(float volume){
        BGM_Mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        BGM_Mixer.GetFloat("BGM",out BGM_Volume);
    }
}
