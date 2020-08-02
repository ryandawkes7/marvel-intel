using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public GameObject arCamera;
    public GameObject smoke;

    public int scoreValue = 1;
    public int enemiesValue = 1;

    public int enemyHealth = 3;

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if(hit.transform.name == "Flying(Clone)")
            {
                Debug.Log("Enemy Hit!");
                enemyHealth -= 1;
                if (enemyHealth <= 0)
                {
                    Destroy(hit.transform.gameObject);
                    Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                    MiniGame1Score.score += scoreValue;
                    MiniGame1Score.enemies += enemiesValue;
                }
            }
        }
    }
}
