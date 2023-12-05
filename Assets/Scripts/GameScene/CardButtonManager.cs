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
        MissileLauncher missileLauncher = null;

        if (towers.Length == 0)
        {
            Debug.Log("타워를 찾을 수 없습니다.");
            return;
        }

        // 공격속도 0.5s 이상인 타워에만 적용
        List<GameObject> eligibleTowers = new List<GameObject>();

        foreach (GameObject tower in towers)
        {
            missileLauncher = tower.GetComponent<MissileLauncher>();
            if (missileLauncher != null && missileLauncher.currentSpeed > 0.5f)
            {
                eligibleTowers.Add(tower);
            }
        }

        if (eligibleTowers.Count == 0)
        {
            Debug.Log("공격 속도를 업그레이드할 수 있는 타워가 없습니다.");
            return;
        }

        GameObject randomTower = eligibleTowers[Random.Range(0, eligibleTowers.Count)];

        missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if (missileLauncher != null)
        {
            missileLauncher.ApplyAttckSpeed();
            Debug.Log("타워의 공격 속도가 업그레이드되었습니다: " + randomTower.name);
        }
    }


    void ApplyAttackPowerUp()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if(towers.Length == 0)
        {
            Debug.Log("공격력을 증가할 수 있는 타워가 없습니다.");
            return;
        }

        GameObject randomTower = towers[Random.Range(0, towers.Length)];
        
        MissileLauncher missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if(missileLauncher != null)
        {
            missileLauncher.ApplyAttackPower();
            Debug.Log("타워의 공격력이 업그레이드 되었습니다: " + randomTower.name);
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
            Debug.Log("배치할 수 있는 타일이 존재하지 않습니다");
            return;
        }

        GameObject randomTile = emptyTiles[Random.Range(0, emptyTiles.Count)];

        // 랜덤 타일 위에 타워 추가
        Instantiate(towerPrefab, randomTile.transform.position, Quaternion.identity);
        Debug.Log("타워 추가 완료되었습니다");
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
