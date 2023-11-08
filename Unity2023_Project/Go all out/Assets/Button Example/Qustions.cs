using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Qustions : MonoBehaviour
{

    public string NowAnswer = "1";
    public ToggleGroup toggleGroup;
    public GameObject AlertPanel;//�D��
    public Button checkButton;//�ˬd����
    public Text qustionText;//�D��
    public GameObject parsingPanel;//�D��
    public StartCountdown startCountdown;
    public int questionNumber = 0;//�ĴX�D
    public class QuestionBank//�D�w
    {
        public string topic { get; set; }//�D��
        public string answerIndex { get; set; }//�D�ص��צ�m
        public string[] fourAnswers = new string[4];//�|�ӵ���
        public string parsingText ;//���ܤ�r

        public QuestionBank(string topic, string answerIndex, string[] fourAnswers, string parsingText)//�غc�l
        {
            this.answerIndex = answerIndex;
            this.topic = topic;
            this.fourAnswers = fourAnswers;
            this.parsingText = parsingText;
        }
    }

    List<QuestionBank> questionBank = new List<QuestionBank>(){
        new QuestionBank("�D��1:2*2=?", "4",new string[4]{"99", "244", "555", "4"},"�A�h�ݬݤE�E���k��?"),//��0�D
        new QuestionBank("�D��2:�x�W�`�λy���O=?", "3",new string[4]{"�^��", "�ƾ�", "���", "�X��"},"�A�Q�Q��?"),//1
        new QuestionBank("�D��3:����`�λy���O=?", "1",new string[4]{"�^��", "�ƾ�", "���", "�X��"},"�A�h�ݬݤE�E���k��?"),//1

    };

    // Start is called before the first frame update
    void Start()//�i�J�{��
    {
        Debug.Log(questionBank);
        checkButton.onClick.AddListener(() =>
        {
            this.checkAnswer();//�ˬd����
        });

        UpdateUI();//��s�D��
    }

    void UpdateUI()//��s�D��
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
                if (t.name == questionBank[questionNumber].answerIndex)//����

                {
                    if (questionNumber == questionBank.Count - 1)//0 2
                    {
                        AlertPanel.SetActive(true);//�ڹL���F
                        CancelInvoke("startCount");//����startCountdown�p�ɾ����p��
                    }
                    else
                    {
                        questionNumber += 1;//�e�i�U�@�D 0+1
                        UpdateUI();
                    }
                }
                else//����
                {
                    parsingPanel.GetComponentInChildren<Text>().text = questionBank[questionNumber].parsingText;//���ܤ�r

                    parsingPanel.SetActive(true);//���X�ѪR

                }



            }
        }
    }
}



    

