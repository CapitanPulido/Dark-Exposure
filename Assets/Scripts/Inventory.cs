using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryimage;
    bool istrue;


    private void Start()
    {
        istrue = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            istrue = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            istrue = false;
        }

        if (istrue)
        {
            inventoryimage.SetActive(true);
        }
        else
        {
            inventoryimage.SetActive(false);
        }
    }
}
