using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarReflection : MonoBehaviour
{
    Camera m_Camera_Reflection;
    Camera m_Main_Camera;

    public GameObject m_ReflectionPlane;
    RenderTexture m_RenderTarget;

    void Start()
    {
        GameObject reflectionCameroGO = new GameObject("ReflectionCamera");
        m_Camera_Reflection = reflectionCameroGO.AddComponent<Camera>();
        m_Camera_Reflection.enabled = false;
        m_Main_Camera = Camera.main;

        m_RenderTarget = new RenderTexture(Screen.width, Screen.height, 24);
    }

   
    void Update()
    {
        
    }

    private void OnPostRender()
    {
        ReflectionCamera();
    }
    void ReflectionCamera()
    {
        m_Camera_Reflection.CopyFrom(m_Main_Camera);

        Vector3 cameraDirectionWorldSpace = m_Main_Camera.transform.forward;
        Vector3 cameraUpWorldSpace = m_Main_Camera.transform.up;
        Vector3 CameraPositionWorldSpace = m_Main_Camera.transform.position;

        Vector3 cameraDirectionPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraUpPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraUpWorldSpace);
        Vector3 cameraPositionPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(CameraPositionWorldSpace);

        cameraDirectionPlaneSpace.y *= -1.0f;
        cameraUpPlaneSpace.y *= -1.0f;
        cameraPositionPlaneSpace.y *= -1.0f;

        cameraDirectionWorldSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraDirectionPlaneSpace);
        cameraUpWorldSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraUpPlaneSpace);
        CameraPositionWorldSpace = m_ReflectionPlane.transform.InverseTransformPoint(cameraPositionPlaneSpace);

        m_ReflectionPlane.transform.position = CameraPositionWorldSpace;
        m_ReflectionPlane.transform.LookAt(CameraPositionWorldSpace + cameraUpWorldSpace + cameraPositionPlaneSpace);


        m_Camera_Reflection.targetTexture = m_RenderTarget;
        m_Camera_Reflection.Render();
    }
}
