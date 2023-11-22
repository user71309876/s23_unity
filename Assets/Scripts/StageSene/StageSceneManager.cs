using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSceneManager : MonoBehaviour
{
    private GameObject stageDetail;
    private float force=100f;
    private float gravity=10f;
    private Vector2 stageDetailPos;

    void Start(){
        //stageDetail 오브젝트 저장
        stageDetail=GameObject.Find("StageDetail");
    }

    void Update()
    {
        stageDetailPos = stageDetail.GetComponent<RectTransform>().anchoredPosition;
        //stageDetail의 xpos를 50이 될때까지 이동
        if(stageDetailPos.x < 50){
            force+=gravity;
            stageDetail.GetComponent<RectTransform>().anchoredPosition += new Vector2(force, 0f)*Time.deltaTime;
        }
    }
    public void GoMainScene(){
        SceneManager.LoadScene("MainScene");
    }
    public void GoGameScene(){
        SceneManager.LoadScene("GameScene");
    }
    public void GoSettingScene(){
        SceneManager.LoadScene("SettingScene");
    }
}