using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PushFeverButton : MonoBehaviour
{
    private Button button;
    private ImgsFillDynamic imgsFill;
    private GameObject FeverGauge;
    private bool isFeverTime = false;

    private float pulseDuration = 0.3f;
    private float pulseScale = 1.7f;

    private Vector3 originalScale;

    Tweener feverTween;

    LevelUpEvent levelUpEvent;
    private float imgsFillspeed = 1f;

    private void Start()
    {
        imgsFill = GameObject.Find("ImgFillRound").GetComponent<ImgsFillDynamic>();
        FeverGauge = GameObject.Find("ImgFillRound");

        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(HandleFeverButtonCoroutine()));

        originalScale = FeverGauge.transform.localScale;

        feverTween.Pause();

        levelUpEvent = GameObject.Find("LevelUpEvent").GetComponent<LevelUpEvent>();
    }   

    private IEnumerator HandleFeverButtonCoroutine()
    {
        feverTween = FeverGauge.transform.DOScale(pulseScale, pulseDuration).SetLoops(-1, LoopType.Yoyo);

        isFeverTime = true;
        ActivateTower(isFeverTime);
        
        Debug.Log("피버타임 활성화 되었습니다");

        imgsFillspeed = GameObject.Find("2x").GetComponent<BtnType>().currentspeed;

        imgsFill.SetValue(0f, false, 0.0002f * imgsFillspeed);

        if (!levelUpEvent.isCardOpen)
        {
            Debug.Log("피버 모션 재생");
            feverTween.Play();
        }
        else
        {
            feverTween.Pause();
        }

        yield return new WaitForSeconds(10f);

        isFeverTime = false;
        ActivateTower(isFeverTime);

        FeverGauge.transform.DOKill();
        FeverGauge.transform.localScale = originalScale;

        Debug.Log("피버 타임이 비활성화 되었습니다");
    }

    private void ActivateTower(bool isActive)
    {
        // Find all Tower objects with the specified tag
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach (GameObject tower in towers)
        {
            Transform leftLauncher = tower.transform.Find("LeftLauncher");
            if (leftLauncher != null)
            {
                leftLauncher.gameObject.SetActive(isActive);
            }
        }
    }

    public bool GetFeverTime()
    {
        return isFeverTime;
    }
}
