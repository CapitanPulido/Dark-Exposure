using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items; // Todos los objetos en el inventario
    public List<GameObject> removableItems; // Objetos que se pueden sacar
    public List<GameObject> nonRemovableItems; // Objetos que no se pueden sacar
    public List<RawImage> inventorySlots; // Referencia a los espacios en el Canvas
    public int maxSlots = 10; // N�mero m�ximo de espacios en el inventario
    public Transform handTransform; // Punto donde el objeto se coloca en la mano del jugador

    private GameObject equippedItem; // Objeto actualmente en la mano
    private GameObject selectedItem; // Objeto seleccionado en el inventario

    //public Button equipButton; // Referencia al bot�n de equipar
    //public Button dropButton; // Referencia al bot�n de soltar
    public Canvas canvas;

    private void Start()
    {
        items = new List<GameObject>(maxSlots);
        
        canvas.enabled = false;
        

        //equipButton.onClick.AddListener(EquipSelectedItem);
        //dropButton.onClick.AddListener(DropSelectedItem);
    }

    private void Update()
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

        //// Detecta clic en un slot del inventario
        //if (canvas.enabled && Input.GetMouseButtonDown(0))
        //{
        //    CheckInventoryClick();
        //}

        // Soltar el objeto equipado al presionar "G"
        if (equippedItem != null && Input.GetKeyDown(KeyCode.G))
        {
            DropEquippedItem();
        }

        // Lanzar el objeto equipado al presionar la rueda del rat�n
        if (equippedItem != null && Input.GetMouseButtonDown(2))
        {
            ThrowEquippedItem();
        }
    }

    // M�todo para agregar un objeto al inventario y especificar si es removible
    public bool AddItem(GameObject item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item); // Agrega el objeto a la lista
            item.SetActive(false); // Desactiva el objeto en el mundo

            // Obt�n la textura desde el componente KeyPickUp
            KeyPickUp keyPickUp = item.GetComponent<KeyPickUp>();
            if (keyPickUp != null)
            {
                // Encuentra el primer espacio vac�o en el Canvas y asigna la textura
                for (int i = 0; i < inventorySlots.Count; i++)
                {
                    if (inventorySlots[i].texture == null)
                    { // Comprueba si el espacio est� vac�o
                        inventorySlots[i].texture = keyPickUp.keyimage; // Asigna la textura desde KeyPickUp
                        break;
                    }
                }
            }

            Debug.Log("Objeto a�adido al inventario: " + keyPickUp.itemName);
            return true;
        }
        else
        {
            Debug.Log("Inventario lleno. No se puede agregar el objeto: " + item.name);
            return false;
        }
    }

    // M�todo para remover un objeto, solo si est� en removableItems
    public bool RemoveItem(GameObject item)
    {
        if (removableItems.Contains(item))
        {
            int itemIndex = items.IndexOf(item);

            if (itemIndex != -1)
            {
                items.RemoveAt(itemIndex);
                removableItems.Remove(item);
                inventorySlots[itemIndex].texture = null;

                GameObject instance = Instantiate(item, handTransform.position, handTransform.rotation);
             
                Debug.Log("Objeto eliminado e instanciado en la posici�n de la mano: " + item.name);
                return true;
            }
        }
        else
        {
            Debug.Log("Este objeto no se puede sacar del inventario: " + item.name);
        }
        return false;
    }

    //private void CheckInventoryClick()
    //{
    //    // Detecta el objeto sobre el cual se hizo clic
    //    for (int i = 0; i < inventorySlots.Count; i++)
    //    {
    //        if (RectTransformUtility.RectangleContainsScreenPoint(inventorySlots[i].rectTransform, Input.mousePosition))
    //        {
    //            if (items.Count > i)
    //            {
    //                selectedItem = items[i]; // Obt�n el objeto seleccionado
    //                equipButton.gameObject.SetActive(true); // Activa el bot�n de equipar
    //                dropButton.gameObject.SetActive(true); // Activa el bot�n de soltar
    //                break;
    //            }
    //        }
    //    }
    //}

    public void EquipSelectedItem()
    {
        if (selectedItem != null)
        {
            EquipItem(selectedItem);
            //ClearSelection();
        }
    }

    public void DropSelectedItem()
    {
        if (selectedItem != null)
        {
            DropEquippedItem();
            RemoveItem(selectedItem);
            //ClearSelection();
        }
    }

    //private void ClearSelection()
    //{
    //    selectedItem = null; // Limpia la selecci�n
    //    equipButton.gameObject.SetActive(false); // Desactiva el bot�n de equipar
    //    dropButton.gameObject.SetActive(false); // Desactiva el bot�n de soltar
    //}

    private void DropEquippedItem()
    {
        if (equippedItem != null)
        {
            equippedItem.transform.parent = null; // Separa el objeto de la mano
            equippedItem.SetActive(true); // Asegura que est� visible

            // Posiciona el objeto en la posici�n del jugador
            equippedItem.transform.position = transform.position + new Vector3(0, 0.5f, 0); // Ajusta la altura si es necesario
            Rigidbody rb = equippedItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 5f, ForceMode.Impulse); // Aplica una fuerza para que caiga hacia adelante
            }

            Debug.Log("Objeto soltado: " + equippedItem.name);
            equippedItem = null; // Libera el espacio de la mano
        }
    }

    private void ThrowEquippedItem()
    {
        if (equippedItem != null)
        {
            equippedItem.transform.parent = null; // Separa el objeto de la mano
            equippedItem.SetActive(true); // Asegura que est� visible

            // Posiciona el objeto en la posici�n del jugador
            equippedItem.transform.position = transform.position + new Vector3(0, 0.5f, 0); // Ajusta la altura si es necesario
            Rigidbody rb = equippedItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 50f, ForceMode.Impulse); // Lanza el objeto hacia adelante
            }

            Debug.Log("Objeto lanzado: " + equippedItem.name);
            equippedItem = null; // Libera el espacio de la mano
        }
    }

    public bool EquipItem(GameObject item)
    {
        if (item != null)
        {
            equippedItem = item; // Asigna el objeto a la mano
            items.Remove(item); // Remueve el objeto de la lista del inventario

            // Encuentra y libera el espacio en el Canvas
            int itemIndex = items.IndexOf(item);
            if (itemIndex != -1)
            {
                inventorySlots[itemIndex].texture = null;
            }

            equippedItem.SetActive(true); // Activa el objeto
            equippedItem.transform.position = handTransform.position; // Posici�nalo en la mano
            equippedItem.transform.parent = handTransform; // Haz que siga la mano
            Debug.Log("Objeto equipado: " + item.name);
            return true;
        }
        return false;
    }
}

