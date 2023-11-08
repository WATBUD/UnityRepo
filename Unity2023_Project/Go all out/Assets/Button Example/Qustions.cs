using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Qustions : MonoBehaviour
{

    public string NowAnswer = "1";
    public ToggleGroup toggleGroup;
    public GameObject AlertPanel;//題目
    public Button checkButton;//檢查答案
    public Text qustionText;//題目
    public GameObject parsingPanel;//題目
    public StartCountdown startCountdown;
    public int questionNumber = 0;//第幾題
    public class QuestionBank//題庫
    {
        public string topic { get; set; }//題目
        public string answerIndex { get; set; }//題目答案位置
        public string[] fourAnswers = new string[4];//四個答案
        public string parsingText ;//提示文字

        public QuestionBank(string topic, string answerIndex, string[] fourAnswers, string parsingText)//建構子
        {
            this.answerIndex = answerIndex;
            this.topic = topic;
            this.fourAnswers = fourAnswers;
            this.parsingText = parsingText;
        }
    }

    List<QuestionBank> questionBank = new List<QuestionBank>(){
        new QuestionBank("題目1:2*2=?", "4",new string[4]{"99", "244", "555", "4"},"再去看看九九乘法表?"),//第0題
        new QuestionBank("題目2:台灣常用語言是=?", "3",new string[4]{"英文", "數學", "國文", "俄文"},"再想想看?"),//1
        new QuestionBank("題目3:美國常用語言是=?", "1",new string[4]{"英文", "數學", "國文", "俄文"},"再去看看九九乘法表?"),//1

    };

    // Start is called before the first frame update
    void Start()//進入程式
    {
        Debug.Log(questionBank);
        checkButton.onClick.AddListener(() =>
        {
            this.checkAnswer();//檢查答案
        });

        UpdateUI();//更新題目
    }

    void UpdateUI()//更新題目
    {
        Toggle[] answerGroup = this.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < answerGroup.Length; i++)
        {
            var index = i;
            answerGroup[index].GetComponentInChildren<Text>().text = questionBank[questionNumber].fourAnswers[index];
        }
        qustionText.text = questionBank[questionNumber].topic;

    }
    void checkAnswer()
    {
        IEnumerable<Toggle> answerGroup = toggleGroup.ActiveToggles();
        foreach (Toggle t in answerGroup)
        {
            if (t.isOn)
            {
                if (t.name == questionBank[questionNumber].answerIndex)//答對

                {
                    if (questionNumber == questionBank.Count - 1)//0 2
                    {
                        AlertPanel.SetActive(true);//我過關了
                        CancelInvoke("startCount");//取消startCountdown計時器的計時
                    }
                    else
                    {
                        questionNumber += 1;//前進下一題 0+1
                        UpdateUI();
                    }
                }
                else//答錯
                {
                    parsingPanel.GetComponentInChildren<Text>().text = questionBank[questionNumber].parsingText;//提示文字

                    parsingPanel.SetActive(true);//跳出解析

                }



            }
        }
    }
}



    

