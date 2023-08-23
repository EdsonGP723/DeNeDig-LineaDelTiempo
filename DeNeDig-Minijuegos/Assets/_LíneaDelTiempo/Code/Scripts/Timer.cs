using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float delay = 30;
    private bool _timmerIsRunning = false;
    public Text timer;
    void Start(){
        _timmerIsRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        DisplayTime(delay);
        if (_timmerIsRunning){
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        }
        else {
            delay = 0;
            _timmerIsRunning = false;
        }
        
    }

    private void DisplayTime(float timeToDisplay){
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(delay/60);
        float seconds = Mathf.FloorToInt(delay%60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
