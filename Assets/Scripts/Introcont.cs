using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introcont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(contador());
    }


    void Update()
    {

    }
    IEnumerator contador()
    {

        yield return new WaitForSeconds(51);
        SceneManager.LoadScene("Pruebas_Rick");
    }
}
