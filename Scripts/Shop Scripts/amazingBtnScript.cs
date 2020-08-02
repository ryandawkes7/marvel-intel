using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amazingBtnScript : MonoBehaviour
{
    
    public Button alliesBtn, villainsBtn;
    public GameObject allyOne, allyTwo, villainOne, villainTwo;

    private void Awake()
    {
        allyOne.transform.gameObject.SetActive(false);
        allyTwo.transform.gameObject.SetActive(false);
        villainOne.transform.gameObject.SetActive(false);
        villainTwo.transform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        alliesBtn.onClick.AddListener(AlliesBtnPress);
        villainsBtn.onClick.AddListener(VillainsBtnPress);
    }

    void AlliesBtnPress()
    {
        allyOne.transform.gameObject.SetActive(true);
        allyTwo.transform.gameObject.SetActive(true);
        
        villainOne.transform.gameObject.SetActive(false);
        villainTwo.transform.gameObject.SetActive(false);
        
        alliesBtn.image.color = Color.gray;
        villainsBtn.image.color = Color.white;
        
    }
    
    void VillainsBtnPress()
    {
        allyOne.transform.gameObject.SetActive(false);
        allyTwo.transform.gameObject.SetActive(false);
        
        villainOne.transform.gameObject.SetActive(true);
        villainTwo.transform.gameObject.SetActive(true);
        
        villainsBtn.image.color = Color.gray;
        alliesBtn.image.color = Color.white;
    }
}
