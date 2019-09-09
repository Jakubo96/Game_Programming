using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    public static WaveCounter instance;

    private int enemiesKilled = 0;
    private int currentWave = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void EnemyKilled()
    {
        if (IsWaveFinished(++enemiesKilled))
        {
            StartCoroutine(EnemyManager.instance.SpawnEnemies(++currentWave));
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