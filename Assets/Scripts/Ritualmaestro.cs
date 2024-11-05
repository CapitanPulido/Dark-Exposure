using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ritualmaestro : MonoBehaviour
{
    public List<Ritual> gameObjects;
    public int activados;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (activados == 6)
        {
            SceneManager.LoadScene("Final");
        }
    }
}
