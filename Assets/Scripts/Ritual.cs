using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ritual : MonoBehaviour
{
    private int timeToShowUI = 1;
    public GameObject showpiecemissingUI = null;
    public TextMeshProUGUI textoritual;
    public GameObject hand;
    public GameObject istrue;
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
                if (istrue.activeInHierarchy)
                {
                    hand.SetActive(false);
                    animator.enabled = true;
                }
                else if (!showpiecemissingUI.activeInHierarchy)
                {
                    StartCoroutine(ShowpiecemissingUI());
                }

            }
        }

    }

    IEnumerator ShowpiecemissingUI()
    {
        showpiecemissingUI.SetActive(true);
        textoritual.text = "Find ritual pieces";
        yield return new WaitForSeconds(timeToShowUI);
        showpiecemissingUI.SetActive(false);
    }
}
