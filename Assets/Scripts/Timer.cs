using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        // timeIsRunning = true;
        // isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeIsRunning) {
        //     if (timeRemaining >= 0 )
        //     {
        //         timeRemaining += Time.deltaTime;
        //         DisplayTime(timeRemaining);
        //     }
        // }
        
            
        
        
    }
    void DisplayTime (float timeToDisplay) {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt (timeToDisplay % 60);
        timeText.text = string.Format ("{00:00} : {01:00}",minutes , seconds);
    }
}
