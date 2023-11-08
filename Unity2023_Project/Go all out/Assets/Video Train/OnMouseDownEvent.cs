using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class OnMouseDownEvent : MonoBehaviour
{
    VideoPlayer VP = new VideoPlayer();

    public Transform VideoObject;
    void OnMouseDown()
    {
        VP = VideoObject.GetComponent<VideoPlayer>();
        VP.Stop();//°±¤î
        VP.Play();//¼½©ñ
        print(name);
    }
}
