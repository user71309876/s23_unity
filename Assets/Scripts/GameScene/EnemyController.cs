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

    Vector2 pos;//�μ����� �� ��ġ �ľ��ؼ� �� ���� ���� �� ��ü �ֱ� ���� ����

    public GameObject[] nextspawnEnemy = new GameObject[1]; // �ı��� ��, �������� ��ȯ�� ������Ʈ ����

    GameObject level_event;
    // Start is called before the first frame update
    void Start()
    {
        //hp_splider.value = hp_splider.maxValue;
        level_event = GameObject.Find("LevelUpEvent");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp_splider.value <= 0)
        {
            pos = this.gameObject.transform.position;
            Destroy(gameObject);
            SpawnObject();
            level_event.GetComponent<LevelUpEvent>().GainExp(); // �� ó�� �� �� ������
        }
    }

    public void TakeDamage (float damage)
    {
        hp_splider.value -= damage;
    }

    void SpawnObject()  // �� ����
    {
        if(nextspawnEnemy != null && nextspawnEnemy.Length > 0)
        {
            int randomIndex = Random.Range(0, nextspawnEnemy.Length);  // �迭�̶�� ���� ����

            Quaternion rotation = Quaternion.Euler(-30f, -5f, -25f);    // ������Ʈ ȸ�� ����
            GameObject newObject = Instantiate(nextspawnEnemy[randomIndex], pos, rotation); // �� ������Ʈ �ʱ� ����
        }
    }
}
