using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySceneManager : MonoBehaviour
{
    public abstract void playerTap(GameObject player);
    public abstract void enemyTap(GameObject enemy);
}
