using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class time : MonoBehaviour {
	public Text ti;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ti.text = "" + (int)Time.time;
	}
}
