using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    RaycastHit[] hits;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            RaycastHit ray;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        



        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, Mathf.Infinity))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50, Color.blue);
        //}
    }
}
