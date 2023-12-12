using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotationAnimation : MonoBehaviour
{
    public Transform middleHead;
    public Transform topHead;
    public float rotationSpeed = 50f;

    void Update()
    {
        // middleHead를 시계 방향으로 회전
        middleHead.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // topHead를 반시계 방향으로 회전
        topHead.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}
