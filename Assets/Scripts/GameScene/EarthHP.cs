using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EarthHP : MonoBehaviour
{
    [SerializeField] Slider hp_splider;
    public GameObject gameOverUI;
    public TMP_Text earthHP;
    private float targetEarthHP;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        hp_splider.value = hp_splider.maxValue;
        targetEarthHP = hp_splider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))   // �ӽ÷� �����̽� �� ���� �� ����ġ 30 ȹ��
        {
            gameOver();
        }
        if (hp_splider.value <= 0)
        {
            Time.timeScale = 0f;
            gameOver();
        }

        else if (hp_splider.value >= targetEarthHP)
        {
            hp_splider.value -= 2.0f * Time.deltaTime;
            
            earthHP.text = (Mathf.FloorToInt(hp_splider.value * 20f) + 1).ToString();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            targetEarthHP--;
            Destroy(collision.gameObject);//�ΰ����� �ı�
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
