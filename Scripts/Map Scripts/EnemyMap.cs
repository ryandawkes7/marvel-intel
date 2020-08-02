//REFERENCES: (Applies to all map scripts)
// Unity - https://www.youtube.com/watch?v=BV4C0sTkz_w&t=18s
// Mapbox - https://www.youtube.com/watch?v=Xw0haMrTRbY&t=136s
// MattheHalberg - https://www.youtube.com/watch?v=u8JaKspgWvE&t=165s
// Mapbox (Series) - https://www.youtube.com/watch?v=sK3lr3Yh6XI

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMap : MonoBehaviour
{

    [SerializeField] private float spawnRate = 0.10f;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public float SpawnRate
    {
        get { return spawnRate; }
    }

    private void OnMouseDown()
    {
        EnemySceneManager[] managers = FindObjectsOfType<EnemySceneManager>();
        foreach (EnemySceneManager enemySceneManager in managers)
        {
            if (enemySceneManager.gameObject.activeSelf)
            {
                enemySceneManager.enemyTap(this.gameObject);
            }
        }
    }
}
