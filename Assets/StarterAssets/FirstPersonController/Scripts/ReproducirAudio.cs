using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAudio : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float soundRange = 10f;
    public AudioSource audioSource;
    public Enemy enemy;

    // Emitir sonido y notificar a enemigos cercanos
    public void EmitSound()
    {
        audioSource.Play();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, soundRange, enemyLayer);
        foreach (var hitCollider in hitColliders)
        {
            EnemyHearing enemyHearing = hitCollider.GetComponent<EnemyHearing>();
            if (enemyHearing != null)
            {
                // Envía la posición del sonido al enemigo
                enemyHearing.OnSoundEvent(transform.position);
            }
        }
    }

    void Update()
    {
        //// Emite el sonido al presionar la tecla Space
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    EmitSound();
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Emite sonido al tocar el "Suelo"
        if (collision.gameObject.CompareTag("Suelo"))
        {
            EmitSound();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SeguirRuido();
            enemy.MoveToRandomPoint();
        }
    }

   
    IEnumerator SeguirRuido()
    {
        Debug.Log("Moviendo");

        yield return new WaitForSeconds(3);
        enemy.MoveToRandomPoint();
    }
}

