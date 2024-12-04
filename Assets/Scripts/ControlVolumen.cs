using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{

    public AudioMixer Master;
    public Slider MasterSlider;

    public void Awake()
    {
        MasterSlider.onValueChanged.AddListener(ControlMasterVolumen);
    }
    void Start()
    {
        Cargar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ControlMasterVolumen(float valor)
    {
        Master.SetFloat("VolumenMaster" , Mathf.Log(valor) * 20);
        PlayerPrefs.SetFloat("VolumeMaster", MasterSlider.value);
    }

    public void Cargar()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("VolumenMaster", 0.75f);
        ControlMasterVolumen(MasterSlider.value);
    }
}
