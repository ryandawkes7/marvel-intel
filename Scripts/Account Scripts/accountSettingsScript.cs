using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class accountSettingsScript : MonoBehaviour
{

    public GameObject accountSettingsPnl;

    public Button accountSettingsBtn;
    public Button closeBtn;
    public Button logoutBtn;

    public Text emailTxt;
    public Text userIdTxt;

    void Awake()
    {
        accountSettingsPnl.transform.gameObject.SetActive(false);
        // emailTxt.text = PlayerPrefs.GetString("usersEmail");

        if (PlayerPrefs.GetString("usersEmail") != "")
        {
            emailTxt.text = PlayerPrefs.GetString("usersEmail");
        }
        else
        {
            emailTxt.text = "email address";
        }
        
        userIdTxt.text = PlayerPrefs.GetString("usersId");
    }

    private void OnEnable()
    {
        accountSettingsBtn.onClick.AddListener(OpenAccountSettings);
        closeBtn.onClick.AddListener(CloseAccountSettings);
        logoutBtn.onClick.AddListener(PressLogout);
    }

    public void OpenAccountSettings()
    {
        accountSettingsPnl.transform.gameObject.SetActive(true);
    }
    public void CloseAccountSettings()
    {
        accountSettingsPnl.transform.gameObject.SetActive(false);
    }

    public void PressLogout()
    {
        PlayerPrefs.SetString("usersEmail", null);
        PlayerPrefs.SetString("usersId", null);
        SceneManager.LoadScene("HomeScene");
    }
}
