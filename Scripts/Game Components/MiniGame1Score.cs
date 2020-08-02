using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame1Score : MonoBehaviour
{
    public static int score;
    public static int enemies;

    Text text;

    void Awake()
    {

        text = GetComponent<Text>();
        score = 0;
        enemies = 0;

    }

    void Update()
    {

        text.text = "Score: " + score;
        PlayerPrefs.SetInt("newScore", score);

    }
}
