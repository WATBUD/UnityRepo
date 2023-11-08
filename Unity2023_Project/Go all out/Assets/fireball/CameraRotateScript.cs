using UnityEngine;
using System.Collections;

public class CameraRotateScript : MonoBehaviour {
    public float mouseSpeed;
    float Distance_c;
    public float Distance_C_Max;
    public float Distance_C_Min;
    public float NearSpeed;
    public GameObject CameraBoxY;
   
    
     Quaternion rotateBox;
     Vector3 cameraPosition;
    public float x;
    public float y;

    // Use this for initialization
    void Start () {
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
	}
	
	// Update is called once per frame
	void Update () {
       

        mouseRotate();
        CameraDistance();
    }
  
    void mouseRotate() {
        
        x += Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        
        y -= Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        if (x>360) {
            x -= 360;
        }
        else if (x<=0)
        {
            x += 360;
        }
        if (y > 60)
        {
            y = 60;
        } else if (y<-5) {
            y = -5;
        }
            rotateBox = Quaternion.Euler(y,x,0);
            cameraPosition = rotateBox * new Vector3(0, 0, -Distance_c) + CameraBoxY.transform.position;
        transform.rotation = rotateBox;
        transform.position = cameraPosition;
        



    }
    void CameraDistance()
    {

        Distance_c-= Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*500;
        Distance_c = Mathf.Clamp(Distance_c, Distance_C_Min, Distance_C_Max);
        
    }
}
