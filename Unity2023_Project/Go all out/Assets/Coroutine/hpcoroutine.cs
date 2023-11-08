using UnityEngine;
using System.Collections;

public class hpcoroutine : MonoBehaviour {
	
	/*private Char Char1;
	void Awake() {
		Char1 = new Char();
	}*/
	
	void Start () {
		//StartCoroutine(MyCoroutineX(Char1.pos));

		StartCoroutine(scale());
		
		//Char1.addHP(100.0f);
		//StartCoroutine(MyCoroutineY(Char1.pos));
		
		/*for(int i = 1; i < 5; i++)
		{
			Char1.addMp(5.0f);
		}*/
	}
	void Update () {
		/*StartCoroutine(scale());
		StopCoroutine(scale());
         */
	}
	
	/*IEnumerator MyCoroutineX (Vector3 Pos) {
		while(Pos.x < 100)
		{
			Debug.Log("Pos.x: " + Pos.x);
			yield return new WaitForSeconds(0.1f);
			Pos.x += 10;
		}
	}
	
	IEnumerator MyCoroutineY (Vector3 Pos) {
		while(Pos.y < 100)
		{
			Debug.Log("Pos.y: " + Pos.y);
			yield return new WaitForSeconds(0.01f);
			Pos.y += 10;
		}
	}*/

	IEnumerator scale(){
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, Random.Range(-1, 1));
		yield return 0;//報告 我完成了!!
		StopCoroutine(scale());

	}



}

/*public class Char{
	
	private float HP;
	private float MP;
	private Vector3 Pos;
	
	public float hp{
		get{ return HP; }
	}
	public float mp{
		get{ return MP; }
	}
	public Vector3 pos{
		get{ return Pos;}
	}
	
	public Char() {
		HP = 100;
		MP = 100;
		Pos = Vector3.zero;
		Debug.Log("Create Char - HP: " + HP + " ,MP: " + MP + " ,Pos.x: " + Pos.x + " ,Pos.y: " + Pos.y);
	}
	
	public float addHP(float f) {
		HP += f;
		Debug.Log("HP: " + HP);
		return HP;
	}
	
	public float addMp(float f) {
		MP += f;
		Debug.Log("MP: " + MP);
		return MP;
	}
}*/
