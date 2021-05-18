using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public GameObject goal;

    private List<GameObject> inactivEnemyPool;

    public float SpawnInterval;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        inactivEnemyPool = new List<GameObject>();
        spawnTimer = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEmeny();
            spawnTimer = SpawnInterval;
        }
    }

    private void SpawnEmeny()
    {
        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject go = GetInactiveEnemy();
        go.transform.position = spawn.position;

        Enemy enemy = go.GetComponent<Enemy>();
        enemy.spawner = this;
        enemy.hitPoints = 10;

        go.SetActive(true);

        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        agent.destination = this.goal.transform.position;
    }

    private GameObject GetInactiveEnemy()
    {
        if (inactivEnemyPool.Count == 0)
        {
            CreateEnemys(10);
        }

        GameObject enemy = inactivEnemyPool[0];
        inactivEnemyPool.Remove(enemy);
        return enemy;
    }

    private void CreateEnemys(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab);
            enemy.SetActive(false);

            inactivEnemyPool.Add(enemy);
        }
    }

    public void AddToInactivePool(GameObject go)
    {
        inactivEnemyPool.Add(go);
    }
}
