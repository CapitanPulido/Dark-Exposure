using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BateriaC : MonoBehaviour
{
    Linterna linterna;

    public float NumMaxUsos;
    public float NumMinUsos;
    public float NumActualUsos;

    public bool TienesBaterias = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        NumActualUsos = Mathf.Clamp(NumActualUsos, NumMinUsos, NumMaxUsos);

        if (NumActualUsos >= 0)
        {
            TienesBaterias = false;
        }
    }

    public void Bateria()
    {
        linterna.RecargarBateria();
        NumActualUsos -= 1;
    }

    public void ObtuvisteBateria()
    {
        NumActualUsos += 1;
    }
}
