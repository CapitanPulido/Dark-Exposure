using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryimage;



    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            inventoryimage.SetActive(true);
        }
        else
        {
            inventoryimage.SetActive(false);
        }

    }
}
