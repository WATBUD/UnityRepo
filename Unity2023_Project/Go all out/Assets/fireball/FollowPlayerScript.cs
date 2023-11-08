using UnityEngine;
using System.Collections;

public class FollowPlayerScript : MonoBehaviour {
    public GameObject PlayerObject;
	public Vector3 errortest;
    /*public float XErrorValue;
    public float YErrorValue;
    public float ZErrorValue;*/
   // public bool angleRotato;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.position = new Vector3(PlayerObject.transform.position.x+XErrorValue,PlayerObject.transform.position.y+YErrorValue,PlayerObject.transform.position.z+ZErrorValue);
        
		gameObject.transform.position = (PlayerObject.transform.position)+errortest;



		//if (angleRotato)
        //{
            gameObject.transform.eulerAngles = PlayerObject.transform.eulerAngles;
        //}
	}
}
