using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpEvent : MonoBehaviour
{
    public TMP_Text expText;
    public TMP_Text levelText; 

    private float expInterval = 30f;   // 경험치 할당량
    private float currentExp = 0; // 현재 경험치
    private float maxExp = 100f;   // 최대 경험치
    private float currentlevel = 1f;   // 현재 레벨


    public Slider expslider;   // 경험치 슬라이더

    private float targetProgress = 0;   // 목표치
    public float fillSpeed = 3.0f;  // 경험치 차는 속도

    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        UpdateExpText();
    }

    void UpdateExpText()    // ExpText의 text 내용 변경
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    
    void GainExp()    // 경험치 얻었을 경우
    {
        currentExp += expInterval;
        UpdateExpText();

        targetProgress = currentExp * 0.01f;    // 경험치량을 정규화(0 ~ 1 사이 값)

        if (currentExp >= maxExp) // 레벨업
        {
            currentExp -= maxExp;
            UpdateExpText();
            currentlevel++;
            levelText.text = "Lv. " + currentlevel;

            targetProgress = 1.0f;  // 우선, 100%로 경험치 할당 => Update 함수에서 다음 할당량 처리
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))   // 임시로 스페이스 바 누를 시 경험치 30 획득
        {
            GainExp();
        }

        if(expslider.value <= targetProgress)
        {
            expslider.value += fillSpeed * Time.deltaTime;
            if (expslider.value == 1.0f)    // 슬라이더 값이 100% 채웠을 때
            {
                targetProgress = currentExp * 0.01f;    // 목표치 재할당
                expslider.value = 0f;   // 슬라이더 값 초기화
            }
        }
    }
}
