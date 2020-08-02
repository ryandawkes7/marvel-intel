using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopsChangeScene : MonoBehaviour
{
    public void backBtn()
    {
        SceneManager.LoadScene("CharacterHubScene");
    }

    public void homeBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }
}
