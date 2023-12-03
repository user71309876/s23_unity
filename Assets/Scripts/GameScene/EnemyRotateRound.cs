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
    private float timer;

    private bool isRotating;

    private void Start()
    {
        rotation_speed = 25.0f;//Random.Range(10.0f, 50.0f);    // 10 ~ 50 사이의 랜덤 값
        timer = 0f;
        isRotating = true;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);  // 중심에서 원주 방향으로 회전 속도만큼 이동
            timer += Time.deltaTime;

            if(timer >= 60f)//임시로 60초가 되면 적 인공위성들은 지구로 떨어지게
            {
                isRotating = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, center.position, Time.deltaTime * rotation_speed * 0.05f);
        }
    }
}
