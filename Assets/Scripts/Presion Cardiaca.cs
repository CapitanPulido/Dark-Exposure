using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(AudioSource))]
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
    public float volumen;
    public AudioClip[] sounds;

    Die died;

    AudioSource Hearth;

    void Start()
    {
        ActualPressure = MinPressure;
        

        if (Hearth == null)
        {
            ObtenerAudioSource();
        }
    }

    public void ObtenerAudioSource()
    {
        Hearth = GetComponent<AudioSource>();

        if (Hearth == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el GameObject.");
            return;
        }

        // Configura el AudioSource como sonido 3D
        Hearth.spatialBlend = 1.0f; // Hace que el sonido sea completamente 3D
        Hearth.rolloffMode = AudioRolloffMode.Linear; // Cambia esto si deseas un tipo diferente de caída del volumen
        Hearth.minDistance = 1f; // La distancia mínima a partir de la cual se escuchará el sonido
        Hearth.maxDistance = 20f; // La distancia máxima a la que el sonido es audible
    }
    public void Musica()
    {
        int r = UnityEngine.Random.Range(0, sounds.Length);
        Hearth.PlayOneShot(sounds[r], volumen);
    }

    public void Update()
    {
        if (!Hearth.isPlaying)
        {
            Musica();
        }

        ActualPressure = Mathf.Clamp(ActualPressure, MinPressure, MaxPressure);

        if (ActualPressure >= 250)
        {
            Controller.enabled = false;
            

        }

        pressureColor.a = ActualPressure;
        PressureBlood.color = pressureColor;
        //Hearth.volume = ActualPressure;
        //Hearth.pitch = ActualPressure;

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
