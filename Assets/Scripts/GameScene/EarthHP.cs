using DG.Tweening;
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
    private Transform earthTransform;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        hp_splider.value = hp_splider.maxValue;
        targetEarthHP = hp_splider.value;

        earthTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
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
            ShakeEarth();
            targetEarthHP--;
            Destroy(collision.gameObject);
        }
    }

    void ShakeEarth()
    {
        earthTransform.DOShakePosition(1f, strength: 0.3f, vibrato: 15, randomness: 90, fadeOut: false);
    }

    void SpawnExplosions(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.onUnitSphere * 5f;
            Instantiate(explosionPrefab, earthTransform.position + randomOffset, Quaternion.identity);
        }
    }

    public void gameOver()
    {
        SpawnExplosions(10);
        gameOverUI.SetActive(true);
    }
}
