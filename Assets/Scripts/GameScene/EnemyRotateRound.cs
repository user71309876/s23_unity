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
        rotation_speed = Random.Range(10.0f, 50.0f);    // 10 ~ 50 ������ ���� ��
        timer = 0f;
        isRotating = true;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.RotateAround(center.position, Vector3.forward, rotation_speed * Time.deltaTime);  // �߽ɿ��� ���� �������� ȸ�� �ӵ���ŭ �̵�
            timer += Time.deltaTime;

            if(timer >= 5f)
            {
                isRotating = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, center.position, Time.deltaTime * rotation_speed * 0.05f);

            // Optionally, you can also rotate the enemy towards the center while moving
            // Uncomment the line below if you want the enemy to rotate while moving
            // transform.rotation = Quaternion.LookRotation(Vector3.forward, center.position - transform.position);
        }
    }



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Earth"))
    //    {
    //        Debug.Log("gd");
    //        Destroy(gameObject);
    //    }
    //}
}
