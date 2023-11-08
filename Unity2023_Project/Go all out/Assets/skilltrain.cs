using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilltrain : MonoBehaviour {

    public Image icon;
    public float skillCooldown, currentCoolDown;//5,currentCoolDown=5,
    public Button skillButton;
    void Start() {
        skillButton.onClick.AddListener(() => this.useSkill());//按鈕點擊加入技能方法
        currentCoolDown = skillCooldown;
    }
    public void useSkill(){
        icon.gameObject.SetActive(true);
        currentCoolDown = 0;
        Debug.LogFormat("你使用了技能{0}", "DEF上升術");

        skillButton.interactable = false;//按鈕不能按

    }   
	// Update is called once per frame
	void Update () {
        if (currentCoolDown<skillCooldown)
        {
            currentCoolDown += Time.deltaTime;
            float fillAmountValue = 1 - (currentCoolDown / skillCooldown);
            icon.fillAmount = fillAmountValue;
            if (icon.fillAmount<=0)
            {
                skillButton.interactable = true; //按鈕開啟
                icon.gameObject.SetActive(false); //關閉
            }
        }
	}
}
