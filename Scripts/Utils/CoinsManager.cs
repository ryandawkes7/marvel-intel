//REFERENCES
//Video Tutorials:
//    Press Start - Unity - How to Save Game / Data (https://www.youtube.com/watch?v=y7RPVvwjrsA)

//Forums/Sites:
//    Unity3D - PlayerPrefs (https://docs.unity3d.com/ScriptReference/PlayerPrefs.html)
//    Unity Forums - How to create currency (https://forum.unity.com/threads/how-to-create-currency.124297/)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CoinsManager {
    private static int _coinsRecieved = PlayerPrefs.GetInt("CoinsRecieved");
    public static int CoinsRecieved {
        get { return _coinsRecieved; }
        private set {
            _coinsRecieved = value;
            PlayerPrefs.SetInt("CoinsRecieved", _coinsRecieved);
        }
    }
    private static int _currentCoinsTotal = PlayerPrefs.GetInt("currentCoinsTotal");
    public static int CurrentCoinsTotal {
        get { return _currentCoinsTotal; }
        private set
        {
            _currentCoinsTotal = value;
            PlayerPrefs.SetInt("CurrentCoinsTotal", _currentCoinsTotal);
            PlayerPrefs.Save();
        }
    }

    public static void ClearCoinsRecieved()
    {
        CoinsRecieved = 0;
    }

    public static void AddCoinsRecieved(int coins) {
        CoinsRecieved += coins;
    }

    public static void AddCurrentCoins(int coins) {
        CurrentCoinsTotal += coins;
    }

    public static void RemoveCurrentCoins(int coins)
    {
        CurrentCoinsTotal -= coins;
    }
}