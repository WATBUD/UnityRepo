using UnityEngine;
using System.Collections;

public class collisionDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += new Vector3 (0.1f, 0, 0);//朝X方向持續持動+0.1
	}
	void OnCollisionEnter(Collision a)//自定碰撞自身a
	{
		if (a.collider.tag == "box") {//如果碰撞標籤名為BOX的物件 則摧毀
			Destroy(gameObject);
            Destroy(a.collider.gameObject);
        }
	}
}
