using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class v : MonoBehaviour {
		public int d;
		public Text a;
		public int[] array = new int[10];
		//public int[,] array = new int[10, 20];

	void Start () {
				xd ();

	}
	
	// Update is called once per frame
		void Update () {


	}
		void xd (){
				for (int i=0; i < 10; ++i)
				{
						array [i] = i;
								print (array [i].ToString ());
								print ("無名");

				}

		}
}

