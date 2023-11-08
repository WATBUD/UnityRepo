using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleChoiceGroup : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public string NowAnswer = "1";
    public GameObject AlertPanel;
    public Button checkButton;

    void Start()
    {
        checkButton.onClick.AddListener(() =>
        {
            this.checkAnswer();
        });

    }
    public void checkAnswer()
    {
        IEnumerable<Toggle> answersGroup = toggleGroup.ActiveToggles();
        foreach (Toggle t in answersGroup)
        {
            if (t.isOn)
            {
                if (NowAnswer == t.name)
                {
                    AlertPanel.SetActive(true);
                }           
            }
        }
        
    }

    void Update()
    {
        
    }
}
