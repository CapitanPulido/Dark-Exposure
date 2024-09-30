using KeySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;

        [SerializeField] private Keyinventori _keyinventori = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            {
                _keyinventori.hasRedkey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
