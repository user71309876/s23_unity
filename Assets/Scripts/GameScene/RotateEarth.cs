using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    3D ���� ���� ������ ����
 */

public class RotateEarth : MonoBehaviour
{
    public float rotation_speed = 10.0f;    // ���� �ӵ�

    void Update()
    {
        Earth_Rotation();
    }

    void Earth_Rotation()   // ���� ���� �Լ�
    {
        transform.Rotate(Vector3.down * rotation_speed * Time.deltaTime);
    }
}
