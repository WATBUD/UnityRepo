using UnityEngine;
using System.Collections;

public class changtag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButtonDown(0))//按下滑鼠左鍵則變更TAG
		{
			gameObject.tag="a";
		}
	if(gameObject.tag=="a")//TAG=A時持續移動
		{
			transform.Translate(0.1f,0,0);
		}
		
	}
}
