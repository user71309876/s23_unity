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

    private float expInterval = 30f;   // ����ġ �Ҵ緮
    private float currentExp = 0; // ���� ����ġ
    private float maxExp = 100f;   // �ִ� ����ġ
    private float currentlevel = 1f;   // ���� ����


    public Slider expslider;   // ����ġ �����̴�

    private float targetProgress = 0;   // ��ǥġ
    public float fillSpeed = 3.0f;  // ����ġ ���� �ӵ�

    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        UpdateExpText();
    }

    void UpdateExpText()    // ExpText�� text ���� ����
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    
    void GainExp()    // ����ġ ����� ���
    {
        currentExp += expInterval;
        UpdateExpText();

        targetProgress = currentExp * 0.01f;    // ����ġ���� ����ȭ(0 ~ 1 ���� ��)

        if (currentExp >= maxExp) // ������
        {
            currentExp -= maxExp;
            UpdateExpText();
            currentlevel++;
            levelText.text = "Lv. " + currentlevel;

            targetProgress = 1.0f;  // �켱, 100%�� ����ġ �Ҵ� => Update �Լ����� ���� �Ҵ緮 ó��
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))   // �ӽ÷� �����̽� �� ���� �� ����ġ 30 ȹ��
        {
            GainExp();
        }

        if(expslider.value <= targetProgress)
        {
            expslider.value += fillSpeed * Time.deltaTime;
            if (expslider.value == 1.0f)    // �����̴� ���� 100% ä���� ��
            {
                targetProgress = currentExp * 0.01f;    // ��ǥġ ���Ҵ�
                expslider.value = 0f;   // �����̴� �� �ʱ�ȭ
            }
        }
    }
}
