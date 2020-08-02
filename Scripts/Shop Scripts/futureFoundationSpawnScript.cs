// REFERENCES
// MatthewHalberg - https://www.youtube.com/watch?v=khavGQ7Dy3c 
// DevEnabled - https://www.youtube.com/watch?time_continue=43&v=VMjZ70PmnPs&feature=emb_logo
// Unity3dTeacher - https://www.youtube.com/watch?v=ptwHTu6gicE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class futureFoundationSpawnScript : MonoBehaviour
{
    public ARRaycastManager rayManager;
    public GameObject markerObj;


    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        markerObj = this.transform.GetChild(0).gameObject;
        markerObj.SetActive(false);
    }

    void Update()
    {
        List<ARRaycastHit> hitPos = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitPos, TrackableType.Planes);

        if (hitPos.Count > 0)
        {
            transform.position = hitPos[0].pose.position;
            transform.rotation = hitPos[0].pose.rotation;

            if (!markerObj.activeInHierarchy)
            {
                markerObj.SetActive(true);
            }
        }
        
        
    }
}
