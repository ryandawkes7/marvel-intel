using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ifLoggedInScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetString("usersEmail") != "")
        {
            if (PlayerPrefs.GetString("usersId") != "")
            {
                SceneManager.LoadScene("AccountHubScene");
            }
            else
            {
                Debug.Log("no user id");
            }
        }
        else
        {
            Debug.Log("no user email");
        }
    }
}
