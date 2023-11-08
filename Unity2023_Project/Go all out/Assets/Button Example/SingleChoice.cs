using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleChoice : MonoBehaviour
{

    public List<Toggle> togglesList = new List<Toggle>();
    public Toggle[] toggleArray;
    public int NowAnswer = 9999;
    public GameObject AlertPanel;
    public Button checkButton;

    private void Awake()
    {
        checkButton.onClick.AddListener(() =>
        {
            this.checkAnswer();
        });
        toggleArray = this.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < toggleArray.Length; i++)
        {
            var index = i;
            //Debug.Log(i);
            toggleArray[index].onValueChanged.AddListener((Flag) =>
            {
                NowAnswer = index;
                //toggleChanged(toggleArray[index], Flag);
                if (Flag)
                {
                    for (int i = 0; i < toggleArray.Length; i++)
                    {
                        if (i != index)
                        {
                            //toggleArray[i].isOn = false;
                            toggleArray[i].SetIsOnWithoutNotify(false);
                            toggleArray[i].interactable = true;
                        }
                        else
                        {
                            toggleArray[i].interactable = false;
                        }
                    }
                }
                
            });


            toggleArray[index].GetComponentInChildren<Text>().text= i.ToString();
        }

    }
    void Start()
    {
    }

    private void toggleChanged(Toggle toggle, bool OnOff)
    {
        //Debug.Log("toggle" + toggle);
        Debug.Log("newValue" + OnOff);
        if (OnOff)
        {
            for (int i = 0; i < toggleArray.Length; i++)
            {
                if (toggleArray[i] != toggle)
                {
                    toggleArray[i].isOn = false;
                    toggleArray[i].interactable = true;
                }
                else
                {
                    toggleArray[i].interactable = false;
                }
            }
        }
    }

    public void checkAnswer()
    {
        if (NowAnswer == 0)
        {
            AlertPanel.SetActive(true);
        }

    }
    void Update()
    {

    }
}
