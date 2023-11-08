using UnityEngine;
using System.Collections;

public class delegatetest : MonoBehaviour {
	delegate void myc(int num);
	myc my ;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		my=c;
		my(50);
		my=d;
		my(50);
	}
	void c(int num)
	{
		print("YES AAAAA" + num);


	}//c

	void d(int num)
	{
		print("YES AAAAA" + num*2);
		
		
	}//c
}
