using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuizManager : MonoBehaviour
{
    public GameManager gamemanager;
    public TalkManager talkmanager;
    public int BingGo = 0;
    public bool isClicked = false;

    private void Update()
    {
        if (isClicked)
        {
            Invoke("InvokeDelay", 2.0f);
            Debug.Log("isClicked");
            isClicked = false;
        }
    }
    void InvokeDelay()
    {
        if (BingGo == 1)
        {
            Debug.Log("complete");
            gamemanager.questPanel.SetActive(false);
            gamemanager.isAction = false;
        }
        else
        {
            Debug.Log("fail");
            gamemanager.quizText.text = "������ ���� ���� �����޶�� �߾���?\n\n\n";
        }
    }
    public void OnClickRed()
    {
        BingGo = 0;
        Debug.Log("�����Դϴ�");
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "����.. �� ������ �ƴϿ����� ����..\n\n\n";
        isClicked = true;
        
    }
    public void OnClickBlue()
    {
        Debug.Log("�����Դϴ�");
        BingGo = 1;
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "�¾�! �Ķ��� ���̿���. �� ����ؾ߰ڴ�.\n\n\n";
        isClicked = true;
    }

    public void OnClickYellow()
    {
        BingGo = 0;
        Debug.Log("�����Դϴ�");
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "����.. �� ������ �ƴϿ����� ����..\n\n\n";
        isClicked = true;
    }

}
