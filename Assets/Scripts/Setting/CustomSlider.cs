using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using DG.Tweening;
//TODO : 포인트가 up 될때만 볼륨값 저장하기

public class CustomSlider: Slider
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        SettingPrefabController.instance.SaveSliderValue();
    }
}