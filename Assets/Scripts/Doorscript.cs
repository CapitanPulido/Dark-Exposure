using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour
{
    public GameObject hand;
    public GameObject keyistrue;
    public bool isplayer;
    Animator animator;
    void Start()
    {
        isplayer = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isplayer = true;
            hand.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isplayer = false;
            hand.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(keyistrue.activeInHierarchy)
        {
            if (isplayer)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hand.SetActive(false);
                    animator.enabled = true;
                }
            }
        }
    }
}
