using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class dealdown : MonoBehaviour {
		public GameObject t;
		public GameObject te;
		public int num;
		public  Sprite  c2,c3,c4,c5;

		delegate void king();
		king chan;
		void OnMouseDown ( ) {
				//gameObject.GetComponent<Image>().sprite=Resources.LoadAll("a")  as Sprite;

				//c = te.GetComponent<Image> ().sprite;
			
				te.GetComponent<Image>().sprite=Resources.Load<Sprite>("d") ;
				//te.GetComponent<Image>().sprite=c;

				t.GetComponent<Text>().text="successful"+num;
		}


	void Start ()
		{	
				//c=Resources.Load<Sprite>("Sprites/d") ;
			    c2=Resources.Load<Sprite>("a") ;
				c3=Resources.Load<Sprite>("d") ;
				te=GameObject.Find("b");
				num = Random.Range (1, 10);
				t=GameObject.Find("T") ;
				t.GetComponent<Text>().text="5";
				//t = Text.FindObjectOfType (typeof(Text));
		}
	void Update () {

	}
								
				

}
