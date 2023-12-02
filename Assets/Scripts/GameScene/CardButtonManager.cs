using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardButtonManager : MonoBehaviour
{
    public GameObject towerPrefab;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => HandleButtonOnClick(button));
    }

    public void HandleButtonOnClick(Button button)
    {
        Debug.Log("Button Clicked: " + button.name);
        string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;

        if (buttonText == "Add Tower")
        {
            AddTower();
        }
        else if (buttonText == "Attack Power Up")
        {
            ApplyAttackPowerUp();
        }
        else if (buttonText == "Attack Speed Up")
        {
            ApplyAttackSpeedUp();
        }
        SFXManager.instance.playSFXSound("Button");
    }

    void ApplyAttackSpeedUp()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if (towers.Length == 0)
        {
            Debug.Log("공격속도 증가 대상 없음");
            return;
        }

        GameObject randomTower = towers[Random.Range(0, towers.Length)];

        MissileLauncher missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if (missileLauncher != null)
        {
            missileLauncher.ApplyAttckSpeed();
            Debug.Log("공격속도 증가 적용");
        }
    }

    void ApplyAttackPowerUp()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if(towers.Length == 0)
        {
            Debug.Log("공격력 증가 대상 없음");
            return;
        }

        GameObject randomTower = towers[Random.Range(0, towers.Length)];
        
        MissileLauncher missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if(missileLauncher != null)
        {
            missileLauncher.ApplyAttackPower();
            Debug.Log("공격력 증가 적용");
        }
    }

    void AddTower()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        var emptyTiles = new List<GameObject>();

        foreach (var tile in tiles)
        {
            if (!HasObjectOnTile(tile))
            {
                emptyTiles.Add(tile);
            }
        }

        // 빈 타일 존재 하지 않음
        if (emptyTiles.Count == 0)
        {
            Debug.Log("No empty tiles available.");
            return;
        }

        GameObject randomTile = emptyTiles[Random.Range(0, emptyTiles.Count)];

        // 랜덤 타일 위에 타워 추가
        Instantiate(towerPrefab, randomTile.transform.position, Quaternion.identity);
        Debug.Log("타워 추가 완료");
    }

    bool HasObjectOnTile(GameObject tile)   // 타일 위에 타워 체크
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(tile.transform.position, tile.GetComponent<CircleCollider2D>().radius, 0);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != tile)
            {
                return true;
            }
        }

        return false;
    }
}
