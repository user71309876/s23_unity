using UnityEngine;

public class TowerPlacementManager : MonoBehaviour
{
    private GameObject[] tiles;
    private int[] towerStatus;

    private int towerMaximum = 10;

    void Start()
    {
        InitializeTowerStatus();
        UpdateTowerStatus();
    }

    // Ÿ�ϰ� Ÿ�� ��Ȳ �ʱ�ȭ
    void InitializeTowerStatus()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        towerStatus = new int[tiles.Length];
        for (int i = 0; i < towerStatus.Length; i++)
        {
            towerStatus[i] = 0;
        }
    }

    // Ÿ�� ��Ȳ ������Ʈ
    public void UpdateTowerStatus()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach (GameObject tower in towers)
        {
            int tileIndex = GetTileIndex(tower.transform.position);

            if (tileIndex != -1)
            {
                towerStatus[tileIndex] = 1;
            }
        }
    }

    // Ÿ�� �ε��� ��ȯ
    int GetTileIndex(Vector3 position)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (Vector3.Distance(position, tiles[i].transform.position) < 0.1f)
            {
                return i;
            }
        }
        return -1;
    }

    public bool IsPlacedTowerCountExceedsLimit()
    {
        int count = 0;

        for (int i = 0; i < towerStatus.Length; i++)
        {
            if (towerStatus[i] == 1)
            {
                count++;
            }
        }

        if (count > towerMaximum)
        {
            Debug.Log("Ÿ�� ���� �Ѱ�ġ ����");
            return true;
        }

        return false;
    }
}
