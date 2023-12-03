using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ���� �ش��ϴ� ��ü�� ���� �������� ������ �ӵ��� �̵�
    ��ü���� ��ũ��Ʈ�� ������� ���� ���� �ӵ��� ����
 */

public class EnemyRotateRound : MonoBehaviour
{
    public Transform center;    // �߽ɿ� �ش��ϴ� ��ü
    private float rotation_speed;   // ȸ�� �ӵ�
    private float timer;

    private bool isRotating;

    private void Start()
    {
        rotation_speed = 25.0f;//Random.Range(10.0f, 50.0f);    // 10 ~ 50 ������ ���� ��
        timer = 0f;
        isRotating = true;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);  // �߽ɿ��� ���� �������� ȸ�� �ӵ���ŭ �̵�
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
}
