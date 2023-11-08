using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gat : MonoBehaviour {
	public Transform[] a;
	//public Component[] hingeJoints;
	// Use this for initialization
	void Start () {

	a = GetComponentsInChildren<Transform>();//取得底下所有的運輸位置
		a [1].gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
