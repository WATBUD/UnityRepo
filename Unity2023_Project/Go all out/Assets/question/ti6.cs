using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ti6 : MonoBehaviour {
	public Text ti;
	void Start () {
	
	}
				
	void Update () {
				ti.text=""+((int) Time.time)%60;
	}
}
