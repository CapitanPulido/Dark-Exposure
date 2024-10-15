using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BateriaC : MonoBehaviour
{
    public Linterna linterna;

    public GameObject keyimage;
    public GameObject hand;
    public bool isplayer;



    void Start()
    {
        isplayer = false;
    }

    
    void Update()
    {

        if (isplayer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                keyimage.SetActive(true);
                hand.SetActive(false);
                Destroy(gameObject);
                Bateria();
            }
        }
    }

    public void Bateria()
    {
        linterna.RecargarBateria();
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

    
}
