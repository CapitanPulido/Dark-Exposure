using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    //public Canvas MenuSFX;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        //MenuSFX.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void Empezar1()
    {
        SceneManager.LoadScene("Pruebas_Rick");
        Time.timeScale = 1f;

    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;

    }

    public void Empezar()
    {
        SceneManager.LoadScene("Intro");

    }

    public void Menep()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MenuPrincipal");

    }

    public void Exit()
    {
        Application.Quit();
    }
    public void SFX()
    {
        //MenuSFX.enabled = true;

    }



}
