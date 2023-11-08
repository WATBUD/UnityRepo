using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinuePlayingMusic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene("music2");//¤Á´«³õ´º

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
