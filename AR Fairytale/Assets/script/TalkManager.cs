using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    // NPC�� �°� ��ȣ , ��ȭâ ����
    void Awake ()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(100, new string[] { "������ ��� �츮���̴�." });
        talkData.Add(200, new string[] { "��ɲ� �Ҿƹ����� ���̴�." });
        //�������� ��ȭ
        talkData.Add(1000, new string[] { ".. � �Ͼ��.:0" , "���� �����..:0", "���� ����� � �Ͼ��.:0", "���� �ҸӴ� ������ ����� ���ݴ�.:0"});
        //��ɲ۰��� ��ȭ
        talkData.Add(2000, new string[] { "�ݰ�����. ���� �����.:1","��ħ���� �������ϱ���:0" });
        talkData.Add(2001, new string[] { "���� ����� ���� �ҸӴϸ� ������ ����?:0", "���� ���� ���밡 ��Ÿ���ٴ� �ҹ��� ���ܴ�.:0",
            "�̷� ���� ���� ���밡 ���� �� ���� ������, Ȥ�� �𸣴� �����ؾ� �ȴܴ�?:0","�� �˰ڴ�?:0" });
        talkData.Add(2002, new string[] { "�����Ϸ�.:2" });

        //portraitData.Add(1000 + 0, portraitArr[0]); //�Ϲ�ǥ��
        //portraitData.Add(1000 + 1, portraitArr[1]); //���ǥ��
        //portraitData.Add(1000 + 2, portraitArr[2]); //����ǥ��
        //portraitData.Add(1000 + 3, portraitArr[3]); //ǥ��
        portraitData.Add(2000 + 0, portraitArr[0]); //�Ϲ�ǥ��
        portraitData.Add(2000 + 1, portraitArr[1]); //���ǥ��
        portraitData.Add(2000 + 2, portraitArr[2]); //����ǥ��
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
