//REFERENCES
// https://library.vuforia.com/articles/Training/getting-started-with-vuforia-in-unity.html

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class vbScript : MonoBehaviour
{
    public float m_ButtonReleaseTimeDelay;
    public GameObject character;

    public Text unlockedTxt;
    public Button continueBtn;
    public GameObject descPnl;
    
    UnlockSpiderman _unlockSpiderman;
    public static bool spidermanAccess;
    private string vbName;

    VirtualButtonBehaviour[] virtualButtonBehaviours;

    void OnEnable()
    {
        continueBtn.onClick.AddListener(PressContinueBtn);
    }

    void PressContinueBtn()
    {
        SceneManager.LoadScene("ViewCharacterScene");
    }

    void Start()
    {
        descPnl.transform.gameObject.SetActive(true);
        unlockedTxt.transform.gameObject.SetActive(false);
        character.SetActive(true);
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
        {
            virtualButtonBehaviours[i].RegisterOnButtonPressed(OnButtonPressed);
            // virtualButtonBehaviours[i].RegisterOnButtonReleased(OnButtonReleased);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;
        if (vbName == "actionButton")
        {
            VirtualButtonChanged();
            Debug.Log("Button pressed");
        }
        else
        {
            Deactivate();
        }
    }

    void VirtualButtonChanged()
    {
        unlockedTxt.transform.gameObject.SetActive(true);
        descPnl.transform.gameObject.SetActive(false);
    }

    void Deactivate()
    {
        character.SetActive(false);
    }
}
