using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class countdown : MonoBehaviour {
	GameObject ti;
	public GameObject ni;
	public TimeField sssss;
	int end=99;

	// Use this for initialization
	void Start () {
		ni=GameObject.Find("nice");
		ti=GameObject.Find("time");
	}
	// Update is called once per frame
	void Update () {
		if(end>0){
		end=10-(int)Time.time;
        TimeSpan timeSpan = TimeSpan.FromSeconds(end);

        //ni.GetComponent<Text>().text=""+end;
        //d2=00 d3 000 
        ni.GetComponent<Text>().text = string.Format("{0:D2},{1:D2},{2:D2}",timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
		if(end==0)
			ti.GetComponent<Text>().text="倒數計時完畢";
		}
}
