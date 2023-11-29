using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject m_goMissile = null; // �̻��� ������ ���� ����

    [SerializeField] Transform m_tfMissileSpawn = null;//�߻�� ��ġ ���� ����

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
                //�̻��� ����
                GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, Quaternion.identity);

                t_missile.GetComponent<Missile>().SetDamage(currentDamage);

                //���� ������
                t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;
            }
            

            yield return new WaitForSeconds(currentSpeed); // ���� �ӵ��� ���缭 ����
        }
    }

    private bool HasTarget()    // ��ǥ Ȯ��
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, LayerMask.GetMask("EnemyLayer"));

        return (colliders.Length > 0);
    }
}
