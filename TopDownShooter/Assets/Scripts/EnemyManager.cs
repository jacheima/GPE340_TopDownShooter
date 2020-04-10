using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberAllowedInLevel;

    [SerializeField] private Transform spawnLocation;

    public List<GameObject> enemiesInLevel;
    public bool spawnNotStarted = true;

    private float spawnStartTime;
    public float waitTime;

    private void Start()
    {
        enemiesInLevel = new List<GameObject>();
        spawnNotStarted = true;
        waitTime = 2f;
    }

    private void Update()
    {
        if (enemiesInLevel.Count < numberAllowedInLevel)
        {
            if(Time.time >= spawnStartTime + waitTime)
            {
                SpawnEnemy();
            }

            return;
        }
        if (enemiesInLevel.Count >= numberAllowedInLevel)
        {
            spawnNotStarted = true;
        }
    }

    public void SpawnEnemy()
    {
        spawnStartTime = Time.time;

        GameObject enemy = Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
        enemiesInLevel.Add(enemy);
        enemy.name = "Enemy_" + enemiesInLevel.Count;
    }
}
