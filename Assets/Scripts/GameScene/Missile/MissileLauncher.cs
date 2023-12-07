using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class MissileLauncher : MonoBehaviour
{
    private GameObject m_goMissile = null; // 미사일 프리팹
    [SerializeField] GameObject missilePrefabLowDamage = null;
    [SerializeField] GameObject missilePrefabMediumDamage = null;
    [SerializeField] GameObject missilePrefabHighDamage = null;

    //[SerializeField] Transform m_tfMissileSpawn = null; // 스폰 장소
    [SerializeField] Transform m_leftMissileSpawn = null;   // Left Missile Spawn
    [SerializeField] Transform m_rightMissileSpawn = null;  // Right Missile Spawn

    [SerializeField] float currentDamage = 1f;

    public float currentSpeed = 2f;

    private float powerUp = 1f;
    private float speedUp = 0.5f;
    private Animator animator;
<<<<<<< Updated upstream

    /*
    공격모션 바꾸는 방법
    animator.SetInteger("AttackMode",0); -> 오른쪽팔만 공격, 기본값
    animator.SetInteger("AttackMode",1); -> 양쪽팔이 번갈아가며 공격
    animator.SetInteger("AttackMode",2); -> 양쪽팔이 동시에 공격
    */
=======
>>>>>>> Stashed changes

    private void Start()
    {
        m_goMissile = missilePrefabLowDamage;
        StartCoroutine(MissileLaunch());
        animator=gameObject.GetComponent<Animator>();
    }

    /*
    런처 애니메이션 바꿀때 다음과 같은 방법을 사용하시면 됩니다
    animator.SetInteger("LunchMode",0); => 오른쪽팔만 발사, 기본값
    animator.SetInteger("LunchMode",1); => 두 팔이 다른 타이밍에 발사
    animator.SetInteger("LunchMode",2); => 두 팔이 같은 타이밍에 발사
    */

    public void ApplyAttackPower()
    {
        currentDamage += powerUp;

        if (currentDamage < 3f)
        {
            m_goMissile = missilePrefabLowDamage;
        }
        else if(currentDamage < 6f)
        {
            m_goMissile = missilePrefabMediumDamage;
        }
        else
        {
            m_goMissile = missilePrefabHighDamage;
        }
    }

    public void ApplyAttckSpeed()
    {
        currentSpeed -= speedUp;
<<<<<<< Updated upstream
        animator.SetFloat("AttackSpeed",currentSpeed/2f);
=======
        animator.SetFloat("LunchSpeed",currentSpeed/2f);
        Debug.Log(currentSpeed);
>>>>>>> Stashed changes
    }

    // Set the tower's missile launch locations to 2
    // Implement missile launch for each
    private IEnumerator MissileLaunch()
    {
        while (true)
        {
            GameObject earthObject = GameObject.FindGameObjectWithTag("Earth");

            if(HasTarget())
            {
                Quaternion rightToEarth = Quaternion.LookRotation(earthObject.transform.position - m_leftMissileSpawn.position);
                Quaternion leftToEarth = Quaternion.LookRotation(earthObject.transform.position - m_rightMissileSpawn.position);

                // Check left missile object activation
                if (m_leftMissileSpawn.gameObject.activeSelf)
                {
                    GameObject leftMissile = Instantiate(m_goMissile, m_leftMissileSpawn.position, leftToEarth * Quaternion.Euler(90, 0, 0));

                    ParticleSystem leftFlameParticle = leftMissile.GetComponentInChildren<ParticleSystem>();
                    if (leftFlameParticle != null)
                    {
                        var mainModule = leftFlameParticle.main;

                        if (currentSpeed < 1.0f)
                        {
                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(0f / 255f, 247f / 255f, 250f / 255f, 158f / 255f),
                                new Color(0f / 255f, 0f / 255f, 0f, 143f / 255f)
                            );
                        }
                        else if (currentSpeed < 1.5f)
                        {
                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(234f / 255f, 0f / 255f, 250f / 255f, 158f / 255f),
                                new Color(255f / 255f, 255f / 255f, 255f, 143f / 255f)
                            );
                        }
                        else if (currentSpeed < 2.0f)
                        {

                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(255f / 255f, 204f / 255f, 13f / 255f, 158f / 255f),
                                new Color(255f / 255f, 109f / 255f, 0f, 143f / 255f)
                            );
                        }
                    }
                    leftMissile.GetComponent<Missile>().SetDamage(currentDamage);
                }

                // Check right missile object activation
                if (m_rightMissileSpawn.gameObject.activeSelf)
                {
                    GameObject rightMissile = Instantiate(m_goMissile, m_rightMissileSpawn.position, rightToEarth * Quaternion.Euler(90, 0, 0));

                    ParticleSystem rightFlameParticle = rightMissile.GetComponentInChildren<ParticleSystem>();
                    if (rightFlameParticle != null)
                    {
                        var mainModule = rightFlameParticle.main;

                        if (currentSpeed < 1.0f)
                        {
                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(0f / 255f, 247f / 255f, 250f / 255f, 158f / 255f),
                                new Color(0f / 255f, 0f / 255f, 0f, 143f / 255f)
                            );
                        }
                        else if (currentSpeed < 1.5f)
                        {
                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(234f / 255f, 0f / 255f, 250f / 255f, 158f / 255f),
                                new Color(255f / 255f, 255f / 255f, 255f, 143f / 255f)
                            );
                        }
                        else if (currentSpeed < 2.0f)
                        {

                            mainModule.startColor = new ParticleSystem.MinMaxGradient(
                                new Color(255f / 255f, 204f / 255f, 13f / 255f, 158f / 255f),
                                new Color(255f / 255f, 109f / 255f, 0f, 143f / 255f)
                            );
                        }
                    }
                    rightMissile.GetComponent<Missile>().SetDamage(currentDamage);
                }
                animator.SetTrigger("Attack");
                // 위로 퉁 쏘아올리는 동작
                //t_missile.GetComponent<Rigidbody>().velocity = Vector3.forward * 3f;
<<<<<<< Updated upstream
=======
                animator.SetTrigger("Lunch");
>>>>>>> Stashed changes
            }
            
            yield return new WaitForSeconds(currentSpeed); // attack speed
        }
    }

    private bool HasTarget()    // Detect target
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("EnemyLayer"));

        return (colliders.Length > 0);
    }
}
