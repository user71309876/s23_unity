using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class LevelUpEvent : MonoBehaviour
{
    public TMP_Text expText;    
    public TMP_Text levelText;  
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    private float expInterval = 15f;
    private float currentExp = 0;
    private float maxExp = 100f;
    private float currentlevel = 1f;
    private float currentScore = 0f;

    // when level up, maxExp = maxExp + increaseExp;
    private float increaseExp = 10f;
    
    private Slider expslider;

    private float targetProgress = 0;
    private float fillSpeed = 2.0f;

    public GameObject darkPanel;

    public RectTransform cardObejcts;
    public GameObject cardButtons;

    public bool isCardOpen = false;

    private float Btn2x = 1f;

    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        UpdateExpText();

        Button card1Button = cardButtons.transform.Find("Card1").GetComponent<Button>();
        Button card2Button = cardButtons.transform.Find("Card2").GetComponent<Button>();
        Button card3Button = cardButtons.transform.Find("Card3").GetComponent<Button>();

        card1Button.onClick.AddListener(RestartGameAndCloseCard);
        card2Button.onClick.AddListener(RestartGameAndCloseCard);
        card3Button.onClick.AddListener(RestartGameAndCloseCard);

        PauseGameAndOpenCard();

        expslider.value -= 0.04f;
    }

    void UpdateExpText()
    {
        expText.text = currentExp + " / " + maxExp;
    }

    
    public void GainExp()
    {
        currentExp += expInterval;
        UpdateExpText();

        targetProgress = currentExp * 0.01f; // normalized

        currentScore += 50f;

        if (currentExp >= maxExp) // level up
        {
            currentExp -= maxExp;
            UpdateExpText();

            currentlevel++;
            levelText.text = currentlevel.ToString();

            targetProgress = 1.0f;
            
            maxExp += increaseExp;
            UpdateExpText();

            currentScore += 1000f;

            PauseGameAndOpenCard();
        }

        // text update
        scoreText.text = currentScore.ToString();
        gameOverText.text = currentScore.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))   // level up key
        {
            GainExp();
        }

        if(expslider.value <= targetProgress)
        {
            expslider.value += fillSpeed * Time.deltaTime;

            if (expslider.value == 1.0f) // level up
            {
                targetProgress = currentExp * 0.01f;    // exp slider update
                expslider.value = 0f;
            }
        }
    }

    private void CardMove(Vector3 targetPosition)   // Card Open
    {
        cardObejcts.DOAnchorPosY(targetPosition.y, 1f).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    private void PauseGameAndOpenCard()
    {
        // stop game
        Time.timeScale = 0f;
        isCardOpen = true;

        // open dark panel
        darkPanel.SetActive(true);
        darkPanel.GetComponent<Image>().DOFade(0.7f, 1f).SetUpdate(true);

        SFXManager.instance.playSFXSound("SettingOpen");
        CardMove(new Vector3(0, -1080, 10));
    }

    private void RestartGameAndCloseCard()
    {
        Btn2x = GameObject.Find("2x").GetComponent<BtnType>().currentspeed;
        // game start
        Time.timeScale = Btn2x;
        isCardOpen = false;

        // close dark panel
        darkPanel.GetComponent<Image>().DOFade(0f, 1f).OnComplete(() => darkPanel.SetActive(false));

        SFXManager.instance.playSFXSound("SettingClose");
        CardMove(new Vector3(0, 0, 10));
    }
}
