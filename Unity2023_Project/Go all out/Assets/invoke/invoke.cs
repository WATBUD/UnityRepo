using UnityEngine;
using System.Collections;

public class invoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating("A",2,0.01f);
	}

	void A () {
		transform.Translate(0.1f,0,0);
	}
}
