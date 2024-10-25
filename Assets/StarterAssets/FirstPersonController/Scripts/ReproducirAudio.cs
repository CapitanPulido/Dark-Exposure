using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAudio : MonoBehaviour
{ 
    public LayerMask enemyLayer;
    public float soundRange = 10f;
    public AudioSource x;
    public Enemy enemy;

    public void EmitSound()
    {
        x.Play();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, soundRange, enemyLayer);

       

        if(hitColliders.Length == 1)
        
        {
            foreach (var hitCollider in hitColliders)
            {

                EnemyHearing enemyHearing = hitCollider.GetComponent<EnemyHearing>();
                if (enemyHearing != null)
                {
                    enemyHearing.OnSoundEvent(transform.position);


                }
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitSound();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            EmitSound();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.MoveToRandomPoint();
            Debug.Log("Ya llegue");
        }
    }

}

