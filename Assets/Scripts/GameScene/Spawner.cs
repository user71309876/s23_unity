using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
    스폰 위치에서 랜덤 시간 간격을 두어 적을 소환시킴
 */

public class Spawner : MonoBehaviour
{
    public GameObject spawnEnemy;   // 적 오브젝트
    public Transform center;    // 중심 위치

    public float minSpawnInterval = 0.5f;   // 최소 스폰 시간
    public float maxSpawnInterval = 2.0f;   // 최대 스폰 시간

    private float nextSpawnTime;    // 다음 스폰 시간

    public float baseHealth = 10f; // 초기 체력

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);   // 다음 스폰 시간 설정
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)  // 스폰 시간이 되었을 때
        {
            SpawnObject();  // 오브젝트 스폰
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);   // 다음 스폰 시간 설정
            baseHealth += 3f;
        }
    }

    void SpawnObject()  // 적 스폰
    {
        Vector3 spawnPosition = new Vector3(0f, 2.5f, -2f); // 스폰 위치 설정
        GameObject newObject = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity); // 새 오브젝트 초기 설정
        newObject.GetComponent<EnemyRotateRound>().center = center; // 회전 중심 설정
        newObject.GetComponent<EnemyController>().SetHealth(baseHealth);
    }
}

