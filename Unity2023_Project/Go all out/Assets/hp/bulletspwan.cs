using UnityEngine;
using System.Collections;

public class bulletspwan : MonoBehaviour {
	public GameObject bullet;
	public static float mhp=1;//創造血量
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){//當滑鼠按下左鍵時複製
			Instantiate (bullet, transform.position, Quaternion.identity);
		}

	}
}
