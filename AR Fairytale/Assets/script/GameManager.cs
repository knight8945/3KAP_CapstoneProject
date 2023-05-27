using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public QuizManager quizManager;
    public GameObject talkPanel; // 액션때만 대화창 띄우기
    public GameObject questPanel;
    public GameObject Button;
    public Image portraitImg;
    public TextMeshProUGUI talkText;
    public TextMeshProUGUI quizText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex = 0;
    public bool next = false;
    public bool questCheck = false;
    public int countMeal = 0;
    public int countGrape = 0;
    public int self = 0;
    private void Start()
    {
        //Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
        if(quizManager.BingGo == 1)
        {
            questPanel.SetActive(false);
        }
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        if (countGrape == 1 && countMeal == 1)
        {
            next = true;
            countMeal = 0;
            countGrape = 0;
            self = 1;
        }

        if (next)
        {
            next = false;
            if (objData.id == 1110)
            {
                objData.id = 1110;
            }
            else if(objData.id % 10 == 5)
            {
                objData.id += 5;
            }
            else
            {
                objData.id += 10;
            }
            
        }
        Talk(objData.id, objData.isNPC);
        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNPC)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id, talkIndex);


        //End Talk
        if (talkData == null)
        { 
            isAction = false;
            talkIndex = 0;
            nextScript(id);
            questManager.CheckQuest();
            return;
        }

        if (id % 10 == 5)
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        else if (isNPC)
        {

            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    void nextScript(int id)
    {
        switch (id)
        {
            case 400:
                countMeal = 1;
                next = false;
                break;
            case 500:
                countGrape = 1;
                next = false;
                break;
            case 250:
            case 1000:
            case 1010:
            case 1020:
            case 1025:
            case 1030:
            case 1040:
            case 1050:
            case 1070:
            case 1080:
            case 1090:
            case 1100:
            case 1110:
                next = true;
                break;
            case 1060:
                Debug.Log(questManager.CheckQuest());
                questCheck = true;
                if (countMeal == 1 && countGrape == 1)
                {
                    next = true;
                    break;
                }
                else
                {
                    break;
                }
            case 2000:
                if(self == 1)
                    next = true;
                else
                    next = false;
                break;
            case 2010:
            case 2015:
            case 2020:
                next = true;
                break;
        }
    }



}
