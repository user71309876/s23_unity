using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelUpEvent : MonoBehaviour
{
    public TMP_Text expText;    // 경험치 텍스트
    public TMP_Text levelText;  // 레벨 텍스트

    private float expInterval = 15f;   // 경험치 할당량
    private float currentExp = 0; // 현재 경험치
    private float maxExp = 100f;   // 최대 경험치
    private float currentlevel = 1f;   // 현재 레벨

    
    private Slider expslider;   // 경험치 슬라이더

    private float targetProgress = 0;   // 목표치
    private float fillSpeed = 3.0f;  // 경험치 애니메이션 속도

    public GameObject darkPanel;    // 어두운 화면

    public RectTransform cardObejcts;   // Card 부모 오브젝트 위치
    public GameObject cardButtons;  // Card 부모 오브젝트
    
    //private bool isGamePaused = false;  // 게임 멈췄는지 체크


    private void Awake()
    {
        expslider = GameObject.Find("ExpSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        // 경험치 초기 설정
        UpdateExpText();

        // 카드 초기 위치 설정
        CardMove(new Vector3(0, 500, -10));

        // 각각의 카드 중 하나를 선택할 경우, 게임 재시작, 카드 닫기
        Button card1Button = cardButtons.transform.Find("Card1").GetComponent<Button>();
        Button card2Button = cardButtons.transform.Find("Card2").GetComponent<Button>();
        Button card3Button = cardButtons.transform.Find("Card3").GetComponent<Button>();

        card1Button.onClick.AddListener(RestartGameAndCloseCard);
        card2Button.onClick.AddListener(RestartGameAndCloseCard);
        card3Button.onClick.AddListener(RestartGameAndCloseCard);
    }

    void UpdateExpText()    // ExpText의 text 내용 변경
    {
        expText.text = "Exp(" + currentExp + " / " + maxExp + ")";
    }

    
    public void GainExp()    // 경험치 얻었을 경우
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

            // 카드 오픈
            PauseGameAndOpenCard();
            //if (!isGamePaused)
            //{
                
            //}
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

    private void CardMove(Vector3 targetPosition)   // 카드 이동 애니메이션
    {
        cardObejcts.DOAnchorPosY(targetPosition.y, 1f).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    private void PauseGameAndOpenCard() // 게임 중단, 카드 열기
    {
        // 게임 정지
        Time.timeScale = 0f;
        //isGamePaused = true;

        // 카드 외의 화면 어둡게 활성화
        darkPanel.SetActive(true);
        darkPanel.GetComponent<Image>().DOFade(0.7f, 1f).SetUpdate(true);

        // 카드 open
        CardMove(new Vector3(0, -600, 10));
    }

    private void RestartGameAndCloseCard()  // 게임 재시작, 카드 닫기
    {   
        // 게임 재시작
        Time.timeScale = 1f;
        //isGamePaused = false;

        // 어둡게 만든 화면 밝게 만들고 비활성화
        darkPanel.GetComponent<Image>().DOFade(0f, 1f).OnComplete(() => darkPanel.SetActive(false));

        // 카드 close
        CardMove(new Vector3(0, 500, 10));
    }
}
