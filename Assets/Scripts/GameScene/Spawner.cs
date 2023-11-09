using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnEnemy;
    public Transform center;

    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(0f, 2.5f, -2f);
        GameObject newObject = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity);
        newObject.GetComponent<EnemyRotateRound>().center = center;
    }
}

