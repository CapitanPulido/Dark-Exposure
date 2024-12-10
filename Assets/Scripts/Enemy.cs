using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public List<Collider> Collist = new List<Collider>() { };

    public float patrolRange = 10f;
    public float waitTime = 2f;
    public float detectionRadius = 10f;
    public Transform player;

    public float waitTimer = 3;
    private Vector3 lastDestination;
    public bool isChasingPlayer = false;

    AudioSource source;
    public AudioClip[] sounds;

    public float volumen;
    //public Animator animator;

    public GameObject Correr;
    public GameObject Caminar;
    public GameObject Idle;

    public void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("No se encontró el componente NavMeshAgent en el GameObject.");
                return;
            }

            //animator = GetComponent<Animator>();
        }

        //waitTimer = waitTime;
        //lastDestination = transform.position;
        MoveToRandomPoint();

        if (source == null)
        {
            ObtenerAudioSource();
        }
    }


    public void Musica()
    {
        int r = UnityEngine.Random.Range(0, sounds.Length);
        source.PlayOneShot(sounds[r], volumen);
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

    void Update()
    {

        Debug.Log(agent.remainingDistance);

        if (!source.isPlaying)
        {
            Musica();
        }

        // Asegúrate de que el objeto mire en la dirección de movimiento
        RotateTowardsMovementDirection();

        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {

        }
        else
        {

            isChasingPlayer = false;

            if (!agent.pathPending && agent.remainingDistance < 2f)
            {
                if (waitTimer <= 0)
                {
                    MoveToRandomPoint();
                    waitTimer = waitTime;
                    agent.speed = 3f;
                }
                else
                {
                    agent.speed = 0f;
                    waitTimer -= Time.deltaTime;
                }
            }

        }


        if (agent.speed == 0f)
        {
            Idle.SetActive(true);
            Correr.SetActive(false);
            Caminar.SetActive(false);
        }

        if (agent.speed > 0f  && agent.speed <= 5)
        {
            Idle.SetActive(false);
            Correr.SetActive(false);
            Caminar.SetActive(true);
        }

        if(agent.speed > 5)
        {
            Idle.SetActive(false);
            Correr.SetActive(true);
            Caminar.SetActive(false);
        }
    }



    public void MoveToRandomPoint()
    {
        Vector3 randomPoint;
        NavMeshHit hit;

        do
        {

            randomPoint = transform.position + UnityEngine.Random.insideUnitSphere * patrolRange;
            randomPoint.y = transform.position.y;

        } while (Vector3.Distance(randomPoint, lastDestination) < 10f ||
                 !NavMesh.SamplePosition(randomPoint, out hit, patrolRange, NavMesh.AllAreas));

        //Actualiza el destino del agente
        agent.SetDestination(hit.position);
        lastDestination = hit.position;
        
    }
    public void MoveToPlayerPosition()
    {
        isChasingPlayer = true;
        agent.SetDestination(player.position);
        agent.speed = 10;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Collist.Add(collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        Collist.Remove(collision);
    }

    void RotateTowardsMovementDirection()
    {
        // Si el agente está moviéndose
        if (agent.velocity.sqrMagnitude > 0.01f)
        {
            // Obtén la dirección del movimiento
            Vector3 direction = agent.velocity.normalized;

            // Calcula la rotación necesaria para mirar en esa dirección
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Aplica la rotación suavemente
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * agent.angularSpeed);
        }
    }
}

