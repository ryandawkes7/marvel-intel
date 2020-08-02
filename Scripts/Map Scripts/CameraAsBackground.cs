using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAsBackground : MonoBehaviour
{

    private RawImage image;
    private WebCamTexture cam;
    private AspectRatioFitter arf; 
    
    void Start()
    {
        arf = GetComponent<AspectRatioFitter>();
        image = GetComponent<RawImage>();
        
        //Sets camera to fit screen size
        cam = new WebCamTexture(Screen.width, Screen.height);
        
        //Img texture becomes the camera
        image.texture = cam;
        
        //Turn on camera
        cam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.width < 100)
        {
            return;
        }

        float cwNeeded = -cam.videoRotationAngle;
        if (cam.videoVerticallyMirrored)
        {
            cwNeeded += 180f;
            
            //Image rotated accordingly to camera's rotation
            image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);

            float videoRatio = (float) cam.width / (float) cam.height;
            arf.aspectRatio = videoRatio;

            if(cam.videoVerticallyMirrored)
            {
                image.uvRect = new Rect(1, 0, -1, 1);
            }
            else
            {
                image.uvRect = new Rect(0, 0, 1, 1);
            }
        }
    }
}
