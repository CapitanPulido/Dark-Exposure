using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light LuzLinterna;
    public GameObject camara;
    public float energiaActual;
    public float energiaMaxima;
    public float energiaMinima;
    public float velocidaddeConsumo;

    public bool Bateria = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if(LuzLinterna.enabled == true)
            {
                LuzLinterna.enabled = false;

            }

            else if (LuzLinterna.enabled == false)
            {
                LuzLinterna.enabled = true;
            }

        }
        if (LuzLinterna.enabled == true)
        {
            energiaActual -= Time.deltaTime * velocidaddeConsumo;

        }

        if (Bateria && LuzLinterna.enabled == false)
        {
           

        }

        if (energiaActual <= 0)
        {
            LuzLinterna.enabled = false;
            Bateria = false;
        }
        if (Input.GetKeyDown("r"))
        {
            RecargarBateria();
        }
        energiaActual = Mathf.Clamp(energiaActual, energiaMinima, energiaMaxima);


    }

    public void RecargarBateria()
    {
        if (Bateria == false)
        {
            energiaActual += energiaMaxima;
            Bateria = true;
        }
    }
}
