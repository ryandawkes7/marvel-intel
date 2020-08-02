using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharScanChangeScene : MonoBehaviour
{

    public void BackBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }
    
}
