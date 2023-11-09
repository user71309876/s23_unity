using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateRound : MonoBehaviour
{
    public Transform center;
    private float rotation_speed;

    private void Start()
    {
        rotation_speed = Random.Range(10.0f, 50.0f);
    }

    private void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);
    }
}
