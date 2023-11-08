using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class bullet : MonoBehaviour {
		public GameObject monsterhp;
	//bullet=	Resources.Load("bu")as GameObject;
	
	//GameObject objPrefab = (GameObject)Resources.Load("bu");

	void Start () {
				monsterhp=GameObject.Find("hp");
	}
	
	// Update is called once per frame
	void Update () {
				gameObject.transform.position += new Vector3 (0, 0, 0.3f);
	}


		void OnCollisionEnter(Collision bu){
				if (bu.gameObject.name == "enemy") {
						Destroy (gameObject);
						MHP.mhp -= 0.1f;

						monsterhp.GetComponent<Image>().fillAmount = MHP.mhp;
						//gameObject.GetComponent("ScriptName");
				}
				//void OnCollisionEnter(Collision ra){       

		}
}
