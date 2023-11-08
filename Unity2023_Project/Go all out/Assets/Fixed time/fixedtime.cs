using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fixedtime : MonoBehaviour {
	public Text ti;
	public GameObject ball;//要產生的物件
	int open=1;//開關
	void Start () {
	
	}

	void Update () {

		ti.text=""+(int)Time.time;
		if((int)Time.time==2 & open==1){ //第5秒執行一次 開關 產生球
			open=2;//只執行一次
			Instantiate(ball,new Vector3(0,1,0),Quaternion.identity);


		}

		//同理複製 改2-3 就可自定 掉落時間
		if((int)Time.time==4 & open==2){ //第8秒執行一次 開關 產生球
			open=3;//只執行一次
			Instantiate(ball,new Vector3(0,1,0),Quaternion.identity);
		}




	}

}
