using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MHP : MonoBehaviour {
		public static float mhp = 1;//宣告環境變數HP
		public GameObject bullet;
	// Use this for initialization
	void Start () {

				//bullet = GameObject.Find ("bullet");
	}
	
	// Update is called once per frame
	void Update () {
				if(Input.GetMouseButtonDown(0)){
						Instantiate (bullet,transform.position,Quaternion.identity);

				}

	}
}
