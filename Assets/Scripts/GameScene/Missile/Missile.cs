using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody m_rigid = null;//리지드바디 변수
    Transform m_tfTarget = null;//표적 변수

    [SerializeField] float m_speed = 0f;//최고속도
    float m_currentSpeed = 0f;//현재속도
    [SerializeField] LayerMask m_layerMask = 0;//원하는 레이어검출하는 마스크
    //[SerializeField] ParticleSystem m_psEffect = null;//파티클 시스템 변수

    GameObject level_event;

    private float damage = 1f;

    public void SetDamage(float newdamage)
    {
        damage = newdamage;
    }

    void SearchEnemy()//표적 탐색 함수
    {
        //100미터 이내의 특정 콜라이더 검출
        Collider[] t_cols = Physics.OverlapSphere(transform.position, 100f, m_layerMask);

        //검출된 것들중 하나를 랜덤으로 표적으로 설정
        if (t_cols.Length > 0)
        {
            m_tfTarget = t_cols[Random.Range(0, t_cols.Length)].transform;
        }
    }

    IEnumerator LaunchDelay()
    {
        //속력이 0보다 떨어지게 되면 0.1초 대기후 표적 탐색
        yield return new WaitUntil(() => m_rigid.velocity.y < 0f);
        yield return new WaitForSeconds(0.1f);
        SearchEnemy();
        //m_psEffect.Play();

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        StartCoroutine(LaunchDelay());

        level_event = GameObject.Find("LevelUpEvent");
    }

    void Update()
    {
        if (m_tfTarget != null)//표적이 있을 경우
        {
            //현재 속도가 최고속도보다 느리다면 계속 가속 시켜줄 것
            if (m_currentSpeed <= m_speed)
                m_currentSpeed += m_speed * Time.deltaTime;

            //미사일을 가속시킬 것
            transform.position += transform.up * m_currentSpeed * Time.deltaTime;

            //표적위치 - 미사일 위치 => 방향과 거리 계산이지만 거리는 의미없어서 normalized로 방향만 계산
            Vector3 t_dir = (m_tfTarget.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, t_dir, 0.25f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }

    void ApplyDamageToEnemy(GameObject enemy)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            enemyController.TakeDamage(damage);
        }
    }
}
