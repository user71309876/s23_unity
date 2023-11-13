using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    void SpawnObject()  // �� ����
    {
        Vector3 spawnPosition = new Vector3(0f, 2.5f, -2f); // ���� ��ġ ����
        GameObject newObject = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity); // �� ������Ʈ �ʱ� ����
        newObject.GetComponent<EnemyRotateRound>().center = center; // ȸ�� �߽� ����
    }
}

