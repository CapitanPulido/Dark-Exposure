using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory; // Referencia al inventario

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador entra en el trigger
        {
            bool added = inventory.AddItem(gameObject);
            if (added)
            {
                Debug.Log("Objeto recogido: " + gameObject.name);
            }
        }
    }
}