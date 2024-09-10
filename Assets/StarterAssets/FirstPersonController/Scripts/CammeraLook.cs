using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraLook : MonoBehaviour
{
    public Transform target; 
    public float rotationSpeed = 5.0f;

    void Update()
    {
        if (target != null)
        {
           
            Vector3 direction = target.position - transform.position;

            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion targetRotation = Quaternion.Euler(0, - lookRotation.eulerAngles.x, 0); // Fija el ángulo X

            
        }
    }
}





