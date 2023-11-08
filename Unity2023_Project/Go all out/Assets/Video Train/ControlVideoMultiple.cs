using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlVideoMultiple : MonoBehaviour {

    VideoPlayer VP=new VideoPlayer();
    public List<VideoClip> videos = new List<VideoClip>();
    string ButtonText = "UNLOOP";//不循環
    int videoindex = 0;//不循環
    bool useloop = false;//不循環

    void Start () {
        VP = GetComponent<VideoPlayer>();
        VP.playOnAwake = false;
        // Each time we reach the end, we slow down the playback by a factor of 10.
        VP.loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        videoindex += 1;
        VP.Stop();//停止
        VP.clip = videos[videoindex];//把影片換成影片1
        VP.Play();//播放
        if (videoindex==3)
        {
            videoindex = 0;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void OnGUI()
    {
        if (GUILayout.Button("棋靈王"))
        {
            VP.Stop();//停止
            VP.clip = videos[0];//把影片換成影片0
            VP.Play();//播放
        }
        if (GUILayout.Button("數碼寶貝"))
        {
            VP.Stop();//停止
            VP.clip = videos[1];//把影片換成影片1
            VP.Play();//播放
        }
        if (GUILayout.Button("ITMYLIFE"))
        {
            VP.Stop();//停止
            VP.clip = videos[2];//把影片換成影片2
            VP.Play();//播放
        }

        if (GUILayout.Button("下一首"))
        {
            VP.Stop();//停止
            VP.clip = videos[1];//把影片換成影片1
            VP.Play();//播放
        }
        if (GUILayout.Button("play"))
        {

            VP.Play();
        }
        if (GUILayout.Button("stop"))
        {
            VP.Stop();
        }
        if (GUILayout.Button("Pause"))
        {
            VP.Pause();
        }
        if (GUILayout.Button("Repeat"))
        {
            VP.Stop();
            VP.Play();
        }
        if (GUI.Button(new Rect(0,200,75,25),ButtonText))
        {
            if(useloop==false)
            {
                useloop = true;//bool state
                ButtonText = "loop";//button Text
                VP.isLooping = true;
            }
            else
            {
                useloop = false;//bool state
                ButtonText = "UNLOOP";//button Text
                VP.isLooping = false;
            }
        }


    }
 


}
