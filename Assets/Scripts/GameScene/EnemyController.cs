using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] Slider hp_splider;

    Vector2 pos;//부서지기 전 위치 파악해서 그 보다 작은 적 객체 넣기 위한 변수
    public GameObject midspawnEnemy;   // 중간 적 오브젝트
    public GameObject smallspawnEnemy; // 작은 적 오브젝트

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
            level_event.GetComponent<LevelUpEvent>().GainExp(); // 적 처리 될 시 레벨업
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            hp_splider.value--;
        }
    }

    void SpawnObject()  // 적 스폰
    {
        GameObject newObject = Instantiate(midspawnEnemy, pos, Quaternion.identity); // 새 오브젝트 초기 설정
    }
}
