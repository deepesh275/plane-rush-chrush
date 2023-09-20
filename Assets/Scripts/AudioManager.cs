using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip planeSound;
    public AudioClip missile;
    public AudioClip coin;

    public GameObject pausePanel; 

    private void Start() {
        musicSource.clip = planeSound;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopPlaySound(bool value) 
    {
        if(value == true) {
            musicSource.clip = planeSound;
            musicSource.Stop();
        }
   
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        musicSource.clip = planeSound;
        musicSource.Stop();
    }
    
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        musicSource.clip = planeSound;
        musicSource.Play();
    }
    
    public void QuitButton() {
        Application.Quit();
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

   
}
