using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkManager : MonoBehaviour
{
	Dictionary<int, string[]> talkData;
	Dictionary<int, Sprite> portraitData;
	public Sprite[] portraitArr;
	public GameManager gamemanager;
	public bool next = false;
	public int count = -1;
	// NPC에 맞게 번호 , 대화창 구현
	void Awake()
	{
		talkData = new Dictionary<int, string[]>();
		portraitData = new Dictionary<int, Sprite>();
		GenerateData();
	}

	// Update is called once per frame
	void GenerateData()
	{
		//빨간 망토 집
		// 만의 자리 빨간망토 1 / 나레이션 2 / 늑대 3 // 할머니 4
		// 천의 자리 엄마 1 / 사냥꾼 2
		talkData.Add(10, new string[] { "높은 식탁에 있는 걸 엄마가 내려주었나봐" });
		//엄마와의 대화(화면 어둡게) 
		talkData.Add(1000, new string[] { ".. 어서 일어나렴.", "빨간 망토야.." });
		//화면 밝아짐
		talkData.Add(1010, new string[] { "빨간 망토야 어서 일어나렴.", "오늘 할머니 병문안 가기로 했잖니.", "으음.", "네 엄마 저 이제 일어났어요." });
		talkData.Add(1020, new string[] { "그럼 어서 씻고 준비하렴.", "해가 지기 전에 돌아오려면 서둘러야 한단다.", "네." });
		// 화면 잠시 어두워졌다 밝아짐
		talkData.Add(1030, new string[] { "엄마! 저 준비 다 됐어요!!" });
		talkData.Add(1040, new string[] { "좋아 옷도 반듯하고 문제없겠구나.", "할머니 병문안 가기전에", "할머니가 좋아하시는 빵이랑 포도주를 가져가면 좋겠구나.", "빨간 망토야 밖에 나가서 밀이랑 포도주를 가져오렴." });
		talkData.Add(1050, new string[] { "밀은 집 밖에 있는 밭에 4번째 줄에 아래에서 2번째 밀이 가장 잘 익었더구나.", "포도주는 포도밭 옆에 있는 상자에서 가져오면 된단다.", "네. 다녀올게요 엄마!!" });
		talkData.Add(1060, new string[] { "포도주는 상자에서 가져오고 밀은 왼쪽에서 4번째 줄에서 아래에서 2번째 밀이 가장 잘 익었더구나." });
		// 밀과 포도주를 가져왔을 때
		talkData.Add(1070, new string[] { "밀이랑 포도주랑 둘 다 잘 가져왔구나.", "이제 엄마가 빵을 구워줄테니 잠시만 기다리렴.", "네. 엄마" });

		// 잠시 암전
		talkData.Add(1080, new string[] { "빨간 망토야 빵이 다 되었단다.", "식탁 아래에 있는 바구니에 빵이랑 포도주를 담아 줄 수 있겠니?", "엄마는 바구니에 넣을 다른 것들을 찾아오마.", "네!" });
		//AR 이벤트 #1 후
		talkData.Add(1090, new string[] { "고맙구나.", "이제 이 바구니에 담아서 가져가기만 하면 된단다.", "그리고 가는길에 꽃밭에서 파란 꽃을 가져가렴.", "할머니가 요즘 잠을 못 주무신다는데 그 꽃의 향기를 맡으면 수면에 도움이 될 거야.", "알았어요. 엄마", "파란색 꽃 말이죠?" });
		talkData.Add(1100, new string[] { "한눈팔지 말고 늦기 전에 다녀와야 된단다.", "또 모르는 사람과 이야기하면 안 돼!", "네 엄마. 다녀올게요!" });
		talkData.Add(1110, new string[] { "늦지 않게 서두르렴", "파란색 꽃을 가져가는 것도 잊지 말고!" });
		// 문앞 미니 퀴즈
		talkData.Add(1115, new string[] { "엄마가 찾아가라고 한 꽃이 무슨 색이었지?:0" });


		//마을 사냥꾼과의 대화
		talkData.Add(2000, new string[] { "반갑구나. 빨간 망토야.:1", "아침부터 부지런하구나:1" });
		talkData.Add(2010, new string[] { "빨간 망토야 숲의 할머니를 만나러 가니?:1", "요즘 숲에 늑대가 나타났다는 소문이 돈단다.:2",
			"이런 작은 숲에 늑대가 나올 것 같지 않지만, 혹시 모르니 조심하렴?:2"});
		talkData.Add(2015, new string[] { "네. 사냥꾼 할아버지! 조심할게요." });
		talkData.Add(2020, new string[] { "조심하렴.:2" });

		//통나무 Scene 스크립트 1 빨간망토 2 나레이션 3 늑대
		talkData.Add(20000, new string[] { "커다란 통나무가 길을 가로막고 있어...", "응차", "으..통나무를 밀어도 보고 당겨도 봤지만 꿈쩍도 하지 않아...", "어떡하지.. 길은 여기밖에 없는데. 이러면 할머니를 만나러 갈 수 없어..." });
		talkData.Add(20010, new string[] { "그때, 곤란해하던 빨간 망토의 뒤로 망토를 뒤집어쓴 커다란 남자가 나타났어요." });
		talkData.Add(20020, new string[] { "거기 꼬마 아가씨.:4 ", "어디 곤란한 일이라도 있니?:4" });
		talkData.Add(20030, new string[] { "어? 아저씨는 누구세요?" });
		talkData.Add(20040, new string[] { "나는 지나가던 나그네란다. 검은 망토 아저씨라고 불러주렴.", "검은 망토요? 저는 빨간 망토라고 불려요. 정말 신기하네요!" });
		talkData.Add(20050, new string[] { "하하하!! 이거 재미있는 우연이구나.", "그래서 우리 빨간 망토는 여기서 무엇을 하고 있었니?", "할머니 병문안을 가고 있었는데 통나무가 길을 막아버렸어요..", "할머니가 혼자서 기다리고 계실 텐데.. 어떻게 하죠?" });
		talkData.Add(20060, new string[] { "(호오 그럼 이 꼬마랑 할머니, 둘 다 잡아먹을 수 있겠군!)" });
		talkData.Add(20070, new string[] { "네? 뭐라고 하셨나요?" });
		talkData.Add(20080, new string[] { "아니, 아무것도 아니란다. 그보다 그렇다면 이 검은 망토 아저씨가 도와줄 수 있을 것 같구나." });
		talkData.Add(20090, new string[] { "네? 정말요?" });
		talkData.Add(20100, new string[] { "그럼. 이 아저씨랑 같이 나무를 밀면 될 꺼란다. 둘이 힘을 합치면 충분히 할 수 있을 거야.", "하나, 둘, 셋 할때 밀면 된단다." });
		talkData.Add(20110, new string[] { "앗, 네 알았어요!" });
		// AR 이벤트 #2 후
		//실패
		talkData.Add(20115, new string[] { "음, 다시 한번 해보자꾸나. 하나, 둘, 셋!" });
		//성공
		talkData.Add(20120, new string[] { "와! 정말로 성공했어요! 아저씨 정말로 고맙습니다." });
		talkData.Add(20130, new string[] { "후후 이정도는 별거 아니란다.", "그럼 이제 나는 그만 가보도록 하마.", "할머니 병문안은 잘 하고 오너라.", "네. 아저씨 안녕히 가세요.", "엄청 서둘러서 가시네. 많이 바쁘신가 보다." });

		// 꽃밭 
		talkData.Add(20170, new string[] { "엄마가 할머니께 드릴 꽃을 가져가라고 하셨지. 무슨 색이었더라?" });
		talkData.Add(20180, new string[] { "어떤 꽃을 가져가야 했지..." });

		//AR 이벤트 #3
		//성공
		talkData.Add(20190, new string[] { "이 꽃은 향기가 너무 좋다. 할머니도 좋아하실 거야.", "다시 길을 나서려던 빨간 망토는 알록달록한 꽃들과 날아다니는 나비들을 발견했어요.", " 빨간 망토는 그것들이 너무나 예뻐 보였답니다.", "조금만 구경하고 가도 괜찮겠지?" });
		//암전

		//4. 오두막 앞
		talkData.Add(20200, new string[] { "빨간 망토가 꽃밭에서 쉬고 있을 때, 할머니의 오두막 앞에 검은 망토 아저씨가 나타났어요.", "검은 망토 아저씨는 주변을 두리번거리더니 망토를 벗어던졌어요.", "그러니 그 속에서 커다란 늑대가 나타났어요", "검은 망토 아저씨의 정체는 늑대였던 것이에요!" });
		talkData.Add(20210, new string[] { "숲 속에 혼자 사는 할머니의 집이 여기가 틀림없군.:4", "후후 오랜만에 정말 배불리 먹을 수 있겠군!:4" });
		talkData.Add(20220, new string[] { "늑대는 할머니의 집 앞에서 목을 가다듬더니 빨간 망토의 목소리를 흉내 내기 시작했어요." });
		talkData.Add(20230, new string[] { "할머니 저 빨간망토 왔어요!", "몸은 좀 괜찮으신가요?", "오오 우리 손녀 빨간 망토가 왔구나.", "크아아아앙!" });
		talkData.Add(20240, new string[] { "앗.. 엄마가 한눈 팔지 말라고 그랬는데!!!", "빨리 할머니집에 가야겠어!!" });
		//암전    

		//5. 꽃밭

		//6. 오두막 앞

		//7. 오두막 안
		talkData.Add(20300, new string[] { "오오 우리 빨간 망토 왔구나.", "할머니 많이 아프세요?", "할머니는 괜찮단다. 조금 피곤할 뿐이야.", "어! 할머니 귀가 왜 그렇게 커지셨어요?", "할머니?" });
		talkData.Add(20310, new string[] { "아 이건 우리 귀여운 빨간 망토의 목소리를 더 잘 들으려고 커진 거란다.", "지금 보니까 손도 엄청 커지신 것 같아요!", "이건 우리 빨간 망토를 더 따뜻하게 안아주기 위해서지." });
		talkData.Add(20320, new string[] { "할머니 입도 커지셨어요!" });
		talkData.Add(20330, new string[] { "그건 바로 너를 한 입에 잡아먹기 위해서지!", "크아아아앙!" });

		//AR 이벤트 #4

		//8. 오두막 앞
		talkData.Add(2030, new string[] { "한편 늑대가 잠에 빠져있었을 때, 사냥꾼 아저씨는 숲을 순찰 중에 특이한 것을 발견했어요." });
		talkData.Add(2050, new string[] { "아니 이것은 늑대 발자국? ", "정말로 이 숲에 늑대가 나타나다니!", "큰일이군..", "서둘러 찾지 않으면 누군가 크게 다칠지도 모르겠어." });
		talkData.Add(2060, new string[] { "늑대의 흔적을 따라가 보자" });
		//미니게임
		//실패
		talkData.Add(2070, new string[] { "내가 본 늑대랑 다른거 같아. 날카로운 발톱에 검정색 늑대였었지." });
		//발자국 성공
		talkData.Add(2080, new string[] { "발자국은 이쪽으로 이어지는군. 계속 찾아봐야겠어" });
		//모피 성공
		talkData.Add(2090, new string[] { "검은색 털이 여기에 떨어져있군. 할머니의 오두막으로 가봐야겠어." });
		//9. 오두막 안
		talkData.Add(2100, new string[] { "오두막 안으로 들어선 사냥꾼 아저씨는 침대에서 자고 있는 커다란 늑대를 발견했어요.", "부풀어 오른 늑대의 배를 보고 빨간 망토와 할머니가 어떻게 되었는지도 알 수 있었지요." });
		talkData.Add(2110, new string[] { "이럴수가! 어떻게 해야 하지?" });
		//1번 선택 실패
		talkData.Add(2115, new string[] { "아니야 아직 늦지 않았을지도 몰라!" });
		//3번 선택 실패
		talkData.Add(2125, new string[] { "늑대를 깨웠다가는 큰일이 날 거야." });
		// 성공시
		talkData.Add(2120, new string[] { "사냥꾼 아저씨는 서둘러서 가위를 꺼내 늑대의 배를 갈랐어요.", "다행히도 빨간 망토와 할머니는 살아있었어요.", "빨간 망토와 할머니는 사냥꾼의 도움으로 무사히 늑대의 배속에서 탈출할 수 있었어요." });
		talkData.Add(2130, new string[] { "으아앙! 정말 무서웠어요!" });
		talkData.Add(2140, new string[] { "정말 고맙네. 자네가 없었으면 어떻게 됐을지 모르겠군." });
		talkData.Add(2150, new string[] { "아직 끝난 게 아닙니다. 이 늑대에게 마땅한 벌을 줘야지요.", "저에게 생각이 있습니다.", "사냥꾼 아저씨는 늑대에 배에 커다란 돌덩이를 집어넣고 그대로 꿰매버렸어요.", "그리고는 빨간 망토와 할머니를 데리고 오두막 밖으로 나갔지요." });

		//10 오두막 앞
		talkData.Add(2160, new string[] { "잠시 후 잠에서 깬 늑대가 오두막 밖으로 나왔어요." });
		talkData.Add(1800, new string[] { "에잇!!" });
		talkData.Add(1810, new string[] { "떨어져라 이 못된 늑대야!!" });
		talkData.Add(2180, new string[] { "늑대가 연못 앞에서 고개를 숙이는 순간 수풀에 숨어있던 사냥꾼이 튀어나왔어요." });
		talkData.Add(2190, new string[] { "이얏!" });

		// AR이벤트 #5

		//OUTRO IMAGE
		talkData.Add(2200, new string[] { "그 후로 빨간 망토와 할머니는 다시는 늑대에게 잡아먹히는 일 없이 오래오래 행복하게 살았답니다." });

		//오브젝트 대화
		talkData.Add(100, new string[] { "엄마랑 사는 우리집이다." });
		talkData.Add(200, new string[] { "사냥꾼 할아버지의 집이다." });
		talkData.Add(250, new string[] { "밀밭으로 갈 수 있을 것 같아." });
		talkData.Add(300, new string[] { "이 밀은 아직 덜 익은 것 같아..." });
		talkData.Add(400, new string[] { "어! 정말 잘 익었네!! 이 밀이 맞는 것 같아!!" });
		talkData.Add(500, new string[] { "박스 안에서 잘 숙성된 포도주를 찾았다." });
		talkData.Add(600, new string[] { "왼쪽에서 4번째줄에 아래쪽에서 2번째 였던것 같아.." });
		talkData.Add(700, new string[] { "오른쪽에 있는 통나무에 가보자!" });
		talkData.Add(710, new string[] { "할머니집에 가보자" });
		talkData.Add(720, new string[] { "물가 옆에 있는 꽃밭으로 가보자!" });
		talkData.Add(800, new string[] { "내가 본 털은 검은색이였던 같아.." });
		//portraitData.Add(1000 + 0, portraitArr[0]); //일반표정
		//portraitData.Add(1000 + 1, portraitArr[1]); //기쁜표정
		//portraitData.Add(1000 + 2, portraitArr[2]); //걱정표정
		//portraitData.Add(1000 + 3, portraitArr[3]); //표정
		portraitData.Add(1115 + 0, portraitArr[0]);
		portraitData.Add(2000 + 0, portraitArr[0]); //일반표정
		portraitData.Add(2000 + 1, portraitArr[1]); //기쁜표정
		portraitData.Add(2000 + 2, portraitArr[2]); //걱정표정
		portraitData.Add(2010 + 1, portraitArr[1]); //기쁜표정
		portraitData.Add(2010 + 2, portraitArr[2]); //걱정표정
		portraitData.Add(2020 + 2, portraitArr[2]); //걱정표정
		portraitData.Add(20020 + 4, portraitArr[4]);
		portraitData.Add(20210 + 4, portraitArr[4]);
		portraitData.Add(20290 + 4, portraitArr[4]);
		portraitData.Add(20330 + 4, portraitArr[4]);
		//portraitData.Add(2000 + 3, portraitArr[3]);
	}
	public string GetTalk(int id, int talkIndex)
	{
		if (!talkData.ContainsKey(id)) {
			if (!talkData.ContainsKey(id - id % 10))
				return GetTalk(id - id % 100, talkIndex);
			else
				return GetTalk(id - id % 10, talkIndex);
		}
		if (talkIndex == talkData[id].Length) {
			return null;
		} else
			return talkData[id][talkIndex];


	}
	public Sprite GetPortrait(int id, int portraitIndex)
	{
		return portraitData[id + portraitIndex];
	}


}
