using UnityEngine;
using System.Collections;

public class abreturn : MonoBehaviour {
		public int resultA = 1;
		public int resultB = 2;
		public int resultC = 3;
		public int a=100;
	// Use this for initialization
	void Start () {
				xd();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		public	void xd()
		{

				a = resultA + a;	
				resultC = a;
				resultB = function2(a) + 10;

		}
		int function2(int a)
		{
				return a++;
		}

	
}

