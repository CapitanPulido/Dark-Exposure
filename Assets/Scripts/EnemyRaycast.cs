using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyRaycast : MonoBehaviour
{
    public RaycastHit hit;
    public float range;


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 12; i++)
        //{
        //    RaycastHit ray = new RaycastHit();
        //    ray.distance = range;
        //    hits[i] = ray;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        for(int i = 1;i < 12; i++)
        {
            Vector3 angulo = new Vector3(transform.rotation.x, -90 + (i*5),transform.rotation.z);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,range))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + angulo) * range, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + angulo)* range, Color.blue);
            }
        }
    
       
    }
}
