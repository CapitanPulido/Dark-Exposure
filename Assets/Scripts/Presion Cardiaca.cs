using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresionCardiaca : MonoBehaviour
{
    public Latido latido;
    public float MaxPressure;
    private float MinPressure = 0;
    public float ActualPressure;
    public float Pressure;
    public float relax;
  

    FirstPersonController Controller;
    public Canvas PressureCanvas;
    public RawImage PressureBlood;
    Color pressureColor = Color.white;
    public bool isEnemy = false;
    public bool isSafe = true;

    Die died;

    public AudioSource Hearth;
    void Start()
    {
        ActualPressure = MinPressure;
        
    }

   
    void Update()
    {

        ActualPressure = Mathf.Clamp(ActualPressure, MinPressure, MaxPressure);

        if (ActualPressure >= 6)
        {
            Controller.enabled = false;
            

        }
        pressureColor.a = ActualPressure;
        PressureBlood.color = pressureColor;
        Hearth.volume = ActualPressure;
        Hearth.pitch = ActualPressure;

        if (isEnemy) 
        {
            ActualPressure += Time.deltaTime * Pressure;
            latido.PLayPressure();
            isSafe = false;
        }
        else
        {
            isSafe = true;
            
        }

        if(isSafe)
        {
            ActualPressure -= Time.deltaTime * relax;
        }

        if (ActualPressure == MaxPressure)
        {
            died.Died();
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
