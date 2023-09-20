using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedSkin;
    public GameObject Player;

    

    private Sprite playersprite;

    void Start() 
    {
        playersprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }
}
