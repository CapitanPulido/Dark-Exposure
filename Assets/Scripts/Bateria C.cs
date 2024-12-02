using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaC : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    public GameObject hand;
    public bool isPlayer;

    void Start()
    {
        isPlayer = false;
    }

    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.Mouse0))
        {
            hand.SetActive(false);
            StartCoroutine(Destroy());
            
        }
    }

    public void Bateria()
    {
        FirstPersonController.RecargarBateria();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            hand.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
            hand.SetActive(false);
        }
    }

    IEnumerator Destroy()
    {
        Bateria();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

