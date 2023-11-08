using UnityEngine;
using System.Collections;
using System;

public class load : MonoBehaviour {
	void Start () {
		GameObject ax = GameObject.CreatePrimitive(PrimitiveType.Plane);
		//Renderer rend = ax.GetComponent<Renderer>();


		//rend.material.mainTexture = Resources.Load("a") as Texture;
		ax.GetComponent<Renderer>().material.mainTexture= Resources.Load("a") as Texture;

	}

	void Update () {

	}
	

	}

