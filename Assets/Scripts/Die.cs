using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

   
    public GameObject firstPerson;
    public GameObject Blood;

    // Start is called before the first frame update
    void Start()
    {
        Blood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    Died();
        //}
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Died();
        }
    }

    public void Died()
    {
        Destroy(firstPerson);
        Blood.SetActive(true);

        Debug.Log("Moriste");
    }
}
