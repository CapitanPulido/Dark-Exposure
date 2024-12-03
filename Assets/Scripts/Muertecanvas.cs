using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muertecanvas : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            StartCoroutine(contador());
        }
    }

    void Update()
    {

    }
    IEnumerator contador()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Muerte");
    }
}
