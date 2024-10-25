using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private int timeToShowUI = 1;
    public GameObject keyimage;

    public TextMeshProUGUI textollave;
    public GameObject keyistrue;
    
    public bool isplayer;
    public string texto;
    Animator animator;
    void Start()
    {
        isplayer = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isplayer = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isplayer = false;
            
        }
    }

    void Update()
    {
        if(isplayer)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                keyimage.SetActive(true);
                keyistrue.SetActive(true);
                textollave.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if (!textollave.gameObject.activeInHierarchy)
            {
                textollave.gameObject.SetActive(true);
                StartCoroutine(ShowKeydUI());
            }
        }
    }

    IEnumerator ShowKeydUI()
    {

        textollave.text = texto;
        yield return new WaitForSeconds(timeToShowUI);
        textollave.gameObject.SetActive(false);
    }
}
