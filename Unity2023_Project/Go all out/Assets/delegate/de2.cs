using UnityEngine;
using System.Collections;

public class de2 : MonoBehaviour {
	delegate void king();
	king first;
	// Use this for initialization
	void Start () {
		first+=p;
		first+=tr;
		//tr();
		first();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void p(){
		print("C");
	}
	void tr(){
		GetComponent<Renderer>().material.color=Color.red;
	}
}
