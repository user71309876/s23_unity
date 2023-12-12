using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Slider hp_splider;


    GameObject level_event;

    public GameObject aluminum;//20%
    public GameObject aluminum2;//20%
    public GameObject korpus;//20%
    public GameObject solar_plane;//50%
    public GameObject solar_plane2;//50%

    GameObject randomItemObject;

    private ImgsFillDynamic ImgsFD;
    float gaugeInterval = 0.03f;

    PushFeverButton pushfeverButton;

    void Start()
    {
        level_event = GameObject.Find("LevelUpEvent");
        randomItemObject = GameObject.Find("RandomItem");
        ImgsFD = GameObject.Find("ImgFillRound").GetComponent<ImgsFillDynamic>();
        pushfeverButton = GameObject.Find("FeverButton").GetComponent<PushFeverButton>();
        hp_splider.value = hp_splider.maxValue;
    }

    void Update()
    {
        if (hp_splider.value <= 0)
        {
            //pos = this.gameObject.transform.position;
            Destroy(gameObject);
            //SpawnObject();
            level_event.GetComponent<LevelUpEvent>().GainExp();
            

            if(!pushfeverButton.GetFeverTime())
            {
                this.ImgsFD.SetValue(this.ImgsFD.GetValue() + gaugeInterval);
            }
            
            //if(Random.Range(0f, 1f) <= 0.3f)
            //{
            //    randomItemObject.GetComponent<ApplyRandomItem>().ApplyRandomItemOnEnemyDefeat();
            //}
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

    //void SpawnObject()
    //{
    //    if(nextspawnEnemy != null && nextspawnEnemy.Length > 0)
    //    {
    //        int randomIndex = Random.Range(0, nextspawnEnemy.Length); 

    //        Quaternion rotation = Quaternion.Euler(-30f, -5f, -25f); 
    //        GameObject newObject = Instantiate(nextspawnEnemy[randomIndex], pos, rotation); 
    //    }
    //}

    public void SetHealth(float newHealth)
    {
        hp_splider.maxValue = newHealth;
    }
}
