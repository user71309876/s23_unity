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

    //public float minSpawnInterval = 0.5f;   // �ּ� ���� �ð�
    //public float maxSpawnInterval = 2.0f;   // �ִ� ���� �ð�
    private float SpawnInterval = 45f;

    private float nextSpawnTime;    // ���� ���� �ð�

    public float baseHealth; // �ʱ� ü��, ����Ƽ ������ �����ϴ°� �� ���� ��� �̰� ����
    private int spawnCount = 1;

    private float enemyNum = 7;
    void Start()
    {
        StartCoroutine(DelaySpawn());
        nextSpawnTime = Time.time + SpawnInterval;/*Random.Range(minSpawnInterval, maxSpawnInterval);*/   // ���� ���� �ð� ����
    }
        
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)  // ���� �ð��� �Ǿ��� ��
        {
            //SpawnObject();// ������Ʈ ����
            StartCoroutine(DelaySpawn());
            nextSpawnTime = Time.time + SpawnInterval;/*Random.Range(minSpawnInterval, maxSpawnInterval);*/   // ���� ���� �ð� ����
            if(SpawnInterval > 10f)
            {
                SpawnInterval -= 5f;
            }
            baseHealth += 3f;//ü���� �þ�� ũ��
            spawnCount++;
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

    IEnumerator DelaySpawn()
    {
        if (spawnCount % 4 == 0)
        {
            enemyNum += 2;
        }
        for (int i = 0; i < enemyNum; i++)
        {
            SpawnObject();
            yield return new WaitForSeconds(Random.Range(0.5f,2f)); // 0.5�� ���� ��ٸ��ϴ�.
        }
    }
}

