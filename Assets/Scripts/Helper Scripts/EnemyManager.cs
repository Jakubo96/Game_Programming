using System;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private int enemiesKilled = 0;
    private int currentWave = 1;

    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void EnemyKilled()
    {
        if (IsWaveFinished(++enemiesKilled))
        {
            ++currentWave;
            StartCoroutine(SpawnEnemies());
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

    private IEnumerator SpawnEnemies()
    {
        for (var i = 0; i < currentWave; ++i)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}