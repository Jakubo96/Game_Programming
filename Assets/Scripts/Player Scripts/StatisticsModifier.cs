using UnityEngine;

public class StatisticsModifier : MonoBehaviour
{
    public static StatisticsModifier instance;
    
    public GameObject leftArmAttackPoint;
    public GameObject rightArmAttackPoint;
    public GameObject leftLegAttackPoint;
    public GameObject rightLegAttackPoint;

    public GameObject player;

    public float statsBoost = 1.15f;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    
    public void IncreasePlayerStats()
    {
        if(Random.Range(0,2) > 0)
        {
            print("Increase damage");
            IncreasePlayerDamage();
        }
        else
        {
            print("Increase speed");
            IncreasePlayerSpeed();
        }
    }

    private void IncreasePlayerDamage()
    {
        leftArmAttackPoint.GetComponent<AttackDetection>().damage *= statsBoost;
        rightArmAttackPoint.GetComponent<AttackDetection>().damage *= statsBoost;
        leftLegAttackPoint.GetComponent<AttackDetection>().damage *= statsBoost;
        rightLegAttackPoint.GetComponent<AttackDetection>().damage *= statsBoost;
    }

    private void IncreasePlayerSpeed()
    {
        player.GetComponent<PlayerMovement>().walkSpeed *= statsBoost;
        player.GetComponent<PlayerMovement>().zSpeed *= statsBoost;
    }
    
    public void HealPlayer()
    {
        var playerHealth = player.GetComponent<HealthScript>().health;
        playerHealth *= statsBoost;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        player.GetComponent<HealthScript>().health = playerHealth;
        player.GetComponent<HealthUI>().DisplayHealth(playerHealth);
    }
}
