using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public RaycastHit hit;
    public float range = 10f; // Rango del campo de visión
    public LayerMask detectionLayer; // Capa que contiene obstáculos y jugadores
    public Enemy enemy;

    private void FixedUpdate()
    {
        // Configuración del campo de visión de 120 grados con 12 rayos
        for (int i = -60; i <= 60; i += 10)
        {
            // Calcula la dirección del rayo en el ángulo correspondiente
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            Vector3 rayDirection = rotation * transform.forward;

            // Lanza el raycast en la dirección calculada
            if (Physics.Raycast(transform.position, rayDirection, out hit, range, detectionLayer))
            {
                // Si detecta un obstáculo o al jugador
                if (hit.collider.CompareTag("Player"))
                {
                    // Detecta al jugador si no hay obstáculos en medio
                    Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.red);
                    Debug.Log("Jugador detectado sin obstáculos: " + hit.collider.gameObject.name);
                    enemy.MoveToPlayerPosition();
                }
                else
                {
                    // Impactó en un obstáculo (bloquea la visión)
                    Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.yellow);
                }
            }
            else
            {
                // Si no impacta ningún objeto dentro del rango
                Debug.DrawRay(transform.position, rayDirection * range, Color.blue);
            }
        }
    }
}