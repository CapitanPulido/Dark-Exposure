using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory; // Referencia al inventario
    public bool isplayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador entra en el trigger
        {

            isplayer = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador salio del trigger
        {

            isplayer = false; ;

        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isplayer)
        {
            bool added = inventory.AddItem(gameObject);
            if (added)
            {
                Debug.Log("Objeto recogido: " + gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}