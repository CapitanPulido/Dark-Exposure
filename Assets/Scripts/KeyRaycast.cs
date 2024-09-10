using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private int raylength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;
    }
}
