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

    void Start()
    {
        //stageDetail 오브젝트 저장
        stageDetail=GameObject.Find("StageDetail");
    }

    // Update is called once per frame
    void Update()
    {
        //stageDetail의 xpos를 50이 될때까지 이동
        if(stageDetail.GetComponent<RectTransform>().anchoredPosition.x < 50){
            force+=gravity;
            stageDetail.GetComponent<RectTransform>().anchoredPosition += new Vector2(force, 0f)*Time.deltaTime;
        }
    }
    public void GoMainScene(){
        SceneManager.LoadScene("MainScene");
    }
    public void GoGameScene(){
        SceneManager.LoadScene("GameScene");
        Debug.Log(PlayerPrefs.GetInt(ScrollButtonHandler.stageNumber));
    }
    public void GoSettingScene(){
        SceneManager.LoadScene("SettingScene");
    }
}
