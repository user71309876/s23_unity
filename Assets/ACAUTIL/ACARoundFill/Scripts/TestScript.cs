
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
