using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public TalkManager talkManager;
    public QuestManager questManager;
    public QuizManager quizManager;
    public GameObject talkPanel; // 액션때만 대화창 띄우기
    public GameObject questPanel;
    public GameObject Button;
    public GameObject wolf;
    public GameObject tree;
    public GameObject gm;
    public GameObject wolf_0;
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
    public int ARCountMeal = 0;
    public int ARCountTree = 0;
    public int ARCountFlower = 0;
    public int playerswitch = 0;
    public int wolfswitch = 0;
    public int count = 0;
    public int wolfquest = 0;
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
            if (objData.id == 1110 || objData.id == 20110 || objData.id == 20180)
            {
                if(objData.id == 20110)
                {
                    if (ARCountTree == 0)
                        objData.id = 20115;
                    else
                        objData.id = 20120;
                }
                if(objData.id == 20180)
                {
                    if (ARCountFlower == 0)
                        objData.id = 20185;
                    else
                        objData.id = 20190;
                }

            }
            else if(objData.id == 2020 || objData.id % 10 == 5)
            {
                objData.id += 5;
            }
            else
            {
                if(objData.id == 20000)
                    wolf.SetActive(true);
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
        else if (isNPC || id == 20020 || id == 20290 || id == 20210)
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
            case 100:
            case 200:
            case 250:
            case 300:
            case 600:
            case 700:
            case 710:
            case 720:
                next = false;
                break;
            case 400:
                countMeal = 1;
                next = false;
                break;
            case 500:
                countGrape = 1;
                next = false;
                break;
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
                    break;
            case 2000:
                if (self == 1)
                    next = true;
                else 
                    next = false;
                break;
            case 2010:
            case 2015:
                next = true;
                break;
            case 20120:
                tree.SetActive(false);
                next = true;
                break;
            case 20130:
                wolf.SetActive(false);
                next = true;
                break;
            case 20190:
                next = true;
                wolfswitch = 1;
                wolf.SetActive(true);
                break;
            case 20230:
                next = true;
                wolfswitch = 2;
                wolf.SetActive(false);
                count = 2;
                break;
            case 20240:
                next = true;
                break;
            case 20330:
                next = true;
                gm.SetActive(false);
                wolf.SetActive(true);
                count = 7;
                playerswitch = 1;
                break;
            case 2050:
                next = true;
                break;
            case 2060:
                wolfquest = 1;
                next = false;
                playerController.cameraTransform.position = new Vector3(60, -50, -1);
                playerController.playerTransform.position = new Vector3(60, -50, -1);
                Debug.Log("이동");
                break;
            case 2080:
                next = true;
                wolfquest = 2;
                break;
            case 2090:
                next = true;
                wolfquest = 3;
                break;
            default:
                next = true;
                break;
               
        }
    }



}
