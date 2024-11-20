using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuSFX : MonoBehaviour
{
   

    public Slider Volumen;
    public float SliderValue;


    // Start is called before the first frame update
    void Start()
    {
        Volumen.value = PlayerPrefs.GetFloat("menu song", 1f);
        AudioListener.volume = Volumen.value;

    }

    public void ChangeSlider(float valor)
    {
        SliderValue = valor;
        PlayerPrefs.SetFloat("menu song", SliderValue);
        AudioListener.volume = Volumen.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
