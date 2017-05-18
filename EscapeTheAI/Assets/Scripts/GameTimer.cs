using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text display;
    int hours;
    int minutes;
    int seconds;

    string hoursDisplay;
    string minutesDisplay;
    string secondsDisplay;

    public bool active;

	void Start () {
        StartCoroutine(Timer());
	}

    void OnTriggerEnter(Collider t)
    {
        if(t.transform.tag == "Player")
        {
            active = false;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        AddSecond();
    }
	
	public void AddSecond()
    {
        if (active)
        {
            StartCoroutine(Timer());
        }
        seconds++;
        if(seconds == 60)
        {
            seconds = 0;
            minutes++;
            if(minutes == 60)
            {
                minutes = 0;
                hours++;
            }
        }
        DisplayTime();
    }
    public void DisplayTime()
    {
        if (hours < 10)
        {
            hoursDisplay = "0" + hours.ToString();
        }
        else
        {
            hoursDisplay = hours.ToString();
        }
        if(minutes < 10)
        {
            minutesDisplay = "0" + minutes.ToString();
        }
        else
        {
            minutesDisplay = minutes.ToString();
        }
        if (seconds < 10)
        {
            secondsDisplay = "0" + seconds.ToString();
        }
        else
        {
            secondsDisplay = seconds.ToString();
        }
        display.text = hoursDisplay + ":" + minutesDisplay + ":" + secondsDisplay;
    }
}
