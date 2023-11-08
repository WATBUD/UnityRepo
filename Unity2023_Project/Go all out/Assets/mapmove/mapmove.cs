using UnityEngine;
using System.Collections;

public class mapmove : MonoBehaviour {
	public float off;
    public float offset;
    public bool CUSTOM;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        offset = -Time.time * 0.2f;

        if (CUSTOM == true)
        {
            GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, off);
        }
        else
        {
            GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, offset);
        }

	}
}
