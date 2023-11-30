using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody m_rigid = null;//������ٵ� ����
    Transform m_tfTarget = null;//ǥ�� ����

    [SerializeField] float m_speed = 0f;//�ְ��ӵ�
    float m_currentSpeed = 0f;//����ӵ�
    [SerializeField] LayerMask m_layerMask = 0;//���ϴ� ���̾�����ϴ� ����ũ
    //[SerializeField] ParticleSystem m_psEffect = null;//��ƼŬ �ý��� ����

    GameObject level_event;

    private float damage = 1f;

    public void SetDamage(float newdamage)
    {
        damage = newdamage;
    }

    void SearchEnemy()//ǥ�� Ž�� �Լ�
    {
        //100���� �̳��� Ư�� �ݶ��̴� ����
        Collider[] t_cols = Physics.OverlapSphere(transform.position, 100f, m_layerMask);

        //����� �͵��� �ϳ��� �������� ǥ������ ����
        if (t_cols.Length > 0)
        {
            m_tfTarget = t_cols[Random.Range(0, t_cols.Length)].transform;
        }
    }

    IEnumerator LaunchDelay()
    {
        //�ӷ��� 0���� �������� �Ǹ� 0.1�� ����� ǥ�� Ž��
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
        if (m_tfTarget != null)//ǥ���� ���� ���
        {
            //���� �ӵ��� �ְ��ӵ����� �����ٸ� ��� ���� ������ ��
            if (m_currentSpeed <= m_speed)
                m_currentSpeed += m_speed * Time.deltaTime;

            //�̻����� ���ӽ�ų ��
            transform.position += transform.up * m_currentSpeed * Time.deltaTime;

            //ǥ����ġ - �̻��� ��ġ => ����� �Ÿ� ��������� �Ÿ��� �ǹ̾�� normalized�� ���⸸ ���
            Vector3 t_dir = (m_tfTarget.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, t_dir, 0.25f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            //Debug.Log("�ı�");
            Destroy(gameObject);//�̻��� �ı�
            
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
