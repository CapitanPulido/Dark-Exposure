using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saltarintro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Salto());
        }
    }

    IEnumerator Salto()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Pruebas_Rick");
    }
}
