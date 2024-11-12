using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresionCardiaca : MonoBehaviour
{
    public Latido latido;
    public float MaxPressure;
    public float MinPressure;
    public float ActualPressure;
    public float Pressure;
  

    FirstPersonController Controller;
    public Canvas DiedCanvas;
    public Canvas PressureCanvas;
    public RawImage PressureBlood;
    Color pressureColor = Color.white;
    public bool isEnemy = false;

    public AudioSource Hearth;
    void Start()
    {
        ActualPressure = 0;
        

    }

   
    void Update()
    {

        ActualPressure = Mathf.Clamp(ActualPressure, MinPressure, MaxPressure);
        if (ActualPressure >= 60)
        {
            Controller.enabled = false;
            DiedCanvas.gameObject.SetActive(true);  

        }
        pressureColor.a = ActualPressure;
        PressureBlood.color = pressureColor;
        Hearth.volume = ActualPressure;
        Hearth.pitch = ActualPressure;

        if (isEnemy) 
        {
            ActualPressure += Time.deltaTime * Pressure;
            latido.PLayPressure();
        }
        else
        {
            ActualPressure -= Time.deltaTime * Pressure;
            
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            isEnemy = true;
        }

        else
        {
            isEnemy = false;
        }
    }



    //agregar soonido de latido y quee se escuhe mas fuerte segun el nivel de la presion
}
