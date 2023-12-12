using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateRound : MonoBehaviour
{
    public Transform center;    // 중심에 해당하는 물체
    private float rotation_speed = 25f;   // 회전 속도
    private float originalRotationSpeed;
    private float timer;

    private bool isRotating;
    public bool inSlowRadius = false;
    private float slowFactor;

    private void Start()
    {
        originalRotationSpeed = rotation_speed;
        timer = 0f;
        isRotating = true;
    }

    private void Update()
    {
        if (inSlowRadius)
        {
            originalRotationSpeed = rotation_speed * slowFactor;
        }
        else
        {
            originalRotationSpeed = rotation_speed;
        }

        if (isRotating)
        {
            transform.RotateAround(center.position, Vector3.forward, originalRotationSpeed * Time.deltaTime);  // 중심에서 원주 방향으로 회전 속도만큼 이동
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

    public void ApplySlow(float slowFactor)
    {
        this.slowFactor = slowFactor;
        this.inSlowRadius = true;
    }

    public void CancelSlow()
    {
        this.inSlowRadius = false;
    }
}
