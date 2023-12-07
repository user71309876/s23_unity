using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Enemy 1 ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ê±ï¿½È­ : È¸ï¿½ï¿½(-30, -5, -25), Å©ï¿½ï¿½(0.16, 0.16, 0.16)
 */

public class EnemyController : MonoBehaviour
{
    public Slider hp_splider;

    //Vector2 pos;//ï¿½Î¼ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½Ä¡ ï¿½Ä¾ï¿½ï¿½Ø¼ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½Ã¼ ï¿½Ö±ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½

    //public GameObject[] nextspawnEnemy = new GameObject[1]; // ï¿½Ä±ï¿½ï¿½ï¿½ ï¿½ï¿½, ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½È¯ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® ï¿½ï¿½ï¿½ï¿½

    GameObject level_event;

    //ï¿½ï¿½ï¿½ï¿½ Ã¼ï¿½ï¿½ï¿½ï¿½ï¿½Ï°ï¿½ ï¿½Ç¸ï¿½ È°ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Òµï¿½
    public GameObject aluminum;//20%
    public GameObject aluminum2;//20%
    public GameObject korpus;//20%
    public GameObject solar_plane;//50%
    public GameObject solar_plane2;//50%

    GameObject randomItemObject;

    private ImgsFillDynamic ImgsFD;
    float gaugeInterval = 0.05f;

    PushFeverButton pushfeverButton;

    void Start()
    {
        level_event = GameObject.Find("LevelUpEvent");
        randomItemObject = GameObject.Find("RandomItem");
        ImgsFD = GameObject.Find("ImgFillRound").GetComponent<ImgsFillDynamic>();
        pushfeverButton = GameObject.Find("FeverButton").GetComponent<PushFeverButton>();
    }

    void Update()
    {
        if (hp_splider.value <= 0)
        {
            //pos = this.gameObject.transform.position;
            Destroy(gameObject);
            //SpawnObject();
            level_event.GetComponent<LevelUpEvent>().GainExp(); // ï¿½ï¿½ Ã³ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½

<<<<<<< Updated upstream
            // Àû Ã³Ä¡ ½Ã, °ÔÀÌÁö gaugeInterval ¸¸Å­ »ó½Â
            if(!pushfeverButton.GetFeverTime())
            {
                this.ImgsFD.SetValue(this.ImgsFD.GetValue() + gaugeInterval);
            }
            
            //if(Random.Range(0f, 1f) <= 0.3f)
            //{
            //    randomItemObject.GetComponent<ApplyRandomItem>().ApplyRandomItemOnEnemyDefeat();
            //}
=======
            // if(Random.Range(0f, 1f) <= 0.3f)
            // {
            //     randomItemObject.GetComponent<ApplyRandomItem>().ApplyRandomItemOnEnemyDefeat();
            // }
>>>>>>> Stashed changes
        }
        else if (hp_splider.value <= hp_splider.maxValue / 5)
        {
            aluminum.SetActive(false);
            aluminum2.SetActive(false);
            korpus.SetActive(false);
        }
        else if (hp_splider.value <= hp_splider.maxValue / 2)
        {
            solar_plane.SetActive(false);
            solar_plane2.SetActive(false);
        }
    }

    public void TakeDamage (float damage)
    {
        hp_splider.value -= damage;
    }

    //void SpawnObject()  // ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    //{
    //    if(nextspawnEnemy != null && nextspawnEnemy.Length > 0)
    //    {
    //        int randomIndex = Random.Range(0, nextspawnEnemy.Length);  // ï¿½è¿­ï¿½Ì¶ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½

    //        Quaternion rotation = Quaternion.Euler(-30f, -5f, -25f);    // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® È¸ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    //        GameObject newObject = Instantiate(nextspawnEnemy[randomIndex], pos, rotation); // ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® ï¿½Ê±ï¿½ ï¿½ï¿½ï¿½ï¿½
    //    }
    //}

    public void SetHealth(float newHealth)
    {
        hp_splider.maxValue = newHealth;
    }
}
