using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class MouseDownTest : MonoBehaviour
{
    VideoPlayer Vp = new VideoPlayer();
    public Transform VideoObject;
    void Start()
    {
        //Vp = VideoObject.GetComponent<VideoPlayer>();

        //Vp.Play();
    }



    void OnMouseDown()
    {
        Vp = VideoObject.GetComponent<VideoPlayer>();

        Vp.Stop();

        Vp.Play();
    }

}
