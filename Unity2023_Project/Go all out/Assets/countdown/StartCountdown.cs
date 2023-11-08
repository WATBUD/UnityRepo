using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartCountdown : MonoBehaviour
{
    int countTime=0;
    public Text TimeText;
    public Button countTimeBtn;
    void Start()
    {
        countTimeBtn.onClick.AddListener(()=>{
            this.gameObject.SetActive(false);
            InvokeRepeating("startCount", 1f, 1f);//開始計時
        });




    }
    void Update()
    {
        
    }
    void startCount()
    {
        countTime += 1;//時間+1秒
        TimeText.text = "目前遊戲時間:" + countTime;
    }



}
