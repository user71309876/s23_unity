using System.Linq;
using UnityEngine;

public class SlowDownTower : MonoBehaviour
{
    //public LayerMask enemyLayer;
    private float slowRadius = 3.5f;
    public float slowFactor = 0.5f;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, slowRadius, LayerMask.GetMask("EnemyLayer"));

        foreach (Collider collider in colliders)
        {
            EnemyRotateRound enemyRotate = collider.GetComponent<EnemyRotateRound>();

            if (enemyRotate != null)
            {
                // 적의 속도를 느리게 만들기
                enemyRotate.ApplySlow(slowFactor);
            }
        }

        EnemyRotateRound[] allEnemies = GameObject.FindObjectsOfType<EnemyRotateRound>();

        foreach (EnemyRotateRound enemy in allEnemies)
        {
            if (!colliders.Contains(enemy.GetComponent<Collider>()))
            {
                // Enemy is outside the slow radius
                enemy.CancelSlow();
            }
        }
    }
}
