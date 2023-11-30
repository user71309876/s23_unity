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
                SFXManager.instance.playSFXSound("Button");
                SceneManager.LoadScene("StageScene");
                break;
            case BTNType.Quit: // exit the game
                SFXManager.instance.playSFXSound("Button");
                Application.Quit();
                break;
            case BTNType.Main: // go to Main Scene
                SFXManager.instance.playSFXSound("Button");
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainScene");
                break;
            case BTNType.Game: // go to Game Scene
                SFXManager.instance.playSFXSound("Button");
                Time.timeScale = 1f;
                SceneManager.LoadScene("GameScene");
                break;
            case BTNType.Setting: // Open Setting window
                SFXManager.instance.playSFXSound("Button");
                SettingPrefabController.instance.OpenSettingWindow();
                break;
        }
    }
}
