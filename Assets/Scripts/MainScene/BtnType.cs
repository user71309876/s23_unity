using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public static Scene currentScene;
    

    public void OnBtnClick()
    {
        
        switch (currentType)
        {
            case BTNType.Start:
                SceneManager.LoadScene("StageScene");//스테이지 씬으로 이동
                Debug.Log("게임 시작");
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("종료");
                break;
            case BTNType.Main:
                SceneManager.LoadScene("MainScene");
                break;
            case BTNType.Retry:
                SceneManager.LoadScene("GameScene");
                break;
        }
    }
}
