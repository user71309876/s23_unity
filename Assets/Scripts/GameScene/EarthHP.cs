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
    public ParticleSystem explosionParticle;
    [SerializeField] private TMP_Text exp;
    [SerializeField] private TMP_Text user_name;

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
            Vector3 randomOffset = Random.onUnitSphere * 2f;
            Instantiate(explosionParticle, earthTransform.position + randomOffset, Quaternion.identity);
        }
    }

    public void gameOver()
    {
        SpawnExplosions(1);

        StartCoroutine(DelayBeforeGameOverUI());

        // int temp=1;
        // while(!PlayerPrefs.HasKey(temp.ToString())){
        //     temp++;
        // }
        // PlayerPrefs.SetInt(temp.ToString(),int.Parse(exp.text));
        // PlayerPrefs.SetString(temp.ToString(),user_name.text);
    }

    public void savePoint(){
        int temp=1;
        int result;
        // Debug.Log(PlayerPrefs.HasKey(temp.ToString()));
        while(PlayerPrefs.HasKey(temp.ToString())){
            temp++;
        }
        int.TryParse(exp.text,out result);

        PlayerPrefs.SetInt(temp.ToString(),result);
        PlayerPrefs.SetString(temp.ToString()+"S",user_name.text);
        // Debug.Log(PlayerPrefs.GetInt(temp.ToString()));
        // Debug.Log(PlayerPrefs.GetString(temp.ToString()+"S"));
        // Debug.Log(result.ToString()+user_name.text);
    }

    private IEnumerator DelayBeforeGameOverUI()
    {
        yield return new WaitForSeconds(3f);

        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
