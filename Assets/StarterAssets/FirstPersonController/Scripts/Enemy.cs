using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float patrolRange = 10f;   
    public float waitTime = 2f;       
    public float detectionRadius = 10f; 
    public Transform player;          

    private float waitTimer;
    private Vector3 lastDestination;
    private bool isChasingPlayer = false; 
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("No se encontró el componente NavMeshAgent en el GameObject.");
                return;
            }
        }

        waitTimer = waitTime;
        lastDestination = transform.position; 
        MoveToRandomPoint();
    }

    void Update()
    {
        
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            
            isChasingPlayer = true;
            agent.SetDestination(player.position);
        }
        else
        {
            
            isChasingPlayer = false;

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (waitTimer <= 0)
                {
                    MoveToRandomPoint();
                    waitTimer = waitTime;
                }
                else
                {
                    waitTimer -= Time.deltaTime;
                }
            }
        }

        //Vector3 noisePosition = new Vector3(x.y.z);
    }

    void MoveToRandomPoint()
    {
        Vector3 randomPoint;
        NavMeshHit hit;

        do
        {
            
            randomPoint = transform.position + UnityEngine.Random.insideUnitSphere * patrolRange;
            randomPoint.y = transform.position.y; 

        } while (Vector3.Distance(randomPoint, lastDestination) < 10f ||
                 !NavMesh.SamplePosition(randomPoint, out hit, patrolRange, NavMesh.AllAreas));

        // Actualiza el destino del agente
        agent.SetDestination(hit.position);
        lastDestination = hit.position; 
    }
}
