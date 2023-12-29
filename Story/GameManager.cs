using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public GameObject Npc_name_position;
    public Text Npc_name;
    public GameObject Player_name;
    public Text talkText;
    public bool isTalking;
    public int talk_num = 0;

    string[] Npc1_talk = new string[11];
    string[] Npc2_talk = new string[6];
    string[] Npc3_talk = new string[35];
    string[] Npc4_talk = new string[8];
    string[] Npc3_talk_2 = new string[11];
    string[] Npc5_talk_p = new string[6];
    string[] Npc5_talk_ip = new string[2];
    string[] Player_monologue_1 = new string[8];
    string[] Npc6_talk = new string[10];
    string[] Npc7_talk = new string[22];
    string[] Npc8_talk = new string[10];
    string[] Npc7_talk_2 = new string[12];
    string[] Npc10_talk = new string[6];
    string[] Npc3_talk_3 = new string[22];
    string[] Npc11_talk = new string[6];
    string[] Npc11_talk_2 = new string[4];
    string[] Npc13_talk = new string[16];
    string[] Npc14_talk = new string[19];
    string[] Npc15_talk = new string[11];
    string[] Player_monologue_2 = new string[7];
    string[] Npc16_talk = new string[12];


    GameObject House_potal;
    GameObject Secret_battle_potal;
    GameObject Miro_potal;
    GameObject Gaiatofight_potal;
    GameObject AreatoBoss_potal;
    GameObject AreatoFire_potal;
    GameObject DeserttoTop_potal;

    //퀘스트중 이미지 보이게 하기위한 오브젝트
    GameObject letter;




    void Awake()
    {

        Npc1_talk[0] = "라라: 저기요..! 도와주세요...";
        Npc1_talk[1] = "주인공: 무슨 일이시죠?";
        Npc1_talk[2] = "라라: 이 쪽지 좀 전해주세요...";
        Npc1_talk[3] = "주인공: 쪽찌? ";
        Npc1_talk[4] = "???: 거기 서라!!";
        Npc1_talk[5] = "라라: 칫.. 벌써 들켰나..";
        Npc1_talk[6] = "라라: 이 위로 올라가면 큰 호수정원이 있어요.";
        Npc1_talk[7] = "라라: 호수정원에서 왼쪽길을 따라가 가장 왼쪽 위 노란집에 찾아가 전해주세요..";
        Npc1_talk[8] = "라라: 꼭 부탁드릴게요...!";
        Npc1_talk[9] = "주인공: 아니..이게 무슨? ";
        Npc1_talk[10] = "주인공: (무슨 일인진 모르겠지만, 급해보이니 일단 대신 전해주자.)";


        Npc2_talk[0] = "심각해보이는 여인: 누구시죠?";
        Npc2_talk[1] = "주인공: 아 저는..";
        Npc2_talk[2] = "주인공: 이 쪽지를 드리려고 왔습니다.";
        Npc2_talk[3] = "심각해보이는 여인: (이건...라라 글씨첸데..) 이걸 왜 그 쪽이 갖고 있죠?";
        Npc2_talk[4] = "주인공: 어떤 분이 대신 전해달라해서요.";
        Npc2_talk[5] = "심각해보이는 여인: 일단 안으로 들어오세요. 안에서 저희 보스랑 얘기하시죠.";


        Npc3_talk[0] = "지나: 안녕하세요 저는 레지스탕스대장 지나라고해요.";
        Npc3_talk[1] = "주인공: 레지스탕스? 뭐하시는 분이죠?";
        Npc3_talk[2] = "지나: 저희는 이 도시 뒤에 숨겨진 착취현장과 현재 여기 아레아의 시장 레이보어의 실체를 밝히려는 비밀단체입니다.";
        Npc3_talk[3] = "주인공: 도시에 무슨 일이 있었나요?";
        Npc3_talk[4] = "지나: 수십년 전, 맑은 공기와 푸른 물, 녹색의 자연이 조화를 이뤘던 가이아라는 지역이 있었습니다.";
        Npc3_talk[5] = "지나: 이 지역에는 풍부한 자원과 함께 다섯 가지의 빛이 나는 오색 크리스탈이라는 희귀한 원석이 있었죠.";
        Npc3_talk[6] = "지나: 이 크리스탈은 햇빛을 받으면 스스로 엄청난 에너지를 만드는 힘을 가지고 있어서";
        Npc3_talk[7] = "지나: 이러한 힘은 나무나 꽃과 같은 자연에 깨끗하고 충분한 양분을 만들어 주었죠.";
        Npc3_talk[8] = "지나: 오색 크리스탈의 힘을 기반으로 가이아 지역 사람을 비롯한 모든 생명체들이 풍요롭고 행복하게 살아가고 있었습니다.";
        Npc3_talk[9] = "지나: 레이보어가 가이아를 침략하기 전까지는..";
        Npc3_talk[10] = "지나: 레이보어는 크리스탈을 빼앗은 뒤, 가이아 지역 사람들을 노예로 만들었어요.";
        Npc3_talk[11] = "지나: 지금 이순간까지도 강제로 사람들을 착취시키고, 캐둔 흑원 및 자원들을 다른 지역에 수출해서 막대한 돈을 벌고있죠. ";
        Npc3_talk[12] = "지나: 그리고 빼앗은 오색 크리스탈을 이용해서 지금의 무한 동력 자동차를 만들었고,";
        Npc3_talk[13] = "지나: 아레아 시민들에겐 낮은 가격으로 판매하며 많은 지지를 얻고 결국, 이 도시의 시장이 되었죠.";
        Npc3_talk[14] = "지나: 사실은 욕심 많은 침략자에 사기꾼에 불과한데 말이죠.";
        Npc3_talk[15] = "주인공: 그렇군요.. 그나저나 이러한 사실을 어떻게 아셨죠? 마을 사람들은 대부분 모르는 것 같던데";
        Npc3_talk[16] = "지나: 제가 태어난 곳이 가이아였습니다. 어릴 때 저희 아버지께서 저만이라도 그 곳에서 벗어나게 해주셨어요.";
        Npc3_talk[17] = "지나: 지금의 가이아는 과도한 채광과 채집으로 황폐해졌고,필요한 에너지는 크리스탈을 대신해 흑원을 연소시켜 얻고있습니다. ";
        Npc3_talk[18] = "지나: 계속된 흑원 연소를 통해 많은 대기오염 물질이 배출되었고 공기가 많이 나빠졌다고합니다.";
        Npc3_talk[19] = "지나: 조사원에 따르면 호흡기 쪽 문제가 많은 사람들이 많은데도 마땅한 의료시설은 없고 사람들은 죽어가고 있다고 하네요.";
        Npc3_talk[20] = "지나: 지금도 저희 아버지께선 그러한 환경속에서 부당한 대우와 착취를 당하시고 계시겠죠...";
        Npc3_talk[21] = "주인공: ...";
        Npc3_talk[22] = "지나: 전 그래서 꼭, 이 진실을 알리고 레이보어를 물리쳐 저희 아버지와 가이아 사람들을 구하고 말겁니다.";
        Npc3_talk[23] = "지나: 그러기 위해선, 당신의 힘이 필요해요.";
        Npc3_talk[24] = "주인공: 네..?";
        Npc3_talk[25] = "지나: 당신이 만났던 그 친구는 저희 단체의 스파이였습니다.";
        Npc3_talk[26] = "지나: 가이아의 모습을 도시 사람들에게 알리기 위해서 몰래 가이아에 잠입한 요원이었죠.";
        Npc3_talk[27] = "지나: 안타깝게도 방금 라라가 가이아에서 돌아오는 길에 레이보어에게 잡혔다는 소식을 받았어요.";
        Npc3_talk[28] = "지나: 다시 가이아에 잠입할 요원이 필요한데,";
        Npc3_talk[29] = "지나: 저희 단체는 그쪽에서도 인지하고 있기 때문에 최대한 알려지지 않는 얼굴이 필요해요.";
        Npc3_talk[30] = "지나: 일단, 기지 오른쪽에 훈련대장을 찾아가 테스트를 보세요.";
        Npc3_talk[31] = "지나: 그런 다음에 저를 다시 찾아오세요.";
        Npc3_talk[32] = "주인공: (하.. 쉬러왔지만 사연을 듣고나니 안타까운 마음이 든다.)";
        Npc3_talk[33] = "주인공: (내가 좀 도와줄 필요가 있어보인다.)";
        Npc3_talk[34] = "주인공: (우선, 지나 말대로 훈련대장에게 갔다오자.)";


        Npc4_talk[0] = "훈련대장: 이번에 새로 들어온 요원인가?";
        Npc4_talk[1] = "주인공: 아.. 아뇨 저는 그냥";
        Npc4_talk[2] = "훈련대장: 그렇군. 멋진 사내구만.";
        Npc4_talk[3] = "주인공: (말을 다 안했는데..)";
        Npc4_talk[4] = "훈련대장: 자네가 볼 테스트는 바로...";
        Npc4_talk[5] = "훈련대장: 나 훈련대장과의 겨루기다!";
        Npc4_talk[6] = "훈련대장: 나를 이기면 테스트는 통과일걸세.";
        Npc4_talk[7] = "훈련대장: 그럼 준비되면 오른쪽 지하 훈련방으로 내려오시게.";


        Npc3_talk_2[0] = "지나: 벌써 테스트를 통과하다니 대단하시네요.";
        Npc3_talk_2[1] = "지나: 훌륭한 실력을 가지고 있더군요.";
        Npc3_talk_2[2] = "지나: 당신 같은 사람을 알게되서 정말 다행이에요.";
        Npc3_talk_2[3] = "주인공: 아..예..뭐..";
        Npc3_talk_2[4] = "지나: 이제 가이아에 잠입할 준비를 해두세요.";
        Npc3_talk_2[5] = "지나: 가이아를 향하는 길엔 경비가 삼엄해서 그들이 끼고다니는 뱃지가 필요한데,";
        Npc3_talk_2[6] = "지나: 다행히, 라라가 건네준 쪽지안에 뱃지가 들어있었어요.";
        Npc3_talk_2[7] = "지나: 이 뱃지를 드릴테니, 차고 중앙공원 오른쪽에서 주차장안으로 들어가는길로 가주시겠어요?";
        Npc3_talk_2[8] = "지나: 당신은 얼굴도 알려지지 않았고, 뱃지를 차고있다면 걸릴 일은 없을겁니다.";
        Npc3_talk_2[9] = "지나: 뱃지는 E키를 누르면 착용하실수 있을거에요.";
        Npc3_talk_2[10] = "지나: 가이아의 모습은 현재 어떤지, 사람들은 어떤지 파악한 뒤, 돌아와서 알려주세요.";


        Npc5_talk_p[0] = "경비1: 잠시만, 처음 보는 얼굴인데?";
        Npc5_talk_p[1] = "주인공: 아, 이번에 새로 들어온 신입입니다.";
        Npc5_talk_p[2] = "경비1: 흠... 그렇군.";
        Npc5_talk_p[3] = "경비1: 앞으로 똑바로 잘하도록, 모르는게 있으면 물어보고";
        Npc5_talk_p[4] = "주인공: 네, 알겠습니다.";
        Npc5_talk_p[5] = "경비1: 들어가.";

        Npc5_talk_ip[0] = "경비1: 잠시만, 여기는 관계자외 출입금지 구역입니다.";
        Npc5_talk_ip[1] = "경비1: 돌아가세요.";

        Player_monologue_1[0] = "주인공: 여기가 가이아인가..?";
        Player_monologue_1[1] = "주인공: 눈에 뿌옇한 색이 보일 정도로 공기가 확실히 많이 안좋아...";
        Player_monologue_1[2] = "주인공: 숨쉴때마다 목도 텁텁하고..";
        Player_monologue_1[3] = "주인공: 그나저나 착취당하는 자들이 이렇게 많았다니..";
        Player_monologue_1[4] = "주인공: 생각보다 훨씬 심각하군..";
        Player_monologue_1[5] = "주인공: 더구나 폭력도 서슴치 않게 하고있어. ";
        Player_monologue_1[6] = "주인공: 일단 앞에 당하고 있는 저 할아버지를 구하자.";
        Player_monologue_1[7] = "주인공: 도저히 눈으로만 보고 있을수가 없겠어.";

        Npc6_talk[0] = "경비2: 넌 뭐야?";
        Npc6_talk[1] = "주인공: 안녕하십니까. 이번에 이쪽으로 발령되서 온 신입입니다.";
        Npc6_talk[2] = "경비2: 그렇군. 신입이구만. 잘됐어.";
        Npc6_talk[3] = "경비2: 온 김에 잘 봐둬. 말 잘 안듣는 골치덩어리는 어떻게 교육시키는지";
        Npc6_talk[4] = "주인공: 저 선배님, 아까 걸어오면서 잘 보았습니다.";
        Npc6_talk[5] = "주인공: 제가 따로 교육 철저히 시킬테니, 잠시 쉬러 가시죠.";
        Npc6_talk[6] = "경비2: 흠... 좋아.";
        Npc6_talk[7] = "경비2: 안그래도 계속 교육시키랴 팔 아팠는데 잘됐어.";
        Npc6_talk[8] = "경비2: 정신 똑바로 차릴 수 있게 만들고, 이따 위쪽 사무실로와. ";
        Npc6_talk[9] = "주인공: 네, 알겠습니다. ";

        Npc7_talk[0] = "주인공: 저기.. 괜찮으세요?";
        Npc7_talk[1] = "의문의 할아버지: ...";
        Npc7_talk[2] = "주인공: 저는 사실 여기 경비원이 아닙니다.";
        Npc7_talk[3] = "주인공: 여러분들을 도와드리러 왔어요. ";
        Npc7_talk[4] = "주인공: 아레아에 비밀단체가 있습니다. 그리고 그 단체의 대장 지나라는 사람의 부탁으로 잠입한거구요. ";
        Npc7_talk[5] = "의문의 할아버지: 지나..?";
        Npc7_talk[6] = "의문의 할아버지: 지나라고 하셨나요? 확실합니까?";
        Npc7_talk[7] = "주인공: 네, 맞습니다.";
        Npc7_talk[8] = "의문의 할아버지: 지나는 제 딸입니다.";
        Npc7_talk[9] = "의문의 할아버지: 제 딸은 지금 어떤가요? 괜찮은가요? 어디 아픈데나 없나요?";
        Npc7_talk[10] = "주인공: 네, 건강합니다.";
        Npc7_talk[11] = "의문의 할아버지: 다행이에요.. 정말 다행이야..";
        Npc7_talk[12] = "주인공: 따님은 여러분들을 구하기 위해서 많이 노력하고 있습니다.";
        Npc7_talk[13] = "주인공: 제가 도와드릴테니 다같이 여기서 나가시죠.";
        Npc7_talk[14] = "의문의 할아버지: 그 전에, 먼저 해야할 일이 있습니다.";
        Npc7_talk[15] = "의문의 할아버지: 여기서 공장이 더이상 못돌아가도록 멈춰야해요.";
        Npc7_talk[16] = "의문의 할아버지: 가이아의 공기가 많이 안좋아진 원인은 바로 저 공장때문입니다.";
        Npc7_talk[17] = "의문의 할아버지: 캔 자원들을 이용해서 연소시키고 가공해서 나오는 연기가 가이아의 대기를 오염시키고 있습니다.";
        Npc7_talk[18] = "의문의 할아버지: 더 이상 우리의 땅과 대기를 더럽히는걸 볼수가 없어요.";
        Npc7_talk[19] = "의문의 할아버지: 공장의 트레일러와 기계들의 작동을 멈추게하려면 황금색의 열쇠가 필요한데,";
        Npc7_talk[20] = "의문의 할아버지: 그 열쇠는 위쪽에 사무실의 경비원들이 가지고 있어요.";
        Npc7_talk[21] = "의문의 할아버지: 경비원을 물리쳐 열쇠를 얻고 열쇠로 작동을 멈춰주세요..부탁 드리겠습니다..";

        Npc8_talk[0] = "경비3: 너가 이번에 들어온 신입인가?";
        Npc8_talk[1] = "주인공: 네, 맞습니다.";
        Npc8_talk[2] = "주인공: 혹시, 열쇠 가지고 계신거 있습니까..?";
        Npc8_talk[3] = "경비3: 무슨 열쇠? 뭐 몇개 가지고있긴한데..";
        Npc8_talk[4] = "경비3: 그런데, 그건 갑자기 왜 물어보는거지?";
        Npc8_talk[5] = "주인공: 그럼 잠시 실례좀 하겠습니다.";
        Npc8_talk[6] = "주인공: (주먹으로 명치를 친다) 퍽!";
        Npc8_talk[7] = "경비3: 크윽... 너 이 자식 뭐하는 놈이야..?";
        Npc8_talk[8] = "주인공: 이 열쇠는 아무리 봐도 아닌 거 같은데.. 치잇";
        Npc8_talk[9] = "경비3: 이번에 들어온 신입은 침입자다! 안쪽으로 들어간다! 잡아라!";

        Npc7_talk_2[0] = "할아버지: 공장은 이제 멈췄나요?";
        Npc7_talk_2[1] = "주인공: 네, 빼앗은 열쇠로 공장의 모든 트레일러랑 기계의 작동을 막았습니다.";
        Npc7_talk_2[2] = "주인공: 이제 더 이상 연기로 인해서 가이아가 더 나빠지진 않을겁니다.";
        Npc7_talk_2[3] = "주인공: 경비원들 또한, 처치하고 묶어놨으니 앞으로의 강제노동같은 착취는 없을거예요.";
        Npc7_talk_2[4] = "할어버지: 감사합니다, 정말 감사해요.";
        Npc7_talk_2[5] = "할아버지: 마지막으로 부탁하나만 더 들어주시겠어요?";
        Npc7_talk_2[6] = "주인공: 네네, 말씀하세요.";
        Npc7_talk_2[7] = "할아버지: 가이아에 아픈 사람이 많아서, 근처 병원에 보내야 할 것 같습니다.";
        Npc7_talk_2[8] = "할아버지: 아레아에 있는 병원이 가장 가까울거에요. ";
        Npc7_talk_2[9] = "할아버지: 전 가이아 사람들이랑 다 함께 아픈 사람 부축해서 나갈테니";
        Npc7_talk_2[10] = "할아버지: 먼저, 아레아로 가서 제 딸에게 전 괜찮다고 안부좀 전해주시겠어요?";
        Npc7_talk_2[11] = "할아버지: 부탁드리겠습니다.";

        Npc10_talk[0] = "주인공: 레이보어!?";
        Npc10_talk[1] = "레이보어: 내 사업을 방해하는 쥐새끼가 넌가?";
        Npc10_talk[2] = "레이보어: 몰래 내 영업장을 들어간것도 모자라 망쳐놔?";
        Npc10_talk[3] = "주인공: 그 쪽이 망쳐놓은 것을 되돌려 놓은 뿐인데.";
        Npc10_talk[4] = "레이보어: 그런 짓을 하고도 몰래 도망칠수있을거라 생각했나?";
        Npc10_talk[5] = "레이보어: 가만두지 않겠어.";

        Npc3_talk_3[0] = "지나: 돌아왔군요! 다행입니다.";
        Npc3_talk_3[1] = "지나: 방금 연락을 받았어요.";
        Npc3_talk_3[2] = "지나: 레이보어와 전투를 치뤘다고.. 몸은 괜찮으세요?";
        Npc3_talk_3[3] = "주인공: 네, 전 괜찮습니다. 일단, 들려줄 소식이 있어요.";
        Npc3_talk_3[4] = "주인공: 가이아에 잠입한 후, 아버님을 뵜습니다.";
        Npc3_talk_3[5] = "주인공: 아버님의 부탁으로, 가이아의 대기 오염의 주된 원인인 공장의 모든 작동을 멈췄고,";
        Npc3_talk_3[6] = "주인공: 관리원들 또한 모두 처리해서, 가이아 사람들이 앞으로의 강제노동이나 착취당할 일은 없을겁니다.";
        Npc3_talk_3[7] = "주인공: 그리고, 아버님께서 부상이 있는 가이아 사람들을 데리고 이쪽 근처 병원으로 오고 계실거예요. 곧 보실 수 있을겁니다.";
        Npc3_talk_3[8] = "주인공: 레이보어는 중앙 호수공원에 묶인 상태로 쓰러져있어요. 가면 바로 체포할 수 있을겁니다.";
        Npc3_talk_3[9] = "지나: 그렇군요. 저희 아버지가 살아계셨군요..";
        Npc3_talk_3[10] = "지나: 정말 다행이에요. 그리고 감사해요.. 아버지를 도와주셔서.";
        Npc3_talk_3[11] = "지나: 그리고 정말, 이 싸움의 끝을 낼 수 있겠네요.";
        Npc3_talk_3[12] = "지나: 그럼 얼른, 아버지를 뵙기 전에 요원들과 함께 레이보어 회사에 가야겠어요." ;
        Npc3_talk_3[13] = "지나: 가서 크리스탈을 되찾고 가이아 사람들에게 돌려드릴 수 있도록 움직여야겠네요.";
        Npc3_talk_3[14] = "지나: 크리스탈을 다시 되돌려 놓으면 가이아가 예전의모습으로 돌아갈 수 있을겁니다.";
        Npc3_talk_3[15] = "지나: 아, 그리고 혹시 마지막 부탁 하나만 더 들어주실 수 있을까요?";
        Npc3_talk_3[16] = "지나: 최근에 근처 마을의 온도가 비정상적으로 계속 상승하고 있다고 합니다. ";
        Npc3_talk_3[17] = "지나: 가이아에 있던 공장의 매연이 영향을 끼쳤을까 걱정이 되어 미리 저희 요원을 보냈습니다.";
        Npc3_talk_3[18] = "지나: 그런데 무슨일이 생겼는지 최근에 연락이 끊겼습니다.";
        Npc3_talk_3[19] = "지나: 여기 저희 요원이 최근에 연락이 끊긴 마지막 위치가 적힌 종이입니다.";
        Npc3_talk_3[20] = "지나: 이 곳으로 찾아가서 어떤 일이 있었는지 알려주시면 감사하겠습니다.";
        Npc3_talk_3[21] = "지나: 부탁드리겠습니다. 그럼, 먼저 이만 움직여보겠습니다. 또 연락드릴게요.";

        Npc11_talk[0] = "소녀: 저기요! 도와주세요!";
        Npc11_talk[1] = "주인공: 여기 무슨일이죠? 어떻게 불이 난거죠?";
        Npc11_talk[2] = "소녀: 요즘 들어 마을 주변에 산불이 자주 일어나고 있어요.";
        Npc11_talk[3] = "소녀: 오른쪽으로 가면 저희 마을이 나와요.";
        Npc11_talk[4] = "소녀: 마을에 우물이 있는데, 양동이를 드릴테니 우물에서 물을 떠와 같이 불을 꺼주시겠어요?";
        Npc11_talk[5] = "소녀: 부탁드리겠습니다. 서두르셔야해요.";

        Npc11_talk_2[0] = "소녀: 감사해요, 도와주셔서.";
        Npc11_talk_2[1] = "소녀: 아! 그리고 그 양동이는 저희 마을의 이장님 꺼인데,";
        Npc11_talk_2[2] = "소녀: 방금 마을로 돌아가서 이장님께 돌려주시겠어요?";
        Npc11_talk_2[3] = "주인공: (이장에게 양동이를 돌려주면서 궁금한 점도 물어봐야겠다.)";

        Npc13_talk[0] = "주인공: 안녕하십니까 이장님, 양동이 돌려드리러 왔습니다.";
        Npc13_talk[1] = "이장: 아, 고맙네. 방금 우리 마을사람과 함께 같이 불끄러 간 것을 보았다네.";
        Npc13_talk[2] = "이장: 고맙네, 청년. 그나저나 이 마을엔 무슨 일로 왔는가? 놀러 온 것 같진 않고..";
        Npc13_talk[3] = "주인공: 아, 개인적으로 찾는 사람이 있어 오게 되었습니다.";
        Npc13_talk[4] = "주인공: 혹시 여기 종이에 적힌 위치가 어디인지 아십니까?";
        Npc13_talk[5] = "이장: 보아하니 마을 위쪽 작은 집이 있는 곳 같구만. ";
        Npc13_talk[6] = "이장: 여기서 위로 올라가서, 길을 따라가다 보면 나올걸세.";
        Npc13_talk[7] = "주인공: 알려주셔서 감사합니다, 이장님.";
        Npc13_talk[8] = "이장: 그나저나, 자네 안더운가?";
        Npc13_talk[9] = "이장: 우리 마을이 안그래도 더운데, 이상하게도 점점 더 더워지고 있어서 안그래도 걱정이 되네.";
        Npc13_talk[10] = "이장: 저기 마을 우물 쪽앞에 시장터로 가면 작은 손선풍기를 살 수 있다네.";
        Npc13_talk[11] = "이장: 거기서 하나 사고 찾아가게나, 그 쪽으로 가는 길이 꽤 걸려서 손선풍기없이는 힘들걸세.";
        Npc13_talk[12] = "주인공: 네 알겠습니다, 감사합니다 이장님.";
        Npc13_talk[13] = "주인공: (확실히 마을이 점점 더워지고 있다는 것은 사실인 것 같고)";
        Npc13_talk[14] = "주인공: (마을 사람들과 대화를 좀 나눠봐야겠어. 싸한 느낌이 들어.)";
        Npc13_talk[15] = "주인공: (일단 손선풍기부터 사러 가자.)";


        Npc14_talk[0] = "주인공: 안녕하십니까, 손선풍기 하나 사러 왔습니다.";
        Npc14_talk[1] = "가게주인: 손선풍기요? 알겠습니다~ 잠시만요.";
        Npc14_talk[2] = "가게주인: 예 여기있습니다, 날씨가 많이 덥죠? 허허";
        Npc14_talk[3] = "주인공: 네..많이 덥네요, 여기 돈 드리겠습니다.";
        Npc14_talk[4] = "가게주인: 진짜 카이만님 아니었으면 저도 그렇고 저희 마을 사람들 멀쩡하게 못돌아다녔을겁니다. 더위먹어서";
        Npc14_talk[5] = "주인공: 카이만이요? 어떤 사람이죠?";
        Npc14_talk[6] = "가게주인: 카이만님은 cs단체의 대장이십니다. 더워에 지치고 돈없는 우리들에게 무료로 에어컨을 제공해주신 분이시죠.";
        Npc14_talk[7] = "가게주인: 현재는 저희 마을의 필요한 전기를 제공해주시죠. ";
        Npc14_talk[8] = "가게주인: 뿐만아니라 자주 전기제품들을 기부해주십니다. 여기 팔고있는 제품들중에서도 카이만님이 주신것도 많죠.";
        Npc14_talk[9] = "주인공: 뭐 따로 그 사람이 받는 것은 없습니까 그럼?";
        Npc14_talk[10] = "가게주인: 뭐.. 딱히 없는 거 같은데요? 전기세 말고는?";
        Npc14_talk[11] = "가게주인: 전기세도 원래는 안받었어요.";
        Npc14_talk[12] = "가게주인: 이제는 많은 사람들이 사용하니까, 저희도 드리는게 맞다고 봅니다.";
        Npc14_talk[13] = "주인공: 흠...네 알겠습니다.";
        Npc14_talk[14] = "가게주인: 아이고 나이 먹었더니 말이 많아져서 하하하하";
        Npc14_talk[15] = "가게주인: 네! 돈받았습니다. 다음에 또 오세요~";
        Npc14_talk[16] = "주인공: 네 감사합니다.";
        Npc14_talk[17] = "주인공: (확실히 먼가 수상해.. 수상한 냄새가 나.)";
        Npc14_talk[18] = "주인공:(다른 마을 사람에게도 대화를 나눠보자.)";


        Npc15_talk[0] = "주인공: 안녕하세요, 아주머니";
        Npc15_talk[1] = "아주머니: 안녕하세요, 어떤 도와드릴 일이 있을까요?";
        Npc15_talk[2] = "주인공: 아, 아닙니다. 뭐 하나 여쭤보자 합니다. ";
        Npc15_talk[3] = "주인공: 혹시 아주머니도 에어컨이나 선풍기를 이용하시나요? ";
        Npc15_talk[4] = "아주머니: 그럼요, 없으면 못살죠?";
        Npc15_talk[5] = "주인공: 전기세가 어느정도 나오나요?";
        Npc15_talk[6] = "아주머니: 전기세요..?";
        Npc15_talk[7] = "아주머니: 자주 사용하다보니 많이 나오는 것같아요.. ";
        Npc15_talk[8] = "아주머니: 안그래도 요세 전기세 때문에 걱정인데, 날씨는 더 더워지니 안틀수가 없고..";
        Npc15_talk[9] = "아주머니: 더군다나 최근에 갑자기 기본 전기세가 올라서 걱정이에요...";
        Npc15_talk[10] = "주인공: 그렇군요.. 답변해주셔서 감사합니다.";

        Player_monologue_2[0] = "주인공: 급격히 더워지는 날씨...";
        Player_monologue_2[1] = "주인공: 카이만이라고 불리는 자의 갑작스런 제공..";
        Player_monologue_2[2] = "주인공: 마을 사람들 기존 전기세 비용 증가..";
        Player_monologue_2[3] = "주인공: 지나 동료의 끊긴 신호...";
        Player_monologue_2[4] = "주인공: 확실히 먼가 수상해..";
        Player_monologue_2[5] = "주인공: 지나의 동료가 무언가를 알고 있지 않았을까?";
        Player_monologue_2[6] = "주인공: 일단 신호 끊긴데로 가서 지나 동료부터 찾아보자.";


        Npc16_talk[0] = "주인공: !!!!";
        Npc16_talk[1] = "주인공: 젠장..이미 죽었어...";
        Npc16_talk[2] = "주인공: 죄송합니다... 늦게 찾아와서...";
        Npc16_talk[3] = "주인공: 음? 잠시만 손에 뭐가 있어...";
        Npc16_talk[4] = "주인공: 죽기 전에 미리 메시지를 남겼구나...";
        Npc16_talk[5] = "주인공: 마을 중앙 우물...";
        Npc16_talk[6] = "주인공: 북... 동...";
        Npc16_talk[7] = "주인공: 역 ㄱ자 뒤에서 접선...";
        Npc16_talk[8] = "주인공: 장소를 의미하는거 같은데?";
        Npc16_talk[9] = "주인공: 27일이면 오늘인데..";
        Npc16_talk[10] = "주인공: 8시면 곧이군.";
        Npc16_talk[11] = "주인공: 일단 이쪽으로 빠르게 가봐야겠어.";

        Find_potal();
        Open_potal();


    }


    //스토리 전개에 따라 단기적이아닌 지속적으로 포탈을 열기위한 함수 
    public void Find_potal()
    {
        try
        {
            House_potal = GameObject.Find("Potal").transform.Find("Secret house potal").gameObject;
        }
        catch
        {
            Debug.Log(House_potal  + "시크릿하우스포탈 못찾음!");

        }
        try
        {
            Secret_battle_potal = GameObject.Find("Potal").transform.Find("Secret_battle potal").gameObject;
        }
        catch
        {
            Debug.Log(Secret_battle_potal + "시크릿배틀포탈 못찾음!");
        }
        try
        {
            Miro_potal = GameObject.Find("Potal").transform.Find("miro potal").gameObject;
        }
        catch
        {
            Debug.Log(Miro_potal + "미로포탈 못찾음!");
        }
        try
        {
            Gaiatofight_potal = GameObject.Find("Potal").transform.Find("Gaiatofight").gameObject;
        }
        catch
        {
            Debug.Log(Gaiatofight_potal + "가이아에서의 싸움포탈 못찾음!");
        }
        try
        {
            AreatoBoss_potal = GameObject.Find("Potal").transform.Find("AreatoBoss").gameObject;
        }
        catch

        {
            Debug.Log(AreatoBoss_potal + "아레아에서의 보스포탈 못찾음!");
        }
        try
        {
            AreatoFire_potal = GameObject.Find("Potal").transform.Find("AreatoFire").gameObject;
        }
        catch

        {
            Debug.Log(AreatoFire_potal + "아레아에서의 보스포탈 못찾음!");
        }
        try
        {
            AreatoFire_potal = GameObject.Find("Potal").transform.Find("DeserttoTop").gameObject;
        }
        catch

        {
            Debug.Log(AreatoFire_potal + "아레아에서의 보스포탈 못찾음!");
        }


    }

    public void Open_potal()
    {

        if(House_potal != null && NpcQuest.questnum >= 2)
        {
            House_potal.SetActive(true);
        }

        if(Secret_battle_potal != null && NpcQuest.questnum == 4)
        {
            Secret_battle_potal.SetActive(true);
        }
        if( Miro_potal != null && NpcQuest.questnum >= 6 && NpcQuest.use_badge == 1)
        {
            Miro_potal.SetActive(true);
        }
        if(Gaiatofight_potal != null && NpcQuest.questnum == 10)
        {
            Gaiatofight_potal.SetActive(true);
        }
        if (AreatoBoss_potal != null && NpcQuest.questnum == 13)
        {
            AreatoBoss_potal.SetActive(true);
        }
        if (AreatoFire_potal != null && NpcQuest.questnum >= 14)
        {
            AreatoFire_potal.SetActive(true);
        }
        if (DeserttoTop_potal != null && NpcQuest.questnum >= 27)
        {
            DeserttoTop_potal.SetActive(true);
        }
        


    }

    //독백액션
    public void Monologue_Action()
    {
        if (NpcQuest.questnum == 7)
        {

            Player_name.SetActive(true);
            Npc_name_position.SetActive(false);

            talkText.text = Player_monologue_1[0].Split(':')[1];
            talkPanel.SetActive(isTalking);
            StartCoroutine(talk_animation(talkText));
            if (isTalking == true)
            {
                if (talk_num == Player_monologue_1.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                }


                else if (talk_num < Player_monologue_1.Length)
                {
                    talkText.text = Player_monologue_1[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                }
            }
        }

        else if(NpcQuest.questnum == 27)
        {

            Player_name.SetActive(true);
            Npc_name_position.SetActive(false);

            talkText.text = Player_monologue_2[0].Split(':')[1];
            talkPanel.SetActive(isTalking);
            StartCoroutine(talk_animation(talkText));
            if (isTalking == true)
            {
                if (talk_num == Player_monologue_2.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                }


                else if (talk_num < Player_monologue_2.Length)
                {
                    talkText.text = Player_monologue_2[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                }
            }
        }

    }

    public void OnOff_name(string name)
    {
        if (name == "주인공")
        {
            Player_name.SetActive(true);
            Npc_name_position.SetActive(false);
        }
        else
        {
            Npc_name.text = name;
            Npc_name_position.SetActive(true);
            Player_name.SetActive(false);
        }
    }


    public string talkbox_2; // 이름 뒷부분 문장 저장
    public string[] talk_Split; // 이름 뒷부분 문장들을 공백으로 나눔
    public int talk_split_num = 0;
    IEnumerator talk_animation(Text t)
    {
        talkbox_2 = t.text;
        talkText.text = " ";
        talk_split_num = 0;
        talk_Split = talkbox_2.Split(" ");
        
        while(talk_split_num < talk_Split.Length)
        {
            talkText.text = talkText.text + " " + talk_Split[talk_split_num];
            talk_split_num++;

            yield return new WaitForSeconds(0.1f);
        }
      
       
    }


    // 대화액션
    public void Action(GameObject scanObj)
    {
        //npc1
        if (scanObj.name == "Npc1" && NpcQuest.questnum == 1)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc1_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                }


                else if (talk_num < Npc1_talk.Length)
                {
                    talkText.text = Npc1_talk[talk_num].Split(":")[1];
                    StartCoroutine(talk_animation(talkText));
                    talk_animation(talkText);
                    OnOff_name(Npc1_talk[talk_num].Split(':')[0]);

                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc1_talk[talk_num].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc1_talk[talk_num].Split(':')[0]);
            }
        }

        //npc2
        else if (scanObj.name == "Npc2" && NpcQuest.questnum == 2)
        {

            if (isTalking == true)
            {
                if (talk_num == Npc2_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                    House_potal.SetActive(true);

                }


                else if (talk_num < Npc2_talk.Length)
                {
                    talkText.text = Npc2_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc2_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc2_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc2_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc3" && NpcQuest.questnum == 3)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc3_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                    
            
                }


                else if (talk_num < Npc3_talk.Length)
                {
                    talkText.text = Npc3_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc3_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc3_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc3_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc4" && NpcQuest.questnum == 4)
        {
           
            if (isTalking == true)
            {
                if (talk_num == Npc4_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                    Secret_battle_potal.SetActive(true);

                }


                else if (talk_num < Npc4_talk.Length)
                {
                    talkText.text = Npc4_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc4_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc4_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc4_talk[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc3" && NpcQuest.questnum == 5)
        {
         
            if (isTalking == true)
            {
                if (talk_num == Npc3_talk_2.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                    NpcQuest.get_badge = 1;

                }


                else if (talk_num < Npc3_talk_2.Length)
                {
                    talkText.text = Npc3_talk_2[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc3_talk_2[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc3_talk_2[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc3_talk_2[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc5" && NpcQuest.questnum == 6)
        {

            if(NpcQuest.use_badge == 1)
            {
                NpcQuest.clear_badge_mission = 1;
                if (isTalking == true)
                {
                    if (talk_num == Npc5_talk_p.Length)
                    {
                        talk_num = 0;
                        isTalking = false;
                        talkPanel.SetActive(isTalking);
                        Miro_potal.SetActive(true);
                    }


                    else if (talk_num < Npc5_talk_p.Length)
                    {
                        talkText.text = Npc5_talk_p[talk_num].Split(':')[1];
                        StartCoroutine(talk_animation(talkText));
                        OnOff_name(Npc5_talk_p[talk_num].Split(':')[0]);
                    }
                }
                else
                {
                    isTalking = true;
                    talkText.text = Npc5_talk_p[0].Split(':')[1];
                    talkPanel.SetActive(isTalking);
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc5_talk_p[talk_num].Split(':')[0]);
                }
            }
            else
            {
                if (isTalking == true)
                {
                    if (talk_num == Npc5_talk_ip.Length)
                    {
                        talk_num = 0;
                        isTalking = false;
                        talkPanel.SetActive(isTalking);
                    }


                    else if (talk_num < Npc5_talk_ip.Length)
                    {
                        talkText.text = Npc5_talk_ip[talk_num].Split(':')[1];
                        StartCoroutine(talk_animation(talkText));
                        OnOff_name(Npc5_talk_ip[talk_num].Split(':')[0]);
                    }
                }
                else
                {
                    isTalking = true;
                    talkText.text = Npc5_talk_ip[0].Split(':')[1];
                    talkPanel.SetActive(isTalking);
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc5_talk_ip[talk_num].Split(':')[0]);
                }
            }
        }

        else if (scanObj.name == "Npc6" && NpcQuest.questnum == 8)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc6_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc6_talk.Length)
                {
                    talkText.text = Npc6_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc6_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc6_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc6_talk[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc7" && NpcQuest.questnum == 9)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc7_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc7_talk.Length)
                {
                    talkText.text = Npc7_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc7_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc7_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc7_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc8" && NpcQuest.questnum == 10)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc8_talk.Length)
                {
                    Gaiatofight_potal.SetActive(true);
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc8_talk.Length)
                {
                    talkText.text = Npc8_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc8_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc8_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc8_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc7" && NpcQuest.questnum == 12)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc7_talk_2.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc7_talk_2.Length)
                {
                    talkText.text = Npc7_talk_2[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc7_talk_2[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc7_talk_2[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc7_talk_2[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc10" && NpcQuest.questnum == 13)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc10_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);
                    AreatoBoss_potal.SetActive(true);

                }


                else if (talk_num < Npc10_talk.Length)
                {
                    talkText.text = Npc10_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc10_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc10_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc10_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc3" && NpcQuest.questnum == 14)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc3_talk_3.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc3_talk_3.Length)
                {
                    talkText.text = Npc3_talk_3[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc3_talk_3[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc3_talk_3[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc3_talk_3[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc11" && NpcQuest.questnum == 15)
        {

            if (isTalking == true)
            {
                if (talk_num == Npc11_talk.Length)
                {
                    NpcQuest.get_basket = 1;
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);

                }


                else if (talk_num < Npc11_talk.Length)
                {
                    talkText.text = Npc11_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc11_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc11_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc11_talk[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc11" && NpcQuest.questnum == 23)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc11_talk_2.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);


                }


                else if (talk_num < Npc11_talk_2.Length)
                {
                    talkText.text = Npc11_talk_2[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc11_talk_2[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc11_talk_2[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc11_talk_2[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc13" && NpcQuest.questnum == 24)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc13_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);


                }


                else if (talk_num < Npc13_talk.Length)
                {
                    talkText.text = Npc13_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc13_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc13_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc13_talk[talk_num].Split(':')[0]);
            }
        }
        else if (scanObj.name == "Npc14" && NpcQuest.questnum == 25)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc14_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);


                }


                else if (talk_num < Npc14_talk.Length)
                {
                    talkText.text = Npc14_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc14_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc14_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc14_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc15" && NpcQuest.questnum == 26)
        {
            if (isTalking == true)
            {
                if (talk_num == Npc15_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    talkPanel.SetActive(isTalking);


                }


                else if (talk_num < Npc15_talk.Length)
                {
                    talkText.text = Npc15_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc15_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc15_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc15_talk[talk_num].Split(':')[0]);
            }
        }

        else if (scanObj.name == "Npc16" && NpcQuest.questnum == 28)
        {

            letter = GameObject.Find("letter").transform.Find("paper").gameObject;
            if (isTalking == true)
            {
                if(talk_num == 4)
                {
                    letter.SetActive(true);
                }

                if (talk_num == Npc16_talk.Length)
                {
                    talk_num = 0;
                    isTalking = false;
                    letter.SetActive(false);
                    talkPanel.SetActive(isTalking);


                }


                else if (talk_num < Npc16_talk.Length)
                {
                    talkText.text = Npc16_talk[talk_num].Split(':')[1];
                    StartCoroutine(talk_animation(talkText));
                    OnOff_name(Npc16_talk[talk_num].Split(':')[0]);
                }
            }
            else
            {
                isTalking = true;
                talkText.text = Npc16_talk[0].Split(':')[1];
                talkPanel.SetActive(isTalking);
                StartCoroutine(talk_animation(talkText));
                OnOff_name(Npc16_talk[talk_num].Split(':')[0]);
            }
        }



    }

    

  
}
