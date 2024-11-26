using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    public AudioSource Muerte;
    public AudioSource Muerte2;
    AudioSource source;
    public AudioClip[] sounds;
    public float volumen;
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
        //if (!source.isPlaying)
        //{
        //    Musica();
        //}
        TimerAudio += Time.deltaTime;
        if (TimerAudio > 300)
        {
            TimerAudio = 0;
            Musica();
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
        //if aux == r
        /*
         * regenero random
         * 
         */
        source.PlayOneShot(sounds[r], volumen);
    }

    public void ObtenerAudioSource()
    {
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            Debug.LogError("No se encontr� el componente AudioSource en el GameObject.");
            return;
        }

        // Configura el AudioSource como sonido 3D
        source.spatialBlend = 1.0f; // Hace que el sonido sea completamente 3D
        source.rolloffMode = AudioRolloffMode.Linear; // Cambia esto si deseas un tipo diferente de ca�da del volumen
        source.minDistance = 1f; // La distancia m�nima a partir de la cual se escuchar� el sonido
        source.maxDistance = 20f; // La distancia m�xima a la que el sonido es audible
    }
}