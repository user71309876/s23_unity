using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAttackBoundary : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������Ʈ�� Transform ������Ʈ ��������
        Transform myTransform = transform;

        // ���� ȸ���� ��������
        Vector3 currentRotation = myTransform.eulerAngles;

        // z���� ȸ�� �ӵ��� ���ϱ�
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // ���ο� ȸ�������� ����
        myTransform.eulerAngles = currentRotation;
    }
}
