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
    public TMP_Text expText;    // ����ġ �ؽ�Ʈ
    public TMP_Text levelText;  // ���� �ؽ�Ʈ
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    private float expInterval = 15f;   // ����ġ �Ҵ緮
    private float currentExp = 0; // ���� ����ġ
    private float maxExp = 100f;   // �ִ� ����ġ
    private float currentlevel = 1f;   // ���� ����

    private float currentScore = 0f;

    
    private Slider expslider;   // ����ġ �����̴�

    private float targetProgress = 0;   // ��ǥġ
    private float fillSpeed = 2.0f;  // ����ġ �ִϸ��̼� �ӵ�

    public GameObject darkPanel;    // ��ο� ȭ��

    public RectTransform cardObejcts;   // Card �θ� ������Ʈ ��ġ
    public GameObject cardButtons;  // Card �θ� ������Ʈ



    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        // ����ġ �ʱ� ����
        UpdateExpText();

        // ī�� �ʱ� ��ġ ����
        // CardMove(new Vector3(0, 0, -10));

        // ������ ī�� �� �ϳ��� ������ ���, ���� �����, ī�� �ݱ�
        Button card1Button = cardButtons.transform.Find("Card1").GetComponent<Button>();
        Button card2Button = cardButtons.transform.Find("Card2").GetComponent<Button>();
        Button card3Button = cardButtons.transform.Find("Card3").GetComponent<Button>();

        card1Button.onClick.AddListener(RestartGameAndCloseCard);
        card2Button.onClick.AddListener(RestartGameAndCloseCard);
        card3Button.onClick.AddListener(RestartGameAndCloseCard);

        PauseGameAndOpenCard(); // ���� ���� ��, Ÿ�� ��ġ

        expslider.value -= 0.04f;
    }

    void UpdateExpText()    // ExpText�� text ���� ����
    {
        expText.text = currentExp + " / " + maxExp;
    }

    
    public void GainExp()    // ����ġ ����
    {
        currentExp += expInterval;
        UpdateExpText();

        targetProgress = currentExp * 0.01f;    // ����ġ���� ����ȭ(0 ~ 1 ���� ��)

        currentScore += 50f;

        if (currentExp >= maxExp) // ������
        {
            currentExp -= maxExp;
            UpdateExpText();
            currentlevel++;
            levelText.text = currentlevel.ToString();

            targetProgress = 1.0f;  // �켱, 100%�� ����ġ �Ҵ� => Update �Լ����� ���� �Ҵ緮 ó��

            currentScore += 1000f;

            PauseGameAndOpenCard();
        }

        scoreText.text = currentScore.ToString();
        gameOverText.text = currentScore.ToString();
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

    private void CardMove(Vector3 targetPosition)   // ī�� �̵� �ִϸ��̼�
    {
        cardObejcts.DOAnchorPosY(targetPosition.y, 1f).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    private void PauseGameAndOpenCard() // ���� �ߴ�, ī�� ����
    {
        // ���� ����
        Time.timeScale = 0f;
        //isGamePaused = true;

        // ī�� ���� ȭ�� ��Ӱ� Ȱ��ȭ
        darkPanel.SetActive(true);
        darkPanel.GetComponent<Image>().DOFade(0.7f, 1f).SetUpdate(true);

        // ī�� open
        SFXManager.instance.playSFXSound("SettingOpen");
        CardMove(new Vector3(0, -1080, 10));
    }

    private void RestartGameAndCloseCard()  // ���� �����, ī�� �ݱ�
    {   
        // ���� �����
        Time.timeScale = 1f;
        //isGamePaused = false;

        // ��Ӱ� ���� ȭ�� ��� ����� ��Ȱ��ȭ
        darkPanel.GetComponent<Image>().DOFade(0f, 1f).OnComplete(() => darkPanel.SetActive(false));

        // ī�� close
        SFXManager.instance.playSFXSound("SettingClose");
        CardMove(new Vector3(0, 0, 10));
    }
}
