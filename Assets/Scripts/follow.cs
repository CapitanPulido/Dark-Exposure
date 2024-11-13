using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class follow : MonoBehaviour
{

    public GameObject MainCam, SecondCam;

    void LateUpdate()
    {
        if (MainCam.activeSelf)
        {
            transform.rotation = MainCam.transform.rotation;
        }
        else if (SecondCam.activeSelf) 
        {
            transform.rotation = SecondCam.transform.rotation;
        }
        

    }
}
