using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSceneManager : MonoBehaviour
{
    [SerializeField] private RectTransform contents;
    [SerializeField] private GameObject obj;
    private string rank;
    private string name;
    private string score;
    private SortedDictionary<string,int> dicScoreInfo = new SortedDictionary<string,int>();

    void Start(){
        int temp=1;
        while(PlayerPrefs.HasKey(temp.ToString())){
            dicScoreInfo.Add(PlayerPrefs.GetString(temp.ToString()+"S"),PlayerPrefs.GetInt(temp.ToString()));
            temp++;
        }
        temp=1;
        while(PlayerPrefs.HasKey(temp.ToString()+"S")){
            GameObject scoreinfo=Instantiate(obj,contents);
            scoreinfo.transform.Find("RankNumber").GetComponent<TMP_Text>().text=temp.ToString();
            scoreinfo.transform.Find("PlayerName").GetComponent<TMP_Text>().text=PlayerPrefs.GetString(temp.ToString()+"S");
            scoreinfo.transform.Find("Score").GetComponent<TMP_Text>().text=PlayerPrefs.GetInt(temp.ToString()).ToString();
            temp++;
        }
    }

    void Update()
    {

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