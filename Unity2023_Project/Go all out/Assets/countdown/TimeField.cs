using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeField : MonoBehaviour {


    public UnityEngine.UI.Text timerLabel; //#2
    private float temp;

    void Start()
    {

    }

    void Update()
    {
        temp += Time.deltaTime; //#3
        DateTime localDate = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4

        string timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
        //timerLabel.text = timerText; //#6
        timerLabel.text = DateTime.Now.ToString("HH:mm:ss"); //#6

        

        //TimeSpan time = TimeSpan.FromSeconds(10000);
        //string str = time.ToString(@"hh\:mm\:ss\:fff");
    }


}

