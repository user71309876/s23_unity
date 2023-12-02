using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private float timer;
    private int isBlink;
    private float blinkTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        isBlink = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        blinkTimer += Time.deltaTime;
        if (timer >= 50f)//�ӽ÷� 50�ʰ� �Ǹ� �� �ΰ����� ���� ���������� ����
        {
            //GetComponent<MeshRenderer>().materials[0].color = Color.red;
            //Debug.Log("50������");
            if(blinkTimer >= 1f)
            {
                //�� ����
                if(isBlink == 0)
                {
                    ChangeRed();
                }
                else
                {
                    ChangeWhite();
                }

                //�ð� �ʱ�ȭ
                blinkTimer = 0f;
            }
        }
        else if (timer >= 30f)//�ӽ÷� 50�ʰ� �Ǹ� �� �ΰ����� ���� ���������� ����
        {
            //Debug.Log("30������");
            GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
        }
    }

    private void ChangeRed()
    {
        GetComponent<MeshRenderer>().materials[0].color = Color.red;
        isBlink = 1;
    }

    private void ChangeWhite()
    {
        GetComponent<MeshRenderer>().materials[0].color = Color.white;
        isBlink = 0;
    }
}
