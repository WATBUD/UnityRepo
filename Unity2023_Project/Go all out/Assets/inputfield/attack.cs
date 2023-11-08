using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	//public	GameObject a;
	//public Vector3 me;
	public GameObject model;
	public Vector3 raypos;
	public Vector3 player;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				float step = speed * Time.deltaTime;
				player = model.transform.position;
				Ray me = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)



				RaycastHit hit;
				if (Physics.Raycast (me, out hit)){
						
						if (Input.GetMouseButtonDown (0)) {
								if (hit.collider.gameObject.name == "P") {
										raypos = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
									
								}

						}
				}
				if(Vector3.Distance(model.transform.position,raypos)>10f){

						model.transform.position = Vector3.MoveTowards(model.transform.position,raypos,step);
				}
			



				/*if (Input.GetMouseButtonDown (0)) 
			Instantiate (a, me*10,Quaternion.identity);
*/
	}
}
