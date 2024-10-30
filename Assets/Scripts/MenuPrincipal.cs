using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public Canvas Menu;
    public Canvas MenuPausa;
    public Canvas MenuSFX;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = true;
        MenuPausa.enabled = false;
        Pausa();
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true;
        MenuSFX.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            
            MenuPausa.enabled = true;
            Cursor.lockState = CursorLockMode.None; // Libera el cursor
            Cursor.visible = true;
            Pausa();
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
    }

    public void Empezar()
    {
        Time.timeScale = 1f;
        Menu.enabled = false;
        MenuPausa.enabled = false;
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false;
    }

    public void SFX()
    {
        MenuSFX.enabled = true;
        Menu.enabled = false;
        MenuPausa.enabled = false;

    }

    public void MenuPausaVolver()
    {
        MenuSFX.enabled = false;
        Menu.enabled = false;
        MenuPausa.enabled = true;
    }

    public void Muerte()
    {

    }

    public void Victoria()
    {

    }
}
