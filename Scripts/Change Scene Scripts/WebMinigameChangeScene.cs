using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebMinigameChangeScene : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }
}
