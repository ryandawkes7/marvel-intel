using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{

    public Text CurrentCoins;
    public int currentCoinsAmount;

    void Start()
    {

        // Assigns text component for displaying the user's coins
        CurrentCoins = GetComponent<Text>();

        // Logs how many coins the player has upon changing scene
        Debug.Log("You have " + CoinsManager.CurrentCoinsTotal + " coins.");

    }

    void Update()
    {
        // Assigns the integer value of the amount of coins to display as text to the user (as a string)
        CurrentCoins.text = CoinsManager.CurrentCoinsTotal.ToString();

    }
}
