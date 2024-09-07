using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;       // Referencia al componente NavMeshAgent
    public float patrolRange = 10f;  // Rango dentro del cual se patrullará
    public float waitTime = 2f;      // Tiempo de espera en cada punto

    private float waitTimer;         // Temporizador para el tiempo de espera

    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (agent != null)
        {
            MoveToRandomPoint();
        }
    }

    void Update()
    {
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

    void MoveToRandomPoint()
    {
        Vector3 randomPoint = transform.position + UnityEngine.Random.insideUnitSphere * patrolRange;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, patrolRange, NavMesh.AllAreas))
        {
            // Mueve el agente al punto aleatorio
            agent.SetDestination(hit.position);
        }
    }
}


