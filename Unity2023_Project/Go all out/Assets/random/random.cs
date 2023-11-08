using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {
	public float bt;
	public float nt;
	public GameObject ball;

	void Start () {
		nt = Time.time;
		bt = nt;
		//Destroy (gameObject, 4.5f);
	}

	void Update () {
		nt = Time.time;
		if ((nt - bt)>0.4f) 
		{
			bt=nt;
			GameObject anew=Instantiate(ball,new Vector3(Random.Range(-3,3),-2,0),Quaternion.identity) as GameObject;
			anew.GetComponent<Rigidbody>().isKinematic=false;
			anew.GetComponent<Rigidbody>().AddForce(0,Random.Range(500,700),0);
			anew.GetComponent<Rigidbody>().AddTorque(Random.Range(-100f,100f),Random.Range(-100f,100f),Random.Range(-100f,100f));
		}

		/*if (Input.GetButtonDown("Fire1")) {
			Instantiate(ball, new Vector3(0, 0, 0),Quaternion.identity);
		}*/

	}
}
  