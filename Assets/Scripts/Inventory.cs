using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items; // Lista de objetos en el inventario
    public int maxSlots = 10; // Número máximo de espacios en el inventario

    private void Start()
    {
        items = new List<GameObject>(maxSlots); // Inicializa la lista con el tamaño máximo
    }

    public bool AddItem(GameObject item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item); // Agrega el objeto a la lista
            item.SetActive(false); // Desactiva el objeto en el mundo
            Debug.Log("Objeto añadido al inventario: " + item.name);
            return true;
        }
        else
        {
            Debug.Log("Inventario lleno. No se puede agregar el objeto: " + item.name);
            return false;
        }
    }
}
