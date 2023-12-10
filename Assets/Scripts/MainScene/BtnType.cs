using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public static Scene currentScene;
    public float currentspeed;

    private void Start()
    {
        Time.timeScale = 1f;
        currentspeed = 1f;
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
            case BTNType.Speed2x:
                if(currentspeed == 1f)
                {
                    currentspeed = 2f;
                    Time.timeScale = currentspeed;
                }
                else
                {
                    currentspeed = 1f;
                    Time.timeScale = currentspeed;
                }
                break;
        }
    }
}
