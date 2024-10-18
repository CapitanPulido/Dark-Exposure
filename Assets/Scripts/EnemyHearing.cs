using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHearing : MonoBehaviour
{
    public float hearingRadius = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    public void OnSoundEvent(Vector3 soundPosition)
    {
        float distanceToSound = Vector3.Distance(transform.position, soundPosition);

        if (distanceToSound <= hearingRadius)
        {
            Debug.Log("moviendo a a ubicación de sonido");
            agent.SetDestination(soundPosition);
        }
    }
}
