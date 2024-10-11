using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyimage;
    public Doorscript Door;
    public GameObject hand;
    public bool isplayer;
    void Start()
    {
        isplayer = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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

    void Update()
    {
        if(isplayer)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Cambiar
                keyimage.SetActive(true);
                //
                Door.keyistrue = true;
                Destroy(gameObject);
            }
        }
    }
}
