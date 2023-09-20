using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSound : MonoBehaviour
{

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    // [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip sliderBtn;
    // Start is called before the first frame update
    public void SliderButtonSound()
    {
        musicSource.clip = sliderBtn;
        musicSource.Play();
        
    }

}
