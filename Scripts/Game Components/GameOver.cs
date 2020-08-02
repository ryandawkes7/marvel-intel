using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    // Score attained when timer reaches 0
    public Text finalScore;
    // Amount of enemies stopped within the most recent played game
    public Text enemiesStopped;
    // Amount of coins gained via final score
    public Text coinsGained;

    public static int scoreValue = 0;
    private int enemiesValue = 0;
    public static int coinsValue;

    void Start()
    {
        scoreValue = MiniGame1Score.score;
        enemiesValue = MiniGame1Score.enemies;
        coinsValue = scoreValue / 2;

        //Adds coins to player's overall coin amount when game ends
        CoinsManager.AddCoinsRecieved(coinsValue);

        finalScore.text = scoreValue.ToString();
        coinsGained.text = coinsValue.ToString();
        enemiesStopped.text = enemiesValue.ToString();
        addCoins();
    }

    void addCoins()
    {
        if(coinsValue >= 1)
        {
            Debug.Log("You have earnt " + coinsValue + " coins from this game");
            CoinsManager.AddCurrentCoins(coinsValue);
            Debug.Log("You now have " + CoinsManager.CurrentCoinsTotal + " coins in total");
        } else
        {
            Debug.Log("How bad are you - no coins.");
        }
    }
}
