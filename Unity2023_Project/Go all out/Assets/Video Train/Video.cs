using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {
    VideoPlayer videoPlayer;

    bool useloop = false;
    string buttonText = "UNLOOP";
    // Use this for initialization
    void Start () {
        videoPlayer = this.GetComponent<VideoPlayer>();
        //videoPlayer.loopPointReached += EndReached;//当前clip播放完成调用
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;//切換模式

        //videoPlayer.SetTargetAudioSource(0, this.GetComponent<AudioSource>());
        //videoPlayer.playOnAwake = false;
        //videoPlayer.IsAudioTrackEnabled(0);
        //videoPlayer.clip = videoPlayer.clip;
        //videoPlayer.Play();
        //videoPlayer.SetTargetAudioSource(0, this.GetComponent<AudioSource>());
    }
    private void OnGUI()
    {
        if (GUILayout.Button("Pause"))
        {
            if (videoPlayer.isPlaying)
            {

                videoPlayer.Pause();
            }

        }
        if (GUILayout.Button("Play"))
        {
            if (!videoPlayer.isPlaying)
            {

                videoPlayer.Play();
            }

        }
        if (GUILayout.Button("Replay"))
        {
                videoPlayer.Stop();
                videoPlayer.Play();
            

        }
        if (GUI.Button(new Rect(0, 75, 75, 25), buttonText))
          
            if (useloop == false)
            {
                useloop = true;
                buttonText = "loop";
                videoPlayer.isLooping = true;
            }
            else
            {
                useloop = false;
                videoPlayer.isLooping = false;
                buttonText = "UNLoop";
            }
        }
    
      
        


    

    void Update () {
		
	}
}
