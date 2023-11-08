using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;

public class dynamic : MonoBehaviour {
	public Sprite[] sparray= new Sprite[4];
	public SpriteRenderer mainrenderer;
	public float ti;
	public int inti;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		ti += Time.deltaTime;
		inti = (int)ti;
		if (ti>4)
		{
			ti=0;
		}
		mainrenderer.sprite=sparray[inti];

	}
}
