using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class biogBtnScript : MonoBehaviour
{

    public Button parkerBtn;
    public Button moralesBtn;
    public Button drewBtn;
    
    void OnEnable()
    {
        parkerBtn.onClick.AddListener(ParkerScene);
        moralesBtn.onClick.AddListener(MoralesScene);
        drewBtn.onClick.AddListener(DrewScene);
    }

    private static void ParkerScene()
    {
        SceneManager.LoadScene("ParkerBiog");
    }
    private static void MoralesScene()
    {
        SceneManager.LoadScene("MoralesBiog");
    }
    private static void DrewScene()
    {
        SceneManager.LoadScene("DrewBiog");
    }
    
}
