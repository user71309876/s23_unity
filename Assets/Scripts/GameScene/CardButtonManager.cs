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
    }

    void ApplyAttackSpeedUp()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if (towers.Length == 0)
        {
            Debug.Log("적용할 타워가 없습니다 (ApplyAttackSpeedUp)");
            return;
        }

        GameObject randomTower = towers[Random.Range(0, towers.Length)];

        MissileLauncher missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if (missileLauncher != null)
        {
            missileLauncher.ApplyAttckSpeed();
            Debug.Log("타워 공격속도 증가 적용 완료");
        }
    }

    void ApplyAttackPowerUp()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if(towers.Length == 0)
        {
            Debug.Log("적용할 타워가 없습니다 (ApplyAttackPowerUp)");
            return;
        }

        GameObject randomTower = towers[Random.Range(0, towers.Length)];
        
        MissileLauncher missileLauncher = randomTower.GetComponent<MissileLauncher>();

        if(missileLauncher != null)
        {
            missileLauncher.ApplyAttackPower();
            Debug.Log("타워 공격력 증가 적용 완료");
        }
    }

    void AddTower()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        // 빈 타일을 저장할 리스트
        var emptyTiles = new List<GameObject>();

        foreach (var tile in tiles)
        {
            // 타일 위에 다른 오브젝트가 없으면 빈 타일 리스트에 추가
            if (!HasObjectOnTile(tile))
            {
                emptyTiles.Add(tile);
            }
        }

        // 빈 타일이 없으면 함수 종료
        if (emptyTiles.Count == 0)
        {
            Debug.Log("No empty tiles available.");
            return;
        }

        // 빈 타일 중 랜덤으로 선택
        GameObject randomTile = emptyTiles[Random.Range(0, emptyTiles.Count)];

        // 타워를 랜덤으로 선택된 타일의 위치에 생성
        Instantiate(towerPrefab, randomTile.transform.position, Quaternion.identity);
        Debug.Log("타워 배치 완료");
    }

    bool HasObjectOnTile(GameObject tile)   // 수정 필요##############
    {
        // 해당 타일 위에 다른 오브젝트가 있는지 체크
        Collider2D[] colliders = Physics2D.OverlapCircleAll(tile.transform.position, tile.GetComponent<CircleCollider2D>().radius, 0);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != tile)
            {
                // 다른 오브젝트가 있는 경우 true 반환
                return true;
            }
        }

        // 다른 오브젝트가 없는 경우 false 반환
        return false;
    }
}
