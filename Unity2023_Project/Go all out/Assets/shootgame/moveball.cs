using UnityEngine;
using System.Collections;

public class moveball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position+=new Vector3(0.1f,0,0);
		}
		if(Input.GetKey(KeyCode.LeftArrow))

		{
			gameObject.transform.position+=new Vector3(-0.1f,0,0);
		}
	
	}
}
