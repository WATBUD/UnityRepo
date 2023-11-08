using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyControlVideo : MonoBehaviour {

    VideoPlayer playVideo=new VideoPlayer();
    string ButtonText = "UNLOOP";//不循環

    bool useloop = false;//不循環

    void Start () {
        playVideo = GetComponent<VideoPlayer>();
        playVideo.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        if (GUILayout.Button("play"))
        {
            playVideo.Play();
        }
        if (GUILayout.Button("stop"))
        {
            playVideo.Stop();
        }
        if (GUILayout.Button("Pause"))
        {
            playVideo.Pause();
        }
        if (GUILayout.Button("Repeat"))
        {
            playVideo.Stop();
            playVideo.Play();
        }
        if (GUI.Button(new Rect(0,100,75,25),ButtonText))
        {
            if(useloop==false)
            {
                useloop = true;//bool state
                ButtonText = "loop";//button Text
                playVideo.isLooping = true;
            }
            else
            {
                useloop = false;//bool state
                ButtonText = "UNLOOP";//button Text
                playVideo.isLooping = false;
            }
        }


    }
}
