using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{

   
    public GameObject firstPerson;
    public GameObject Blood;
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

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Invoke("Died", 0);
            

            

            Debug.Log("Moriste");
        }
    }

    public void Died()
    {
        Destroy(firstPerson);
        StartCoroutine(Muerte());
        
    }

    public IEnumerator Muerte()
    {
        Blood.SetActive(true);

        yield return new WaitForSeconds(2);
        Debug.Log("Cambio");
        SceneManager.LoadScene("Muerte");
    }


}
