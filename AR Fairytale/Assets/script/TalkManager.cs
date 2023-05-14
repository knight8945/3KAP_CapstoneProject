using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    // NPC에 맞게 번호 , 대화창 구현
    void Awake ()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(100, new string[] { "엄마랑 사는 우리집이다." });
        talkData.Add(200, new string[] { "사냥꾼 할아버지의 집이다." });
        //엄마와의 대화
        talkData.Add(1000, new string[] { ".. 어서 일어나렴.:0" , "빨간 망토야..:0", "빨간 망토야 어서 일어나렴.:0", "오늘 할머니 병문안 가기로 했잖니.:0"});
        //사냥꾼과의 대화
        talkData.Add(2000, new string[] { "반갑구나. 빨간 망토야.:1","아침부터 부지런하구나:0" });
        talkData.Add(2001, new string[] { "빨간 망토야 숲의 할머니를 만나러 가니?:0", "요즘 숲에 늑대가 나타났다는 소문이 돈단다.:0",
            "이런 작은 숲에 늑대가 나올 것 같지 않지만, 혹시 모르니 조심해야 된단다?:0","잘 알겠니?:0" });
        talkData.Add(2002, new string[] { "조심하렴.:2" });

        //portraitData.Add(1000 + 0, portraitArr[0]); //일반표정
        //portraitData.Add(1000 + 1, portraitArr[1]); //기쁜표정
        //portraitData.Add(1000 + 2, portraitArr[2]); //걱정표정
        //portraitData.Add(1000 + 3, portraitArr[3]); //표정
        portraitData.Add(2000 + 0, portraitArr[0]); //일반표정
        portraitData.Add(2000 + 1, portraitArr[1]); //기쁜표정
        portraitData.Add(2000 + 2, portraitArr[2]); //걱정표정
        //portraitData.Add(2000 + 3, portraitArr[3]);
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
