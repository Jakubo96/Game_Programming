using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDead;

    public bool isPlayer;

    private HealthUI healthUI;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        if (isPlayer)
        {
            healthUI = GetComponent<HealthUI>();
        }
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDead)
        {
            return;
        }

        health -= damage;

        if (isPlayer)
        {
            healthUI.DisplayHealth(health);
        }

        if (health <= 0f)
        {
            animationScript.Death();
            characterDead = true;

            if (isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
                WaveCounter.instance.GameOver();
            }

            return;
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
                else
                {
                    if (Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
        }
    }
}