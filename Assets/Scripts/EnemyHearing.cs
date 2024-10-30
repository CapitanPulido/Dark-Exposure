using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHearing : MonoBehaviour
{
    public float hearingRadius;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Método para reaccionar ante eventos de sonido
    public void OnSoundEvent(Vector3 soundPosition)
    {
        float distanceToSound = Vector3.Distance(transform.position, soundPosition);

        if (distanceToSound <= hearingRadius)
        {
            Debug.Log("Moviendo a la ubicación de sonido: " + soundPosition);
            agent.SetDestination(soundPosition);
        }
    }
}


