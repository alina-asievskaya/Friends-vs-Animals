using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> prefabs;
    public List<Transform> SpawnPoints;
    public float spawnInterval = 2f;

    private int enemyCount;
    private float enemySpeed;
    private int activeEnemies = 0; // �������������

    public void StartSpawning(int count, float speed)
    {
        enemyCount = count;
        enemySpeed = speed;
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, SpawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], SpawnPoints[randomSpawnPointID]);

        // ������������� �������� �����
        spawnedEnemy.GetComponent<Enemy>().moveSpeed = enemySpeed;

        // ����������� ������� �������� ������
        activeEnemies++;

        // ������������� �� ������� ����������� �����
        spawnedEnemy.GetComponent<Enemy>().OnEnemyDefeated += HandleEnemyDefeated;
    }

    private void HandleEnemyDefeated()
    {
        activeEnemies--; // ��������� ������� �������� ������
        CheckForWinCondition(); // ��������� ���������� �������
    }

    // ����� ��� ��������, �������� �� �����
    public bool AreEnemiesDefeated()
    {
        return activeEnemies <= 0; // ���������, �������� �� �������� �����
    }

    // ����� ��� �������� ������� ��������
    private void CheckForWinCondition()
    {
        if (AreEnemiesDefeated())
        {
            // �������� ����� Winner � Complexity
            FindObjectOfType<Complexity>().Winner();
        }
    }

}
