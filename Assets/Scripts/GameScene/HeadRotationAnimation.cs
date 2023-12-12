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
        // middleHead�� �ð� �������� ȸ��
        middleHead.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // topHead�� �ݽð� �������� ȸ��
        topHead.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}
