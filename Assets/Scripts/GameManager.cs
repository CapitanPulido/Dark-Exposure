using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject Blood;
    public GameObject Pressure;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public IEnumerator Muerte()
    {
        Blood.SetActive(true);
        Pressure.SetActive(false);
        Player.SetActive(false);
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene("Muerte");
    }
}
