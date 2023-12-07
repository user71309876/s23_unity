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

    private void Start()
    {
        imgsFill = GameObject.Find("ImgFillRound").GetComponent<ImgsFillDynamic>();
        FeverGauge = GameObject.Find("ImgFillRound");

        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(HandleFeverButtonCoroutine()));

        originalScale = FeverGauge.transform.localScale;
    }   

    private IEnumerator HandleFeverButtonCoroutine()
    {
        isFeverTime = true;
        ActivateTower(isFeverTime);
        imgsFill.SetValue(0f, false, 0.001f);

        FeverGauge.transform.DOScale(pulseScale, pulseDuration).SetLoops(-1, LoopType.Yoyo);

        yield return new WaitForSeconds(10f);

        isFeverTime = false;
        ActivateTower(isFeverTime);

        FeverGauge.transform.DOKill();
        FeverGauge.transform.localScale = originalScale;

        Debug.Log("�ǹ� Ÿ���� ��Ȱ��ȭ �Ǿ����ϴ�");
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

        Debug.Log("�ǹ�Ÿ�� Ȱ��ȭ �Ǿ����ϴ�");
    }

    public bool GetFeverTime()
    {
        return isFeverTime;
    }
}
