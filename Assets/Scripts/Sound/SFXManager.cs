using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class EffectSound : SerializableDictionary<string, AudioClip>{}

[DisallowMultipleComponent]
public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    private AudioSource UISFXSource;
    [SerializeField] private EffectSound UISounds;
    [SerializeField] private EffectSound EffectSounds;
    [SerializeField]private AudioSource[] SFXSources;

    void Start()
    {
        if(SFXManager.instance == null){
            SFXManager.instance = this;
        }
        UISFXSource=gameObject.GetComponent<AudioSource>();
    }

    public void playEffectSound(string soundName){
        for(int i=0;i<SFXSources.Length;i++){
            if(!SFXSources[i].isPlaying){
                SFXSources[i].clip=EffectSounds[soundName];
                SFXSources[i].Play();
                return;
            }
        }
        Debug.Log("All effect audio source is playing");
    }

    public void playSFXSound(string soundName){
        UISFXSource.clip=UISounds[soundName];
        UISFXSource.Play();
    }
}
