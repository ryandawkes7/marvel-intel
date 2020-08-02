using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moralesBiogScript : MonoBehaviour
{

    public Button backBtn, homeBtn;

    public Button backButtonD, backButtonF, backButtonP;
    public Button detailsBtn, familyBtn, powersBtn;

    public GameObject mainBackdrop;
    public GameObject detailsPnl, familyPnl, powersPnl;

    void Awake()
    {
        detailsPnl.transform.gameObject.SetActive(false);
        familyPnl.transform.gameObject.SetActive(false);
        powersPnl.transform.gameObject.SetActive(false);
        mainBackdrop.transform.gameObject.SetActive(true);
    }

    void OnEnable()
    {
        backBtn.onClick.AddListener(PressBack);
        homeBtn.onClick.AddListener(PressHome);
        
        backButtonD.onClick.AddListener(ShowMainScene);
        backButtonF.onClick.AddListener(ShowMainScene);
        backButtonP.onClick.AddListener(ShowMainScene);
        
        detailsBtn.onClick.AddListener(ShowDetailsScene);
        familyBtn.onClick.AddListener(ShowFamilyScene);
        powersBtn.onClick.AddListener(ShowPowersScene);
    }

    public void PressBack()
    {
        SceneManager.LoadScene("BiographyScene");
    }

    public void PressHome()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void ShowMainScene()
    {
        detailsPnl.transform.gameObject.SetActive(false);
        familyPnl.transform.gameObject.SetActive(false);
        powersPnl.transform.gameObject.SetActive(false);
        mainBackdrop.transform.gameObject.SetActive(true);
    }
    
    public void ShowDetailsScene()
    {
        detailsPnl.transform.gameObject.SetActive(true);
        mainBackdrop.transform.gameObject.SetActive(false);
    }
    public void ShowFamilyScene()
    {
        familyPnl.transform.gameObject.SetActive(true);
        mainBackdrop.transform.gameObject.SetActive(false);
    }
    public void ShowPowersScene()
    {
        powersPnl.transform.gameObject.SetActive(true);
        mainBackdrop.transform.gameObject.SetActive(false);
    }
}
