using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject m_goMissile = null; // 미사일 프리팹 변수 선언

    [SerializeField] Transform m_tfMissileSpawn = null;//발사된 위치 변수 선언

    [SerializeField] float currentDamage = 1f;

    [SerializeField] float currentSpeed = 2f;

    private float powerUp = 1f;
    private float speedUp = 0.5f;

    private void Start()
    {
        StartCoroutine(MissileLaunch());
    }

    public void ApplyAttackPower()
    {
        currentDamage += powerUp;
    }

    public void ApplyAttckSpeed()
    {
        currentSpeed -= speedUp;
    }

    private IEnumerator MissileLaunch()
    {
        while (true)
        {
            if(HasTarget())
            {
                //미사일 생성
                GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, Quaternion.identity);

                t_missile.GetComponent<Missile>().SetDamage(currentDamage);

                //위로 퉁날림
                t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;
            }
            

            yield return new WaitForSeconds(currentSpeed); // 현재 속도에 맞춰서 날림
        }
    }

    private bool HasTarget()    // 목표 확인
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, LayerMask.GetMask("EnemyLayer"));

        return (colliders.Length > 0);
    }
}
