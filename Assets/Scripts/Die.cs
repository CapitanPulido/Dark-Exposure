using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{

   
    public GameObject firstPerson;
    public GameObject Blood;
    public ControlAudio CA;
    public Canvas muerte;
    

    // Start is called before the first frame update
    void Start()
    {
        Blood.SetActive(false);
        muerte.gameObject.SetActive(false);
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
            Invoke("Died", 3);
            Blood.SetActive(true);

            CA.SFXMuerte();

            Debug.Log("Moriste");
        }
    }

    public void Died()
    {
        Destroy(firstPerson);
        
    }

    IEnumerator Muerte()
    {
        muerte.gameObject.SetActive(true);  
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Muerte");
    }


}
