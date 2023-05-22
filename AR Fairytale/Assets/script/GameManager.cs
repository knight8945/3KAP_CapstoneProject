using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel; // 액션때만 대화창 띄우기
    public Image portraitImg;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {

        isAction = true;
        //talkPanel.SetActive(true);
        scanObject = scanObj;
        objData objData = scanObject.GetComponent<objData>();
        Talk(objData.id, objData.isNPC);
        
        talkPanel.SetActive(isAction); // isAction 과 talkPanel 이 서로 true면 true/ false면 false 로 같으니 하나로 정리
    }
    void Talk(int id, bool isNPC)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+ questTalkIndex, talkIndex);

        //End Talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);
            return;
        }

        if (isNPC)
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
}
