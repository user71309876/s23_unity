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
        if (timer >= 50f)//임시로 50초가 되면 적 인공위성 색이 빨간색으로 변함
        {
            //GetComponent<MeshRenderer>().materials[0].color = Color.red;
            //Debug.Log("50초지남");
            if(blinkTimer >= 1f)
            {
                //색 변경
                if(isBlink == 0)
                {
                    ChangeRed();
                }
                else
                {
                    ChangeWhite();
                }

                //시간 초기화
                blinkTimer = 0f;
            }
        }
        else if (timer >= 30f)//임시로 50초가 되면 적 인공위성 색이 빨간색으로 변함
        {
            //Debug.Log("30초지남");
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
