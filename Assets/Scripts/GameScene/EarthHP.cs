using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthHP : MonoBehaviour
{
    [SerializeField] Slider hp_splider;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        hp_splider.value = hp_splider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp_splider.value <= 0)
        {
            Time.timeScale = 0f;
            gameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            hp_splider.value--;
            Destroy(collision.gameObject);//인공위성 파괴
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
