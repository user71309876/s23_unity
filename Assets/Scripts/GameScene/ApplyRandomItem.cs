using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomItem : MonoBehaviour
{
    public void ApplyRandomItemOnEnemyDefeat()
    {
        // Find all Tower objects with the specified tag
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        // Filter out Tower objects with LeftLauncher inactive
        List<GameObject> inactiveTowers = new List<GameObject>();
        foreach (GameObject tower in towers)
        {
            Transform leftLauncher = tower.transform.Find("LeftLauncher");
            if (leftLauncher != null && !leftLauncher.gameObject.activeSelf)
            {
                inactiveTowers.Add(tower);
            }
        }
        
        // Activate LeftLauncher for a randomly selected Tower
        if (inactiveTowers.Count > 0)
        {
            GameObject randomTower = inactiveTowers[Random.Range(0, inactiveTowers.Count)];
            Transform leftLauncher = randomTower.transform.Find("LeftLauncher");

            if (leftLauncher != null)
            {
                leftLauncher.gameObject.SetActive(true);
                Debug.Log("랜덤 아이템을 획득하여 타워의 공격 횟수가 증가되었습니다.");
            }
        }
    }
}
