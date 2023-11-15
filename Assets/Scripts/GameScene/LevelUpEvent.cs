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

    private int expInterval = 50;   // 경험치 할당량
    private int currentExp = 0; // 현재 경험치
    private int maxExp = 100;   // 최대 경험치
    private int currentlevel = 1;   // 현재 레벨

    private int currentWidthBar = 0;    // 현재 경험치 바의 가로
    private int currentHeightBar = 45;  // 경험치 바의 세로
    private int maxWidthBar = 1000; // 최대 경험치 바 가로 길이
  

    private void Start()
    {
        UpdateExpText();
        UpdateExpBarWidth();
    }

    void UpdateExpText()    // ExpText의 text 내용 변경
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    void UpdateExpBarWidth()
    {
        expBar.rectTransform.sizeDelta = new Vector2(currentWidthBar, currentHeightBar);
    }
    
    void GainExp()    // 경험치 얻었을 경우
    {
        currentExp += expInterval;

        currentWidthBar += expInterval * 10;
        UpdateExpBarWidth();
        UpdateExpText();

        if (currentExp >= maxExp) // 레벨업
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
        if(Input.GetKeyUp(KeyCode.Space))   // 임시로 스페이스 바 누를 시 경험치 30 획득
        {
            //GainExp(expInterval);
            GainExp();
        }
    }
}
