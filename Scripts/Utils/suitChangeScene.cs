using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class suitChangeScene : MonoBehaviour
{
    public Button starkTech;
    public Button ironSpider;
    public Button futureFound;

    private void OnEnable()
    {
        starkTech.onClick.AddListener(StarkTechScene);
        ironSpider.onClick.AddListener(IronSpiderScene);
        futureFound.onClick.AddListener(FutureFoundScene);
    }

    void StarkTechScene()
    {
        SceneManager.LoadScene("starkTechSuit");
    }
    
    void IronSpiderScene()
    {
        SceneManager.LoadScene("ironSpiderSuit");
    }
    
    void FutureFoundScene()
    {
        SceneManager.LoadScene("futureFoundationSuit");
    }
    
}
