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
            // Attack Power Up�� ���� ó��
        }
        else if (buttonText == "Attack Speed Up")
        {
            // Attack Speed Up�� ���� ó��
        }
    }

    void AddTower()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        // �� Ÿ���� ������ ����Ʈ
        var emptyTiles = new List<GameObject>();

        foreach (var tile in tiles)
        {
            // Ÿ�� ���� �ٸ� ������Ʈ�� ������ �� Ÿ�� ����Ʈ�� �߰�
            if (!HasObjectOnTile(tile))
            {
                emptyTiles.Add(tile);
            }
        }

        // �� Ÿ���� ������ �Լ� ����
        if (emptyTiles.Count == 0)
        {
            Debug.Log("No empty tiles available.");
            return;
        }

        // �� Ÿ�� �� �������� ����
        GameObject randomTile = emptyTiles[Random.Range(0, emptyTiles.Count)];

        // Ÿ���� �������� ���õ� Ÿ���� ��ġ�� ����
        Instantiate(towerPrefab, randomTile.transform.position, Quaternion.identity);
        Debug.Log("Ÿ�� ��ġ �Ϸ�");
    }

    bool HasObjectOnTile(GameObject tile)   // ���� �ʿ�##############
    {
        // �ش� Ÿ�� ���� �ٸ� ������Ʈ�� �ִ��� üũ
        Collider2D[] colliders = Physics2D.OverlapCircleAll(tile.transform.position, tile.GetComponent<CircleCollider2D>().radius, 0);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != tile)
            {
                // �ٸ� ������Ʈ�� �ִ� ��� true ��ȯ
                return true;
            }
        }

        // �ٸ� ������Ʈ�� ���� ��� false ��ȯ
        return false;
    }
}
