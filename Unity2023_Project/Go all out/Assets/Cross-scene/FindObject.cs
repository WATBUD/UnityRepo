using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hand;
    void Start()
    {
        hand = GameObject.Find("Dont");
        Destroy(hand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
