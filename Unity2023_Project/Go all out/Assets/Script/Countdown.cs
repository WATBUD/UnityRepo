using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    [SerializeField] public Text countdownText;
    [SerializeField] public int secoend;
    [SerializeField] public float waitTime;
    public delegate void ValueChange();
    public ValueChange fun;

    public Countdown(string name ,int value){

        secoend= value;
        this.name = name;
    }


    void Start () {

        countdownText = transform.Find("Text").GetComponent<Text>();
        InvokeRepeating("Repeat", waitTime, 1f);
    }
    void Repeat()
    {
        if (secoend > 0) {
            secoend -= 1;
            countdownText.text = name+ secoend.ToString();
        }
        else
        {
            if (fun != null)
                fun();
            Destroy(this);//我已達成任務可以去了~~~
            //gameObject.SetActive(false);
        }
  
    }

    // Update is called once per frame
    void Update () {
		
	}
}
