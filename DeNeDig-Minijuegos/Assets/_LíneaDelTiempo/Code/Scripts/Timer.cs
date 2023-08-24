using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float delay;
    public float limitTime;
    private bool _timmerIsRunning = false;
    public TextMeshProUGUI timer;
    void Start(){
        _timmerIsRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        DisplayTime(delay);
        if (_timmerIsRunning == true){
        if (delay < limitTime)
        {
            delay += Time.deltaTime;
        }
        else {
            _timmerIsRunning = false;
            delay = limitTime;
        }
        }
        
    }

    private void DisplayTime(float timeToDisplay){
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(delay/60);
        float seconds = Mathf.FloorToInt(delay%60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
