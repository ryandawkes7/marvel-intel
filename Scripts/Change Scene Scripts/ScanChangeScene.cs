using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanChangeScene : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("AccountSettingsScene");
    }
}
