using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class main : MonoBehaviour {
	public GameObject hp;
	// Use this for initialization
	void Start () {
		hp=GameObject.Find("hp");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, 0, 0.2f);
	}
	void OnCollisionEnter(Collision a){
		if (a.gameObject.name == "enemy") {//如果子彈碰撞名稱為ENEMY的物件則執行
			Destroy(gameObject);
			bulletspwan.mhp-=0.1f;
			hp.GetComponent<Image>().fillAmount=bulletspwan.mhp;
		}

	}

}
