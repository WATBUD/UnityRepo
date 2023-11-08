using UnityEngine;
using System.Collections;

public class mouseuse : MonoBehaviour {
	//public Vector3 currentInputWorldPos;
	//public Ray a;
	public Camera cone;
	public GameObject cu;
	public GameObject aaa;
	public RaycastHit xa;
	public Vector3 mousepos;
	// Use this for initialization
	void Start () {
		//cone = GetComponent<Camera>();
		aaa=GameObject.Find("mc");
	    cone=aaa.GetComponent<Camera>();

		//cu= GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		//currentInputWorldPos= Camera.main.ScreenToWorldPoint( Input.mousePosition );
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		//mousepos = Input.mousePosition;

		Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
		if (Physics.Raycast (ray, out xa)) {

			Debug.Log ("aaa");
			if (xa.collider.name == "b") {
				cu.transform.position = new Vector3 (xa.point.x, xa.point.y, xa.point.z-10);
			}
		}

	}

	
	}



