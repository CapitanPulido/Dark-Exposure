using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Canvas Menu;
    public Canvas MenuSFX;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = true;

        MenuSFX.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    public void Empezar()
    {
        SceneManager.LoadScene("");

    }

    public void Exit()
    {

    }
    public void SFX()
    {
        MenuSFX.enabled = true;

    }

}
