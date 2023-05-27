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
            gamemanager.quizText.text = "엄마가 무슨 꽃을 가져달라고 했었지?\n\n\n";
        }
    }
    public void OnClickRed()
    {
        BingGo = 0;
        Debug.Log("오답입니다");
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "으음.. 이 색깔이 아니였던것 같아..\n\n\n";
        isClicked = true;
        
    }
    public void OnClickBlue()
    {
        Debug.Log("정답입니다");
        BingGo = 1;
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "맞아! 파란색 꽃이였어. 잘 기억해야겠다.\n\n\n";
        isClicked = true;
    }

    public void OnClickYellow()
    {
        BingGo = 0;
        Debug.Log("오답입니다");
        gamemanager.questPanel.SetActive(true);
        gamemanager.quizText.text = "으음.. 이 색깔이 아니였던것 같아..\n\n\n";
        isClicked = true;
    }

}
