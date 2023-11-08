using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {
    public GameObject Player;

    public float DistancePlayer;

    public float enemySpeed;

    Animator myAnimator;
	void Start () {
        Player = GameObject.FindWithTag("Player");
        myAnimator = GetComponent<Animator>();
	}

	void Update () {
        Vector3 me = new Vector3(Player.transform.position.x,0,Player.transform.position.z);


		transform.LookAt(Player.transform.position);

		if (Vector3.Distance(transform.position,me)>=DistancePlayer && !myAnimator.GetBool("att")) {
			 
			
			transform.Translate(new Vector3(0,0,enemySpeed)*Time.deltaTime);

            //myAnimator.SetBool("Run",true);
			myAnimator.SetBool("run",true);
			//myAnimator.SetBool("att",false);

        }


         if (Vector3.Distance(transform.position, me) < DistancePlayer)


        {
            
            //myAnimator.SetBool("Run", false);
			myAnimator.SetBool("att",true);

        }
		if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walk")){

			myAnimator.SetBool("att",false);

		}
			




}
}
