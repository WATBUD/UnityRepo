using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {
    public Image icon;// 技能圖
    public float skillCoolDown;//from inspector
    public string skillName,msg;//from inspector
    [SerializeField]
    private float currentCoolDown;
    [SerializeField]
    private int Value;//from inspector
    private Button skillButton;
    /// <summary>
    /// 使用技能傳入技能名稱
    /// </summary>
    /// <param name="usesKillName"></param>
    public void UseSkill(string usesKillName)
    {
        icon.gameObject.SetActive(true);
        icon.fillAmount = 1;
        currentCoolDown = 0;//ButtonCoolDown
        Debug.LogFormat("使用 【{0}】", skillName);
          
        
        this.skillName = usesKillName; 
        skillButton.interactable = false;//Lock Button
    }
  



    void Start()
    {
        skillButton =GetComponent<Button>();//Assign Button Instance
        icon = transform.Find("CoolDownMask").GetComponent<Image>();//Get Skill CoolDownMask Instance
        skillButton.onClick.AddListener(() => this.UseSkill(this.name));//Button Lamda Delegete
        currentCoolDown = skillCoolDown;
    }
    void Update()
    {
        if (currentCoolDown < skillCoolDown)
        {
            // 更新冷却
            currentCoolDown += Time.deltaTime;
            //Debug.LogWarning("currentCoolDown" + currentCoolDown);
            float fillAmount = 1-(currentCoolDown / skillCoolDown);
            Debug.LogWarning("fillAmount" + fillAmount);
            icon.fillAmount = fillAmount;

            if (icon.fillAmount <= 0)
            {
                skillButton.interactable = true;
                icon.gameObject.SetActive(false);

            }
        }
    }

}
