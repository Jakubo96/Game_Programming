using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static WaveCounter instance;

    private int enemiesKilled = 0;
    private int currentWave = 1;

    private Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        scoreText = GameObject.FindWithTag(Tags.SCORE).GetComponent<Text>();
    }

    public void EnemyKilled()
    {
        StatisticsModifier.instance.IncreasePlayerStats();
        
        if (IsWaveFinished(++enemiesKilled))
        {
            StatisticsModifier.instance.HealPlayer();
            
            StartCoroutine(EnemyManager.instance.SpawnEnemies(++currentWave));
            scoreText.text = string.Format("Fala: {0}", currentWave);
        }
    }

    private bool IsWaveFinished(int count)
    {
        var i = 0;
        var numberToAdd = 1;
        while (i <= count)
        {
            if (i == count)
            {
                return true;
            }

            i += numberToAdd;
            numberToAdd += 1;
        }

        return false;
    }
}