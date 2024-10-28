using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemData> allItems;            // Lista de todos los objetos disponibles
    public List<GameObject> items;             // Lista de objetos en el inventario actual
    public List<RawImage> inventorySlots;      // Referencia a los espacios en el Canvas
    public int maxSlots = 10;                  // Número máximo de espacios en el inventario
    public Transform handTransform;            // Punto donde el objeto se coloca en la mano del jugador
    private GameObject equippedItem;           // Objeto actualmente en la mano
    private GameObject selectedItem;           // Objeto seleccionado en el inventario
    public Button equipButton;                 // Referencia al botón de equipar
    public Button dropButton;                  // Referencia al botón de soltar

    public Canvas canvas;

    private void Start()
    {
        items = new List<GameObject>(maxSlots); // Inicializa la lista de objetos en el inventario
        canvas.enabled = false;

        // Desactivar los botones al inicio
        equipButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(false);

        // Asignar los eventos a los botones
        equipButton.onClick.AddListener(EquipSelectedItem);
        dropButton.onClick.AddListener(DropSelectedItem);
    }

    public void Update()
    {
        // Abrir y cerrar inventario al presionar "Tab"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = true;
            Cursor.lockState = CursorLockMode.None; // Libera el cursor
            Cursor.visible = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            canvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false;
        }

        // Detecta clic en un slot del inventario
        if (canvas.enabled && (Input.GetMouseButtonDown(0)))
        {
            CheckInventoryClick(); // Pasa si es clic izquierdo
        }

        // Soltar el objeto equipado al presionar "G"
        if (equippedItem != null && Input.GetKeyDown(KeyCode.G))
        {
            DropEquippedItem();
        }

        // Lanzar el objeto equipado al presionar la rueda del raton
        if(equippedItem != null && Input.GetMouseButtonDown(2))
        {
            ThrowEquippedItem();
        }
    }

    public bool AddItem(GameObject item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item); // Agrega el objeto a la lista
            item.SetActive(false); // Desactiva el objeto en el mundo

            // Busca en allItems la textura asociada a este objeto
            ItemData itemData = allItems.Find(data => data.prefab == item);
            if (itemData != null)
            {
                // Encuentra el primer espacio vacío en el Canvas y asigna la textura del objeto
                for (int i = 0; i < inventorySlots.Count; i++)
                {
                    if (inventorySlots[i].texture == null) // Comprueba si el espacio está vacío
                    {
                        inventorySlots[i].texture = itemData.itemTexture; // Asigna la textura
                        break;
                    }
                }
                Debug.Log("Objeto añadido al inventario: " + itemData.itemName);
                return true;
            }
            else
            {
                Debug.LogWarning("El objeto no se encuentra en la lista general de items.");
                return false;
            }
        }
        else
        {
            Debug.Log("Inventario lleno. No se puede agregar el objeto: " + item.name);
            return false;
        }
    }

    public bool RemoveItem(GameObject item)
    {
        int itemIndex = items.IndexOf(item);
        if (itemIndex != -1)
        {
            items.RemoveAt(itemIndex); // Remueve el objeto de la lista
            item.SetActive(true); // Reactiva el objeto en el mundo

            // Libera el espacio en el Canvas
            inventorySlots[itemIndex].texture = null;

            Debug.Log("Objeto eliminado del inventario: " + item.name);
            return true;
        }
        else
        {
            Debug.Log("El objeto no se encuentra en el inventario: " + item.name);
            return false;
        }
    }


    // Método para equipar un objeto desde el inventario
    public bool EquipItem(GameObject item)
    {
        if (item != null)
        {
            equippedItem = item; // Asigna el objeto a la mano
            items.Remove(item); // Remueve el objeto de la lista del inventario
            int itemIndex = inventorySlots.FindIndex(slot => slot.texture != null && slot.texture == allItems.Find(data => data.prefab == item).itemTexture);
            if (itemIndex != -1)
            {
                inventorySlots[itemIndex].texture = null; // Libera el espacio en el Canvas
            }

            equippedItem.SetActive(true); // Activa el objeto
            equippedItem.transform.position = handTransform.position; // Posiciónalo en la mano
            equippedItem.transform.parent = handTransform; // Haz que siga la mano

            Debug.Log("Objeto equipado: " + item.name);
            return true;
        }
        return false;
    }

    private void DropEquippedItem()
    {
        if (equippedItem != null)
        {
            equippedItem.transform.parent = null; // Separa el objeto de la mano
            equippedItem.SetActive(true); // Asegura que esté visible

            // Posiciona el objeto en la posición del jugador
            equippedItem.transform.position = transform.position + new Vector3(0, 0.5f, 0); // Ajusta la altura si es necesario

            Rigidbody rb = equippedItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Asegúrate de que no sea kinemático
                rb.AddForce(Camera.main.transform.forward * 5f, ForceMode.Impulse); // Aplica una fuerza para que caiga hacia adelante
            }

            Debug.Log("Objeto soltado: " + equippedItem.name);
            equippedItem = null; // Libera el espacio de la mano
        }
    }

    private void CheckInventoryClick()
    {
        // Detecta el objeto sobre el cual se hizo clic
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(inventorySlots[i].rectTransform, Input.mousePosition))
            {
                if (items.Count > i)
                {
                    selectedItem = items[i]; // Obtén el objeto seleccionado
                    equipButton.gameObject.SetActive(true); // Activa el botón de equipar
                    dropButton.gameObject.SetActive(true); // Activa el botón de soltar
                    break;
                }
            }
        }
    }

    public void EquipSelectedItem()
    {
        if (selectedItem != null)
        {
            EquipItem(selectedItem);
            ClearSelection();
        }
    }

    public void DropSelectedItem()
    {
        if (selectedItem != null)
        {
            DropEquippedItem();
            RemoveItem(selectedItem);
            ClearSelection();
        }
    }

    private void ClearSelection()
    {
        selectedItem = null; // Limpia la selección
        equipButton.gameObject.SetActive(false); // Desactiva el botón de equipar
        dropButton.gameObject.SetActive(false); // Desactiva el botón de soltar
    }

    private void ThrowEquippedItem()
    {
        if (equippedItem != null)
        {
            equippedItem.transform.parent = null; // Separa el objeto de la mano
            equippedItem.SetActive(true); // Asegúrate de que esté visible

            // Posiciona el objeto en la posición del jugador
            equippedItem.transform.position = transform.position + new Vector3(0, 0.5f, 0); // Ajusta la altura si es necesario

            Rigidbody rb = equippedItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Asegúrate de que no sea kinemático
                                        // Lanza el objeto hacia adelante con una fuerza
                Vector3 throwDirection = Camera.main.transform.forward; // Dirección en la que se ve la cámara
                rb.AddForce(throwDirection * 50f, ForceMode.Impulse); // Ajusta la fuerza según sea necesario
            }

            Debug.Log("Objeto lanzado: " + equippedItem.name);
            equippedItem = null; // Libera el espacio de la mano
        }
    }
}
