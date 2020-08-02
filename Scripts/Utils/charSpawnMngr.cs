//REFERENCES:
//Video Tutorials:
//    MatthewHalberg - Vuforia 7 Ground Plane Detection (https://www.youtube.com/watch?v=0O6VxnNRFyg&t=125s)
//    Playful Technology - How to create an Augmented Reality App (https://www.youtube.com/watch?v=MtiUx_szKbI&t=406s)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class charSpawnMngr : MonoBehaviour
{

    public GameObject objToInstantiate;

    private GameObject spawnedObj;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObj == null)
            {
                spawnedObj = Instantiate(objToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObj.transform.position = hitPose.position;
            }
        }
    }
}
