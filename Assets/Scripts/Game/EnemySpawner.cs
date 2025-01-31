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

    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());


    }

    IEnumerator SpawnDelay()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, SpawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], SpawnPoints[randomSpawnPointID]);
    }

}
