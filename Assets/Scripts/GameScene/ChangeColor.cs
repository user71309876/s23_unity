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
        if (timer >= 50f)//임시로 50초가 되면 적 인공위성 색이 빨간색으로 변함
        {
            //Debug.Log("50초지남");
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (timer >= 30f)//임시로 50초가 되면 적 인공위성 색이 빨간색으로 변함
        {
            //Debug.Log("30초지남");
            GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
        }
    }
}
