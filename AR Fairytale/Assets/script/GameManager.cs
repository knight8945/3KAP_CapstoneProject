using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel; // �׼Ƕ��� ��ȭâ ����
    public Image portraitImg;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj)
    {

        isAction = true;
        //talkPanel.SetActive(true);
        scanObject = scanObj;
        objData objData = scanObject.GetComponent<objData>();
        Talk(objData.id, objData.isNPC);
        
        talkPanel.SetActive(isAction); // isAction �� talkPanel �� ���� true�� true/ false�� false �� ������ �ϳ��� ����
    }
    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
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
