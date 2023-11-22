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
                SceneManager.LoadScene("StageScene");//�������� ������ �̵�
                Debug.Log("���� ����");
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("����");
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
