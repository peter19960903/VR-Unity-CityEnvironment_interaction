using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Test_Sheet : MonoBehaviour
{
    public Text TopicTitle;
    public Text TopicText;
    string[][] ArrayX;
    string[] lineArray;
    public TextAsset m_article;
    public TextAsset article
    {
        get { return m_article; }
        set { m_article = value; }
    }
    private int topicIndex = 0;
    public List<Toggle> toggleList;
    public List<Text> chooseitem;
    private int times_index = 0;
    public Text Timer_Text;
    private int timer;
    public Canvas m_correct_message;
    public Canvas m_wrong_message;
    public int answer;
    void Start()
    {
        // for(int i = 0; i<4; i++){
        //     toggleList[i].onValueChanged.AddListener((isOn) => AnswerJudgment(isOn,i));  
        //  }

        for (int j = 0; j < toggleList.Count; j++)
        {
            toggleList[j].interactable = false;
        }
        TextCsv();
        LoadAnswer();

    }

    void TextCsv()
    {
        lineArray = m_article.text.Split('\n');
        ArrayX = new string[lineArray.Length][];
        // foreach(var line in lineArray )
        // {
        //     Debug.Log(line);
        // }
        for (int i = 0; i < lineArray.Length; i++)
        {
            ArrayX[i] = lineArray[i].Split(':');
        }
        // for (int i = 0; i < ArrayX.Length; i++)
        // {
        //     for (int j = 0; j < ArrayX[i].Length; j++)
        //     {
        //         Debug.Log(ArrayX[i][j]);
        //     }
        // }
    }

    void LoadAnswer()
    {
        m_correct_message.enabled = false;
        m_wrong_message.enabled = false;
        for (int x = 0; x < 4; x++)
        {
            toggleList[x].isOn = false;      //初始化toggle打勾的格子
        }
        for (int i = 0; i < toggleList.Count; i++)
        {
            toggleList[i].interactable = false;
        }
        TopicTitle.text = ArrayX[topicIndex][1];
        TopicText.text = ArrayX[topicIndex][2];
        int idx = ArrayX[topicIndex].Length - 3;
        for (int i = 0; i < idx; i++)
        {
            chooseitem[i].text = ArrayX[topicIndex][i + 3];
        }
        timer = 20;
        InvokeRepeating("timer_back", 1, 1); //每1秒重複呼叫函式1次
    }

    void timer_back()
    {
        timer -= 1;
        Timer_Text.text = "剩餘時間:" + timer + "秒";
        if (timer == 0)
        {
            Timer_Text.text = "剩餘時間:" + timer + "秒";
            for (int i = 0; i < toggleList.Count; i++)
            {
                toggleList[i].interactable = true;
            }

            CancelInvoke("timer_back");
            timer += 5; //時間加回五秒 要進入答題時間
            InvokeRepeating("timer_five", 1, 1);
        }
    }

    public bool AnyTogglesOn()
    {
        return toggleList.Find(x => x.isOn) != null;
    }

    void whoison()
    {
        for (int i = 0; i < 4; i++)
        {
            if (toggleList[i].isOn == true)
            {
                answer = i;
            }
        }
    }
    void timer_five()
    {
        timer -= 1;
        Timer_Text.text = "剩餘時間:" + timer + "秒";
        if (timer == 0)
        {
            Timer_Text.text = "剩餘時間:" + timer + "秒";
            CancelInvoke("timer_five");
            if (AnyTogglesOn() == false)
            { //判斷時間到了是否有toggle被勾選 若沒有就直接下一題 
                m_wrong_message.enabled = true;
                topicIndex++;
                Invoke("LoadAnswer", 2.0f);
            }
            else
            {
                whoison();
                AnswerJudgment(true, answer);
            }
        }
    }

    void AnswerJudgment(bool check, int index)
    {
        bool isRight;
        if (check)
        {
            int ans = int.Parse(ArrayX[topicIndex][3]);
            if (int.Parse(ArrayX[topicIndex][index + 3]) == ans)
            {
                topicIndex++;
                isRight = true;
                if (timer == 0)
                {
                    m_correct_message.enabled = true;
                    Invoke("LoadAnswer", 2.0f);
                }
            }
            // else if(times_index<2){ 錯誤次數小於2
            //     times_index++;
            //     LoadAnswer();
            // }
            else
            {
                // times_index++; 錯誤次數
                topicIndex++;
                if (timer == 0)
                {
                    m_wrong_message.enabled = true;
                    Invoke("LoadAnswer", 2.0f);
                }
                // times_index = 0;錯誤次數歸零
            }

        }

    }
    // for (int i = 0; i < toggleList.Count; i++)
    // {
    //     toggleList[i].interactable = false;
    // }







}
