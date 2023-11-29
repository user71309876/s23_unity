using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public static Scene currentScene;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void OnBtnClick()
    {
        
        switch (currentType)
        {
            case BTNType.Stage: //  Go to Stage Scene
                SceneManager.LoadScene("StageScene");
                Debug.Log("���� ����");
                break;
            case BTNType.Quit: // exit the game
                Application.Quit();
                Debug.Log("����");
                break;
            case BTNType.Main: // go to Main Scene
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainScene");
                break;
            case BTNType.Game: // go to Game Scene
                Time.timeScale = 1f;
                SceneManager.LoadScene("GameScene");
                break;
            case BTNType.Setting: // Open Setting window
                SettingPrefabController.instance.OpenSettingWindow();
                break;
        }
    }
}
