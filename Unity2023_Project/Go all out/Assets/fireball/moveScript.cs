using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {
    public float RunSpeed;
    public Transform Camera_Y;
    float yVelocity=0;
    public float smoothTime;
    public Animator PlayerCharacter;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerCharacter.GetNextAnimatorStateInfo(0).IsName("Run"))
        {
            moveTransform();
        }
        if (PlayerCharacter.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            moveTransform();
        }

    }


    void moveTransform()
    {
        //float CurrentlyAngle;
        float yAngle;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(0, 0, RunSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //CurrentlyAngle = 0;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y , ref yVelocity, smoothTime);


            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //CurrentlyAngle = -45;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y -45, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //CurrentlyAngle = 45;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y +45, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.W))
        {
            //CurrentlyAngle = -90;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y -90, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.W))
        {
            //CurrentlyAngle = 90;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y + 90, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //CurrentlyAngle = -180;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y -180, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            //CurrentlyAngle = -135;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y -135, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            //CurrentlyAngle = 135;
            yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Camera_Y.transform.eulerAngles.y + 135, ref yVelocity, smoothTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        }
    }
   
}
