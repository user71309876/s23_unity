using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
    ���� ��ġ���� ���� �ð� ������ �ξ� ���� ��ȯ��Ŵ
 */

public class Spawner : MonoBehaviour
{
    public GameObject spawnEnemy;   // �� ������Ʈ
    public Transform center;    // �߽� ��ġ

    public float minSpawnInterval = 0.5f;   // �ּ� ���� �ð�
    public float maxSpawnInterval = 2.0f;   // �ִ� ���� �ð�

    private float nextSpawnTime;    // ���� ���� �ð�

    public float baseHealth = 10f; // �ʱ� ü��, ����Ƽ ������ �����ϴ°� �� ���� ��� �̰� ����

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);   // ���� ���� �ð� ����
    }
        
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)  // ���� �ð��� �Ǿ��� ��
        {
            SpawnObject();  // ������Ʈ ����
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);   // ���� ���� �ð� ����
            baseHealth += 1f;//ü���� �þ�� ũ��
        }
    }

    void SpawnObject()  // �� ����
    {
        Vector3 spawnPosition = new Vector3(0f, 2.5f, -2f); // ���� ��ġ ����
        Quaternion spawnQuaternion = Quaternion.Euler(-30f, -5f, -25f); // ���� ȸ�� ����

        GameObject newObject = Instantiate(spawnEnemy, spawnPosition, spawnQuaternion); // �� ������Ʈ �ʱ� ����
        newObject.GetComponent<EnemyRotateRound>().center = center; // ȸ�� �߽� ����
        newObject.GetComponent<EnemyController>().SetHealth(baseHealth);
    }
}

