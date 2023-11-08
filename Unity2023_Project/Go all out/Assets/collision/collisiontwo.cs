using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collisiontwo : MonoBehaviour {

	public int recording;
	public Text pr;
	public GameObject one;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pr.text = recording+"";
		if (Input.GetKey(KeyCode.RightArrow)) {
			gameObject.transform.position+=new Vector3(0.06f,0,0);


			//one=one.gameObject.GetComponent<>();

}

	}

	void OnCollisionEnter(Collision ra){       
		if(ra.gameObject.tag=="box"){
			print("ok");
			recording=100;

		}
}

}