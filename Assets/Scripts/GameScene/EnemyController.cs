using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Enemy 1 ������ �ʱ�ȭ : ȸ��(-30, -5, -25), ũ��(0.16, 0.16, 0.16)

 */

public class EnemyController : MonoBehaviour
{
    public Slider hp_splider;

    //Vector2 pos;//�μ����� �� ��ġ �ľ��ؼ� �� ���� ���� �� ��ü �ֱ� ���� ����

    //public GameObject[] nextspawnEnemy = new GameObject[1]; // �ı��� ��, �������� ��ȯ�� ������Ʈ ����

    GameObject level_event;

    //���� ü�����ϰ� �Ǹ� Ȱ���� ������ ��ҵ�
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
            level_event.GetComponent<LevelUpEvent>().GainExp(); // �� ó�� �� �� ������
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

    //void SpawnObject()  // �� ����
    //{
    //    if(nextspawnEnemy != null && nextspawnEnemy.Length > 0)
    //    {
    //        int randomIndex = Random.Range(0, nextspawnEnemy.Length);  // �迭�̶�� ���� ����

    //        Quaternion rotation = Quaternion.Euler(-30f, -5f, -25f);    // ������Ʈ ȸ�� ����
    //        GameObject newObject = Instantiate(nextspawnEnemy[randomIndex], pos, rotation); // �� ������Ʈ �ʱ� ����
    //    }
    //}

    public void SetHealth(float newHealth)
    {
        hp_splider.maxValue = newHealth;
    }
}
