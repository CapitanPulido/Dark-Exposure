using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaL : MonoBehaviour
{

    FirstPersonController controller;

    public float NumMaxUsos;
    public float NumMinUsos;
    public float NumActualUsos;

    public bool TienesBaterias = false;

    // Start is called before the first frame update
    void Start()
    {
        NumActualUsos = 0;
    }

    // Update is called once per frame
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
       if (TienesBaterias)
        {
            controller.RecargarBateria();
            NumActualUsos -= 1;
        }
    }

    public void ObtuvisteBateria()
    {
        NumActualUsos += 1;
    }
}
