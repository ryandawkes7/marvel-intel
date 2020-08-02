using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnlockSpiderman : MonoBehaviour
{

    public bool isSpidermanUnlocked = true;
    public GameObject spiderManButton;
    public GameObject lockedCover;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     if (isSpidermanUnlocked == false)
    //     {
    //         lockedCover.transform.gameObject.SetActive(true);
    //         spiderManButton.transform.gameObject.SetActive(false);
    //     }    else if (isSpidermanUnlocked == true)
    //     {
    //         lockedCover.transform.gameObject.SetActive(false);
    //         spiderManButton.transform.gameObject.SetActive(true);
    //     }
    // }
    //
    // void Update()
    // {
    //     if (vbScript.spidermanAccess == true)
    //     {
    //         isSpidermanUnlocked = true;
    //     }
    // }
}
