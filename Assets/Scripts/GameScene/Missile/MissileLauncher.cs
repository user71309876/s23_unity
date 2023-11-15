using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject m_goMissile = null; // 미사일 프리팹 변수 선언

    [SerializeField] Transform m_tfMissileSpawn = null;//발사된 위치 변수 선언
    private void Start()
    {
        StartCoroutine(MissileLaunch());
    }

    private IEnumerator MissileLaunch()
    {
        while (true)
        {
            //미사일 생성
            GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, Quaternion.identity);

            //위로 퉁날림
            t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;

            yield return new WaitForSeconds(1.5f); // 1.5초 후에 다시 날림 여기서 공격 속도 조절
        }
    }
}
