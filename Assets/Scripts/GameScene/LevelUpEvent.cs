using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpEvent : MonoBehaviour
{
    public TMP_Text expText;
    public TMP_Text levelText; 
    public Image expBar;

    private int expInterval = 50;   // ����ġ �Ҵ緮
    private int currentExp = 0; // ���� ����ġ
    private int maxExp = 100;   // �ִ� ����ġ
    private int currentlevel = 1;   // ���� ����

    private int currentWidthBar = 0;    // ���� ����ġ ���� ����
    private int currentHeightBar = 45;  // ����ġ ���� ����
    private int maxWidthBar = 1000; // �ִ� ����ġ �� ���� ����
  

    private void Start()
    {
        UpdateExpText();
        UpdateExpBarWidth();
    }

    void UpdateExpText()    // ExpText�� text ���� ����
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    void UpdateExpBarWidth()
    {
        expBar.rectTransform.sizeDelta = new Vector2(currentWidthBar, currentHeightBar);
    }
    
    void GainExp()    // ����ġ ����� ���
    {
        currentExp += expInterval;

        currentWidthBar += expInterval * 10;
        UpdateExpBarWidth();
        UpdateExpText();

        if (currentExp >= maxExp) // ������
        {
            currentExp -= maxExp;
            UpdateExpText();
            currentlevel++;
            levelText.text = "Lv. " + currentlevel;

            currentWidthBar -= maxWidthBar;
            UpdateExpBarWidth();
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))   // �ӽ÷� �����̽� �� ���� �� ����ġ 30 ȹ��
        {
            //GainExp(expInterval);
            GainExp();
        }
    }
}
