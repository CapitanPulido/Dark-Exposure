using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject Players, Pause;
    //public Canvas Pause;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Pause.SetActive(true);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        // Pause all audio
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Pause.SetActive(false);
        Players.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        // Resume all audio
        AudioListener.pause = false;
    }
}
