using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

    public bool boolPoint;

    public RawImage Point;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeCamera()
    {
        boolPoint = !boolPoint;
        //Point.gameObject.SetActive(!boolCam);
        //CameraVideo.gameObject.SetActive(boolCam);
    }
}
