using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light LuzLinterna;
   
    public float energiaActual;
    public float energiaMaxima;
    public float energiaMinima;
    public float velocidaddeConsumo;

    public AudioSource noenergy;

    public bool Bateria = true, audiobateria;
    public Slider bateria;

    


    // Start is called before the first frame update
    void Start()
    {
        bateria.maxValue = energiaMaxima;
        bateria.minValue = energiaMinima;
    }

    // Update is called once per frame
    void Update()
    {
        bateria.value = energiaActual;
        if (Input.GetKeyDown("f"))
        {
            if(LuzLinterna.enabled == true)
            {
                LuzLinterna.enabled = false;

            }

            else if (LuzLinterna.enabled == false && Bateria)
            {
                LuzLinterna.enabled = true;
            }

        }
        if (LuzLinterna.enabled == true)
        {
            energiaActual -= Time.deltaTime * velocidaddeConsumo;

        }

        if (energiaActual <= 0)
        {
            LuzLinterna.enabled = false;
            Bateria = false;
            
        }

       

        if (energiaActual == energiaMinima)
        {
            if(noenergy.isPlaying == false && audiobateria == false) 
            {
                noenergy.Play();
                audiobateria = true;
            }
            
            Debug.Log("NO BITCHES");
        }
       
        energiaActual = Mathf.Clamp(energiaActual, energiaMinima, energiaMaxima);

        

    }

    public void RecargarBateria(float cantidad)
    {
        energiaActual += cantidad; // Recarga la cantidad especificada
        energiaActual = Mathf.Clamp(energiaActual, energiaMinima, energiaMaxima); // Clampeo para no exceder el máximo
        Bateria = true;
    }

    
}
