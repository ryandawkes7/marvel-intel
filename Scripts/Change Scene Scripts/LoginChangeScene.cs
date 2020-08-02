using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginChangeScene : MonoBehaviour
{
    public void CloseBtn()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ConfirmBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void ForgotDetailsBtn()
    {
        SceneManager.LoadScene("ForgotDetailsScene");
    }
}
