using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// set to be included in only one object because this class is a singleton class
[DisallowMultipleComponent]
public class BGMManager : MonoBehaviour
{
    private AudioSource BGMSource;
    [SerializeField] private AudioClip BGMClip; // BGM muisc
    void Start()
    {
        BGMSource=gameObject.GetComponent<AudioSource>();
        BGMSource.clip=BGMClip;
        BGMSource.Play();
    }
}
