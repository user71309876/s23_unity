using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelUpEvent : MonoBehaviour
{
    public TMP_Text expText;    // ����ġ �ؽ�Ʈ
    public TMP_Text levelText;  // ���� �ؽ�Ʈ

    private float expInterval = 15f;   // ����ġ �Ҵ緮
    private float currentExp = 0; // ���� ����ġ
    private float maxExp = 100f;   // �ִ� ����ġ
    private float currentlevel = 1f;   // ���� ����

    
    private Slider expslider;   // ����ġ �����̴�

    private float targetProgress = 0;   // ��ǥġ
    private float fillSpeed = 3.0f;  // ����ġ �ִϸ��̼� �ӵ�

    public GameObject darkPanel;    // ��ο� ȭ��

    public RectTransform cardObejcts;   // Card �θ� ������Ʈ ��ġ
    public GameObject cardButtons;  // Card �θ� ������Ʈ
    
    //private bool isGamePaused = false;  // ���� ������� üũ


    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        // ����ġ �ʱ� ����
        UpdateExpText();

        // ī�� �ʱ� ��ġ ����
        CardMove(new Vector3(0, 500, -10));

        // ������ ī�� �� �ϳ��� ������ ���, ���� �����, ī�� �ݱ�
        Button card1Button = cardButtons.transform.Find("Card1").GetComponent<Button>();
        Button card2Button = cardButtons.transform.Find("Card2").GetComponent<Button>();
        Button card3Button = cardButtons.transform.Find("Card3").GetComponent<Button>();

        card1Button.onClick.AddListener(RestartGameAndCloseCard);
        card2Button.onClick.AddListener(RestartGameAndCloseCard);
        card3Button.onClick.AddListener(RestartGameAndCloseCard);
    }

    void UpdateExpText()    // ExpText�� text ���� ����
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    
    public void GainExp()    // ����ġ ����� ���
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

            // ī�� ����
            PauseGameAndOpenCard();
            //if (!isGamePaused)
            //{
                
            //}
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
        CardMove(new Vector3(0, -600, 10));
    }

    private void RestartGameAndCloseCard()  // ���� �����, ī�� �ݱ�
    {   
        // ���� �����
        Time.timeScale = 1f;
        //isGamePaused = false;

        // ��Ӱ� ���� ȭ�� ��� ����� ��Ȱ��ȭ
        darkPanel.GetComponent<Image>().DOFade(0f, 1f).OnComplete(() => darkPanel.SetActive(false));

        // ī�� close
        CardMove(new Vector3(0, 500, 10));
    }
}
