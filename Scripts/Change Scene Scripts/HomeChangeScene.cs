using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeChangeScene : MonoBehaviour
{
    public void LoginBtn()
    {
        SceneManager.LoadScene("LoginScene");
    } 

    public void RegisterBtn()
    {
        SceneManager.LoadScene("RegisterScene");
    }
}