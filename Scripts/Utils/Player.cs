using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Enemies 
    {
        get { return enemies; }
    }

    public void AddDroids(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    
}
