using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorscriptConsultorio2 : MonoBehaviour
{
    private int timeToShowUI = 1;
    public GameObject showDoorLockedUI = null;
    public TextMeshProUGUI textoPuerta;
    public GameObject hand;
    public GameObject keyConsultorio2istrue;
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


        if (isplayer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (keyConsultorio2istrue.activeInHierarchy)
                {
                    hand.SetActive(false);
                    animator.enabled = true;
                }
                else if (!showDoorLockedUI.activeInHierarchy)
                {
                    StartCoroutine(ShowDoorLockedUI());
                }
            }
        }



    }

    IEnumerator ShowDoorLockedUI()
    {
        showDoorLockedUI.SetActive(true);
        textoPuerta.text = "Find the key for Consultorio 2";
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
