using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharHubChangeScene : MonoBehaviour
{
    
    public Text coinsTxt;

    private void Update()
    {
        coinsTxt.text = CoinsManager.CurrentCoinsTotal.ToString();
    }

    public void BackBtn()
    {
        SceneManager.LoadScene("ViewCharacterScene");
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void SuitsBtn()
    {
        SceneManager.LoadScene("SuitShopScene");
    }

    public void MoviesBtn()
    {
        SceneManager.LoadScene("MoviesScene");
    }

    public void ComicsBtn()
    {
        SceneManager.LoadScene("ComicsScene");
    }

    public void BiographyBtn()
    {
        SceneManager.LoadScene("BiographyScene");
    }

    public void ARViewBtn()
    {
        SceneManager.LoadScene("ARViewScene");
    }

    public void AssociationsBtn()
    {
        SceneManager.LoadScene("AssociationsScene");
    }

    public void PowersBtn()
    {
        SceneManager.LoadScene("PowersScene");
    }
}
