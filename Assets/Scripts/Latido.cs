using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latido : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void PLayPressure()
    {
        animator.Play("presuure");
    }
}
