using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccountHubChangeScene : MonoBehaviour
{
    public void ExploreBtn()
    {
        SceneManager.LoadScene("Location-basedGame");
    }
    
    public void ViewCharsBtn()
    {
        SceneManager.LoadScene("ViewCharacterScene");
    }

    public void ScanBtn()
    {
        SceneManager.LoadScene("CharScanScene");
    }

    
}
