using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorscriptConsultorio : MonoBehaviour
{
    private int timeToShowUI = 1;
    public GameObject showDoorLockedUI = null;
    public TextMeshProUGUI textoPuerta;
    public GameObject hand;
    public GameObject keyConsultorioistrue;
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
                if (keyConsultorioistrue.activeInHierarchy)
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
        textoPuerta.text = "Find the key for Consultorio";
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}