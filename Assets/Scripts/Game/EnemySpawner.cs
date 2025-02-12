using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    private void Awake() { Instance = this; }


    public List<GameObject> prefabs;
    public List<Transform> SpawnPoints;
    public float spawnInterval = 2f;

    private int enemyCount;
    private float enemySpeed;

    public void StartSpawning(int count, float speed)
    {
        enemyCount = count;
        enemySpeed = speed;
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, SpawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], SpawnPoints[randomSpawnPointID]);

        // Устанавливаем скорость врага
        spawnedEnemy.GetComponent<Enemy>().moveSpeed = enemySpeed;
    }

}
