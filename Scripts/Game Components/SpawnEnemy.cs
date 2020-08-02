using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] mysterio;

    public int noOfSpawns = 1;
   
    public string levelToLoad;
    private float timer = 10f;
    private Text timerSeconds;

    public float minTime, maxTime;
    private float enemySpawnTimer = 0f;
    private int lastSpawnPointIndex = -1;

    private void Update()
    {
        if (enemySpawnTimer <= 0f)
        {
            SpawnItems();
            ResetTimer();
        }
        enemySpawnTimer -= Time.deltaTime;
    }

    private void SpawnItems()
    {
        for (int i = 0; i < noOfSpawns; i++)
        {
            Transform spawnPoint = GetNextSpawnPoint();
            GameObject prefab = mysterio[Random.Range(0, mysterio.Length)];
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }

    private Transform GetNextSpawnPoint()
    {
        int index = (lastSpawnPointIndex + Random.Range(1, spawnPoints.Length - 1)) % spawnPoints.Length;
        lastSpawnPointIndex = index;
        return spawnPoints[index];
    }

    private void ResetTimer()
    {
        enemySpawnTimer = Random.Range(minTime, maxTime);
    }
}

public class OtherScript
{
    public EnemySpawner spawner;
    public Transform player;

    private void Update()
    {
        if (player.position.x > 40)
            spawner.enabled = false;
    }
}
