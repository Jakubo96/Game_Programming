using System;
using System.Collections;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint;
    public GameObject rightArmAttackPoint;
    public GameObject leftLegAttackPoint;
    public GameObject rightLegAttackPoint;

    public float standUpTimer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;
    
    [SerializeField] private AudioClip whooshSound;
    [SerializeField] private AudioClip fallSound;
    [SerializeField] private AudioClip groundHitSound;
    [SerializeField] private AudioClip deathSound;

    private EnemyMovement enemyMovement;

    private ShakeCamera shakeCamera;

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }

    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    void LeftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void LeftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    void RightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void RightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void TagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG__TAG;
    }

    void UnTagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animationScript.StandUp();
    }

    void AttackSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    void DeathSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deathSound;
        audioSource.Play();
    }   
    
    void KnockDownSound()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }    
    
    void HitGroundSound()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemyMovement.enabled = false;

        transform.parent.gameObject.layer = 0;
    }

    void EnableMovement()
    {
        enemyMovement.enabled = true;

        transform.parent.gameObject.layer = 10;
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }
}