using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Questtext : MonoBehaviour
{
    public Text quest_title;
    public Text quest_text;

    public GameObject gameManager;
    public bool check; //대화끝나고 퀘스트내용 띄우기위함.

    string[] quest1= new string[2];
    string[] quest2 = new string[2];
    string[] quest3 = new string[2];
    string[] quest4 = new string[2];
    string[] quest4_5 = new string[2];
    string[] quest5 = new string[2];
    string[] quest6 = new string[2];
    string[] quest7 = new string[2];
    string[] quest8 = new string[2];
    string[] quest9 = new string[2];
    string[] quest10 = new string[2];
    string[] quest10_5 = new string[2];
    string[] quest11 = new string[2];
    string[] quest12 = new string[2];
    string[] quest13 = new string[2];
    string[] quest13_5 = new string[2];
    string[] quest14 = new string[2];
    string[] quest15 = new string[2];
    string[] quest16 = new string[2];
    string[] quest23 = new string[2];
    string[] quest24 = new string[2];
    string[] quest25 = new string[2];
    string[] quest26 = new string[2];
    string[] quest27 = new string[2];
    string[] quest28 = new string[2];

    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
        quest1[0] = "소녀의 부탁 들어주기";
        quest1[1] = "맵 중앙 호수의 왼쪽길을 따라 노란 집에 찾아가기.";

        quest2[0] = "의문의 초대";
        quest2[1] = "노란 집 안으로 들어가기.";

        quest3[0] = "전투 테스트 받기";
        quest3[1] = "오른쪽의 훈련교관에게 찾아가기.";

        quest4[0] = "훈련교관의 테스트";
        quest4[1] = "훈련교관을 무찌르기.";

        quest4_5[0] = "비밀기지대장에게 돌아가기";
        quest4_5[1] = "비밀기지대장 지나에게 말을 걸어보자.";

        quest5[0] = "위장임무";
        quest5[1] = "지나가 준 배찌를 착용하고 주차장쪽으로 찾아가기.";

        quest6[0] = "가이아에 잠입하기";
        quest6[1] = "가이아로 가는길에는 삼엄하고 위험한 함정이 있으니 조심해서 길을 찾아 가보자.";

        quest7[0] = "쓰러진 할아버지 구해주기";
        quest7[1] = "앞에 쓰러진 할아버지를 공격하는 경비원을 막자.";

        quest8[0] = "할아버지 부축하기";
        quest8[1] = "할아버지를 도와드리고 말을 걸어보자.";

        quest9[0] = "할아버지의 부탁";
        quest9[1] = "먼저위에 경비들이 있는 사무실로 가보자.";

        quest10[0] = "경비원들 물리치고 열쇠얻기";
        quest10[1] = "사무실 내부로 들어가 경비원을 물리치고 열쇠를 획득하자.";

        quest10_5[0] = "공장 작동 멈추기";
        quest10_5[1] = "얻은 열쇠로 공장의 트레일러를 멈춰보자. 열쇠 꽂는데에 가까이가서 E키를 누르면 열쇠를 꽂을 수 있다.";

        quest11[0] = "할아버지께 돌아가기";
        quest11[1] = "할아버지께 성공했다는 소식을 들려주러 가자.";

        quest12[0] = "아레아로 돌아가기";
        quest12[1] = "할아버지 말씀대로 일단 아레아로 돌아가자.";

        quest13[0] = "보스와의 전투";
        quest13[1] = "레이보어에 맞서 싸워 이기자.";

        quest13_5[0] = "지나에게 돌아가자.";
        quest13_5[1] = "비밀기지에 돌아가서 지나에게 지금까지 있었던 일을 알려주자.";

        quest14[0] = "근처 마을로 이동하자.";
        quest14[1] = "지나 말대로 스테이지2로 가보자. 중앙호수 오른쪽 길을 따라 나가면 된다.";

        quest15[0] = "우물에서 물을 가지고 오자.";
        quest15[1] = "오른쪽 마을에 들어가면 우물이 있다. 바구니에 E키를 사용해 물을 떠오자.";

        quest16[0] = "불끄기.";
        quest16[1] = "나무에 붙은 불을 E키를 사용해 끄자.";

        quest23[0] = "마을에 가서 이장님을 만나보자.";
        quest23[1] = "옆 마을로 돌아가 양동이를 돌려드리고 이장님과 대화를 나눠보자.";

        quest24[0] = "우물 앞 시장으로 가자.";
        quest24[1] = "시장으로 가서 손선풍기도 사면서 가게주인과 대화를 나눠보자.";

        quest25[0] = "마을 사람과의 대화.";
        quest25[1] = "마을 이웃 사람과 대화를 나눠보자. 시장 오른쪽 윗길에 아주머니에게 대화를 걸어보자.";

        quest26[0] = "이 마을의 의심";
        quest26[1] = "확실히 마을에 이상한 점이 있는 것 같다.";

        quest27[0] = "끊긴 신호를 따라서";
        quest27[1] = "이장님이 알려주신 길을 따라 올라가자. 이장이 있는 곳의 위에 길을 따라가면 된다. 경사가 있으니 조심하자.";

        quest28[0] = "종이에 적힌 장소로 가보자";
        quest28[1] = "마을로 돌아가 북동방향의 길로 가보자.";

    }

    // Update is called once per frame
    void Update()
    {
        check = gameManager.GetComponent<GameManager>().isTalking;
        if (!check)
        {
            Show_quest();
        }
    }

    void Show_quest()
    {
        if(NpcQuest.questnum == 1)
        {
            quest_title.text = quest1[0];
            quest_text.text = quest1[1];
        }
        else if (NpcQuest.questnum == 2)
        {
            quest_title.text = quest2[0];
            quest_text.text = quest2[1];
        }
        else if (NpcQuest.questnum == 3)
        {
            quest_title.text = quest3[0];
            quest_text.text = quest3[1];
        }
        else if (NpcQuest.questnum == 4)
        {
            quest_title.text = quest4[0];
            quest_text.text = quest4[1];
        }
        else if (NpcQuest.questnum == 4.5f)
        {
            quest_title.text = quest4_5[0];
            quest_text.text = quest4_5[1];
        }
        else if (NpcQuest.questnum == 5)
        {
            quest_title.text = quest5[0];
            quest_text.text = quest5[1];
        }
        else if ( NpcQuest.questnum == 6 && NpcQuest.clear_badge_mission == 1)
        {
            quest_title.text = quest6[0];
            quest_text.text = quest6[1];
        }
        else if (NpcQuest.questnum == 7)
        {
            quest_title.text = quest7[0];
            quest_text.text = quest7[1];
        }
        else if (NpcQuest.questnum == 8)
        {
            quest_title.text = quest8[0];
            quest_text.text = quest8[1];
        }
        else if(NpcQuest.questnum == 9)
        {
            quest_title.text = quest9[0];
            quest_text.text = quest9[1];
        }
        else if (NpcQuest.questnum == 10)
        {
            quest_title.text = quest10[0];
            quest_text.text = quest10[1];
        }
        else if(NpcQuest.questnum == 10.5f)
        {
            quest_title.text = quest10_5[0];
            quest_text.text = quest10_5[1];
        }
        else if (NpcQuest.questnum == 11f)
        {
            quest_title.text = quest11[0];
            quest_text.text = quest11[1];
        }
        else if (NpcQuest.questnum == 12f)
        {
            quest_title.text = quest12[0];
            quest_text.text = quest12[1];
        }
        else if (NpcQuest.questnum == 13f)
        {
            quest_title.text = quest13[0];
            quest_text.text = quest13[1];
        }
        else if (NpcQuest.questnum == 13.5f)
        {
            quest_title.text = quest13_5[0];
            quest_text.text = quest13_5[1];
        }
        else if (NpcQuest.questnum == 14f)
        {
            quest_title.text = quest14[0];
            quest_text.text = quest14[1];
        }
        else if (NpcQuest.questnum == 15f)
        {
            quest_title.text = quest15[0];
            quest_text.text = quest15[1];
        }
        else if (NpcQuest.questnum == 16f)
        {
            quest_title.text = quest16[0];
            quest_text.text = quest16[1];
        }
        else if (NpcQuest.questnum == 23f)
        {
            quest_title.text = quest23[0];
            quest_text.text = quest23[1];
        }
        else if (NpcQuest.questnum == 24f)
        {
            quest_title.text = quest24[0];
            quest_text.text = quest24[1];
        }
        else if (NpcQuest.questnum == 25f)
        {
            quest_title.text = quest25[0];
            quest_text.text = quest25[1];
        }
        else if (NpcQuest.questnum == 26f)
        {
            quest_title.text = quest26[0];
            quest_text.text = quest26[1];
        }
        else if (NpcQuest.questnum == 27f)
        {
            quest_title.text = quest27[0];
            quest_text.text = quest27[1];
        }
        else if (NpcQuest.questnum == 28f)
        {
            quest_title.text = quest28[0];
            quest_text.text = quest28[1];
        }


    }
}
