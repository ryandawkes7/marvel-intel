// REFERENCES: (Applies for all minigame scenes)
// Parth Anand - https://www.youtube.com/watch?v=jDj_UF8ke48&t=488s

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class EnemySpawner : Singleton<EnemySpawner>
{

    [SerializeField] private EnemyMap[] availableEnemies;
    [SerializeField] private Player player;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingEnemies = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;
    
    private List<EnemyMap> liveEnemies = new List<EnemyMap>();
    private EnemyMap selectedEnemy;

    public List<EnemyMap> LiveEnemies
    {
        get { return liveEnemies; }
    }

    public EnemyMap SelectedEnemy
    {
        get { return selectedEnemy; }
    }

    private void Awake()
    {
        Assert.IsNotNull(availableEnemies);
        Assert.IsNotNull(player);
    }

    void Start()
    {
        for (int i = 0; i < startingEnemies; i++)
        {
            InstantiateEnemy();
        }

        StartCoroutine(GenerateEnemies());
    }

    public void EnemyWasSelected(EnemyMap enemyMap)
    {
        selectedEnemy = enemyMap;
    }
    
    private IEnumerator GenerateEnemies()
    {
        while (true)
        {
            InstantiateEnemy();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateEnemy()
    {
        int index = Random.Range(0, availableEnemies.Length);
        float x = player.transform.position.x + GenerateRange();
        float z = player.transform.position.z + GenerateRange();
        float y = player.transform.position.y;
        liveEnemies.Add(Instantiate(availableEnemies[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
    
}
