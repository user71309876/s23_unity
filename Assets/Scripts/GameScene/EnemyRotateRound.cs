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

    private void Start()
    {
        rotation_speed = Random.Range(10.0f, 50.0f);    // 10 ~ 50 ������ ���� ��
    }

    private void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);  // �߽ɿ��� ���� �������� ȸ�� �ӵ���ŭ �̵�
    }
}
