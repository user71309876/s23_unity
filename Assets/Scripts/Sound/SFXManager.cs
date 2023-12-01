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
    private AudioSource SFXSource;
    [SerializeField] private EffectSound Sounds;

    void Start()
    {
        if(SFXManager.instance == null){
            SFXManager.instance = this;
        }
        SFXSource=gameObject.GetComponent<AudioSource>();
    }

    public void playSFXSound(string soundName){
        SFXSource.clip=Sounds[soundName];
        SFXSource.Play();
    }
}
