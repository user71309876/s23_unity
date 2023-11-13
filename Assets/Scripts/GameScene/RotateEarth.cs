using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    3D 지구 모델의 자전을 구현
 */

public class RotateEarth : MonoBehaviour
{
    public float rotation_speed = 10.0f;    // 자전 속도

    void Update()
    {
        Earth_Rotation();
    }

    void Earth_Rotation()   // 지구 자전 함수
    {
        transform.Rotate(Vector3.down * rotation_speed * Time.deltaTime);
    }
}
