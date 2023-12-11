using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateRound : MonoBehaviour
{
    public Transform center;    // �߽ɿ� �ش��ϴ� ��ü
    private float rotation_speed = 25f;   // ȸ�� �ӵ�
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
            transform.RotateAround(center.position, Vector3.forward, originalRotationSpeed * Time.deltaTime);  // �߽ɿ��� ���� �������� ȸ�� �ӵ���ŭ �̵�
            timer += Time.deltaTime;

            if(timer >= 60f)//�ӽ÷� 60�ʰ� �Ǹ� �� �ΰ��������� ������ ��������
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
