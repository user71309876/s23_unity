using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 50f)//�ӽ÷� 50�ʰ� �Ǹ� �� �ΰ����� ���� ���������� ����
        {
            //Debug.Log("50������");
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (timer >= 30f)//�ӽ÷� 50�ʰ� �Ǹ� �� �ΰ����� ���� ���������� ����
        {
            //Debug.Log("30������");
            GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
        }
    }
}
