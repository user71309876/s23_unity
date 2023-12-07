using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public ImgsFillDynamic ImgsFD;
    private float increaseInterval = 1.0f;
    private float timeSinceLastIncrease = 0.0f;

    private PushFeverButton pushFeverButton;

    private void Start()
    {
        pushFeverButton = GameObject.Find("FeverButton").GetComponent<PushFeverButton>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (!pushFeverButton.GetFeverTime())
            {
                ImgsFD.SetValue(ImgsFD.GetValue() + 0.2f);
            }
        }

        timeSinceLastIncrease += Time.deltaTime;
        if(timeSinceLastIncrease >= increaseInterval)
        {
            if (!pushFeverButton.GetFeverTime())
            {
                this.ImgsFD.SetValue(this.ImgsFD.GetValue() + 0.01f);
                timeSinceLastIncrease = 0.0f;
            }
        }
    }

}
