using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

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

    public IEnumerator SpawnEnemies(int currentWave)
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