using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Enemy 1 프리팹 초기화 : 회전(-30, -5, -25), 크기(0.16, 0.16, 0.16)

 */

public class EnemyController : MonoBehaviour
{
    public Slider hp_splider;

    //Vector2 pos;//부서지기 전 위치 파악해서 그 보다 작은 적 객체 넣기 위한 변수

    //public GameObject[] nextspawnEnemy = new GameObject[1]; // 파괴된 후, 다음으로 소환할 오브젝트 설정

    GameObject level_event;

    //일정 체력이하가 되면 활성을 꺼버릴 요소들
    public GameObject aluminum;//20%
    public GameObject aluminum2;//20%
    public GameObject korpus;//20%
    public GameObject solar_plane;//50%
    public GameObject solar_plane2;//50%

    void Start()
    {
        level_event = GameObject.Find("LevelUpEvent");
    }

    void Update()
    {
        if (hp_splider.value <= 0)
        {
            //pos = this.gameObject.transform.position;
            Destroy(gameObject);
            //SpawnObject();
            level_event.GetComponent<LevelUpEvent>().GainExp(); // 적 처리 될 시 레벨업
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

    //void SpawnObject()  // 적 스폰
    //{
    //    if(nextspawnEnemy != null && nextspawnEnemy.Length > 0)
    //    {
    //        int randomIndex = Random.Range(0, nextspawnEnemy.Length);  // 배열이라면 랜덤 선택

    //        Quaternion rotation = Quaternion.Euler(-30f, -5f, -25f);    // 오브젝트 회전 설정
    //        GameObject newObject = Instantiate(nextspawnEnemy[randomIndex], pos, rotation); // 새 오브젝트 초기 설정
    //    }
    //}

    public void SetHealth(float newHealth)
    {
        hp_splider.maxValue = newHealth;
    }
}
