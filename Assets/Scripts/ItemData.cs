using UnityEngine;

[System.Serializable]
public class ItemData
{
    public bool Removible;
    public bool NoRemovible;

    public string itemName;        // Nombre del objeto
    public Texture itemTexture;    // Textura para mostrar en el Canvas
    public GameObject prefab;      // Prefab o referencia al objeto en el mundo
}

