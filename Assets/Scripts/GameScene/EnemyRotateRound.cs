using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    적에 해당하는 물체를 원주 방향으로 랜덤한 속도로 이동
    물체마다 스크립트를 적용시켜 각각 랜덤 속도로 적용
 */

public class EnemyRotateRound : MonoBehaviour
{
    public Transform center;    // 중심에 해당하는 물체
    private float rotation_speed;   // 회전 속도

    private void Start()
    {
        rotation_speed = Random.Range(10.0f, 50.0f);    // 10 ~ 50 사이의 랜덤 값
    }

    private void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);  // 중심에서 원주 방향으로 회전 속도만큼 이동
    }
}
