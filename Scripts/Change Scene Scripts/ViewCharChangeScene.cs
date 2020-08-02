using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewCharChangeScene : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void SpiderManBtn()
    {
        SceneManager.LoadScene("CharacterHubScene");
    }
}
