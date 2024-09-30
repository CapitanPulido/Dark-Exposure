using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;




    public float openAngle = 90f;     // Angle to open the door
    public float closeAngle = 0f;     // Angle to close the door
    public float speed = 2f;          // Speed of door opening/closing
    private bool isOpen = false;      // Is the door open or closed
    private Quaternion targetRotation;


    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }
    void Start()
    {
        targetRotation = transform.localRotation;  // Initialize with current rotation
    }

    void Update()
    {
        // Smoothly rotate the door towards the target rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * speed);
    }

    void OnMouseDown()
    {
        // Toggle between open and closed states
        if (isOpen)
        {
            targetRotation = Quaternion.Euler(0f, closeAngle, 0f);
        }
        else
        {
            targetRotation = Quaternion.Euler(0f, openAngle, 0f);
        }

        isOpen = !isOpen;
    }
}