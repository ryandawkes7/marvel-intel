using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameEndChangeScene : MonoBehaviour
{

    public void ExitBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

}
