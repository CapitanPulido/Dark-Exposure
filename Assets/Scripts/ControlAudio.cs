using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    public AudioSource Muerte;
    public AudioSource Muerte2;
    public AudioSource IAudio;
    public AudioSource Surrar;
    public AudioSource wnch;
    public AudioSource source;
    public AudioClip[] sounds;
    public AudioClip[] Encontrar;

    public float volumen;
    public float volumen2;
    public float TimerAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (source == null)
        {
            ObtenerAudioSource();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerAudio += Time.deltaTime;
        if (TimerAudio > 120)
        {
            TimerAudio = 0;
            Musica();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Found();
        }
    }

    public void SFXMuerte()
    {
        StartCoroutine(sfxdead());
        Debug.Log("Moriste");
    }

    IEnumerator sfxdead()
    {
        Muerte2.Play();
        yield return new WaitForSeconds(2);
        Muerte.Play();
    }
    public void Musica()
    {
        int r = UnityEngine.Random.Range(0, sounds.Length);
        source.PlayOneShot(sounds[r], volumen);
    }
    public void Found()
    {
        int r = UnityEngine.Random.Range(0, sounds.Length);
        source.PlayOneShot(Encontrar[r], volumen2);
        Debug.Log("AudioReproducido");
    }


    public void ObtenerAudioSource()
    {
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el GameObject.");
            return;
        }

        // Configura el AudioSource como sonido 3D
        source.spatialBlend = 1.0f; // Hace que el sonido sea completamente 3D
        source.rolloffMode = AudioRolloffMode.Linear; // Cambia esto si deseas un tipo diferente de caída del volumen
        source.minDistance = 1f; // La distancia mínima a partir de la cual se escuchará el sonido
        source.maxDistance = 20f; // La distancia máxima a la que el sonido es audible
    }

    public void IncioAudio()
    {
        IAudio.Play();
    }

    public void Susurros()
    {
        Surrar.Play();
    }
    public void WNCH()
    {
        wnch.Play();
    }

    public void Encontro()
    {
        Found();
    }

}