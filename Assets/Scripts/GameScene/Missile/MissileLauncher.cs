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

    [SerializeField] Transform m_tfMissileSpawn = null; // 미사일 스폰

    [SerializeField] float currentDamage = 1f;

    public float currentSpeed = 2f;

    private float powerUp = 1f;
    private float speedUp = 0.5f;
    private Animation ani;

    private void Start()
    {
        m_goMissile = missilePrefabLowDamage;
        StartCoroutine(MissileLaunch());
        ani=this.GetComponent<Animation>();
    }

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
    }

    private IEnumerator MissileLaunch()
    {
        while (true)
        {
            GameObject earthObject = GameObject.FindGameObjectWithTag("Earth");

            if(HasTarget())
            {
                // 
                Quaternion rotationtoEarth = Quaternion.LookRotation(earthObject.transform.position - m_tfMissileSpawn.position);
                // 
                GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, rotationtoEarth * Quaternion.Euler(90, 0, 0));

                // FlameParticle
                ParticleSystem flameParticle = t_missile.GetComponentInChildren<ParticleSystem>();
                if (flameParticle != null)
                {
                    var mainModule = flameParticle.main;

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

                t_missile.GetComponent<Missile>().SetDamage(currentDamage);
                Debug.Log("lunch!!!");
                ani.Play("LunchOnce");
                //t_missile.GetComponent<Rigidbody>().velocity = Vector3.forward * 3f;
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
