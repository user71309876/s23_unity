using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject m_goMissile = null; // �̻��� ������ ���� ����

    [SerializeField] Transform m_tfMissileSpawn = null;//�߻�� ��ġ ���� ����
    private void Start()
    {
        StartCoroutine(MissileLaunch());
    }

    private IEnumerator MissileLaunch()
    {
        while (true)
        {
            //�̻��� ����
            GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, Quaternion.identity);

            //���� ������
            t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;

            yield return new WaitForSeconds(1.5f); // 1.5�� �Ŀ� �ٽ� ���� ���⼭ ���� �ӵ� ����
        }
    }
}
