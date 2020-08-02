using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{

    public string levelToLoad;
    private float timer = 10f;
    private Text timerSeconds;

    void Start()
    {

        timerSeconds = GetComponent<Text>();

    }

    void Update()
    {

        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f0");
        if (timer <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        } 

    }
}
