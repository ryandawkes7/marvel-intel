using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : EnemySceneManager
{

    private GameObject enemy;
    private AsyncOperation loadScene;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public override void playerTap(GameObject player)
    {
        
    }

    public override void enemyTap(GameObject enemy)
    {
        SceneManager.LoadScene("WebMinigameScene");
    }
}
