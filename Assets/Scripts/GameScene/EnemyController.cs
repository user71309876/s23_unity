using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] Slider hp_splider;

    Vector2 pos;//�μ����� �� ��ġ �ľ��ؼ� �� ���� ���� �� ��ü �ֱ� ���� ����
    public GameObject midspawnEnemy;   // �߰� �� ������Ʈ
    public GameObject smallspawnEnemy; // ���� �� ������Ʈ

    GameObject level_event;
    // Start is called before the first frame update
    void Start()
    {
        hp_splider.value = hp_splider.maxValue;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            hp_splider.value--;
        }
    }

    void SpawnObject()  // �� ����
    {
        GameObject newObject = Instantiate(midspawnEnemy, pos, Quaternion.identity); // �� ������Ʈ �ʱ� ����
    }
}
