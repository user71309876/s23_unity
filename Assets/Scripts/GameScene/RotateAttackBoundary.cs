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
        // 현재 오브젝트의 Transform 컴포넌트 가져오기
        Transform myTransform = transform;

        // 현재 회전값 가져오기
        Vector3 currentRotation = myTransform.eulerAngles;

        // z값에 회전 속도를 더하기
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // 새로운 회전값으로 설정
        myTransform.eulerAngles = currentRotation;
    }
}
