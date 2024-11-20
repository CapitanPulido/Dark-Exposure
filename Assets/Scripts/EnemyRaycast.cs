using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public RaycastHit hit;
    public float range = 10f; // Rango del campo de visi�n
    public LayerMask detectionLayer; // Capa que contiene obst�culos y jugadores
    public Enemy enemy;

    private void FixedUpdate()
    {
        // Configuraci�n del campo de visi�n de 120 grados con 12 rayos
        for (int i = -60; i <= 60; i += 10)
        {
            // Calcula la direcci�n del rayo en el �ngulo correspondiente
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            Vector3 rayDirection = rotation * transform.forward;

            // Lanza el raycast en la direcci�n calculada
            if (Physics.Raycast(transform.position, rayDirection, out hit, range, detectionLayer))
            {
                // Si detecta un obst�culo o al jugador
                if (hit.collider.CompareTag("Player"))
                {
                    // Detecta al jugador si no hay obst�culos en medio
                    Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.red);
                    Debug.Log("Jugador detectado sin obst�culos: " + hit.collider.gameObject.name);
                    enemy.MoveToPlayerPosition();
                }
                else
                {
                    // Impact� en un obst�culo (bloquea la visi�n)
                    Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.yellow);
                }
            }
            else
            {
                // Si no impacta ning�n objeto dentro del rango
                Debug.DrawRay(transform.position, rayDirection * range, Color.blue);
            }
        }
    }
}