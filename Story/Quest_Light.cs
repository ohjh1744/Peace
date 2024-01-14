using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Light : MonoBehaviour
{

    public GameObject Npc_light;
    public GameObject gameManager;
    public bool check; //대화끝나고 전구 띄우기위함.

    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
        Npc_light = GameObject.Find("Npc").transform.Find("Light").gameObject; // 초기화 미리 이유: 씬넘어가면서 false부분에서 막히기때문에.
    }
    void Update()
    {
        check = gameManager.GetComponent<GameManager>().isTalking;
        if (!check)
        {
            Light_on();
        }
    }

    public void Light_on()
    {
        if(NpcQuest.questnum == 0)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc1").transform.Find("On_quest").gameObject;
            }
            catch
            {
                Debug.Log("퀘스트전구 못찾음!");
            }
            Npc_light.SetActive(true);
        }
        else if(NpcQuest.questnum == 1)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc2").transform.Find("On_quest").gameObject;
                if(Npc_light == GameObject.Find("Npc").transform.Find("Npc2").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 2 || NpcQuest.questnum == 4.5f)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc3").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc3").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
            
        }
        else if (NpcQuest.questnum == 3)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc4").transform.Find("On_quest").gameObject;
                if(Npc_light == GameObject.Find("Npc").transform.Find("Npc4").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }

        }
        else if (NpcQuest.questnum == 4)
        {
            //이부분의 경우 전투교관에게 말을걸고 느낌표없애기만함. 
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("이전 퀘스트 전구 못없앰!");
            }

        }
        else if (NpcQuest.questnum == 5)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc5").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc5").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }

        }
        else if( NpcQuest.questnum == 6 && NpcQuest.clear_badge_mission == 1)
        {
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("이전 퀘스트 전구 못없앰!");
            }
        }
        else if (NpcQuest.questnum == 7)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc6").transform.Find("On_quest").gameObject;
                if(Npc_light == GameObject.Find("Npc").transform.Find("Npc6").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }

        }
        else if (NpcQuest.questnum == 8)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc7").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc7").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }

        }
        else if (NpcQuest.questnum == 9)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc8").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc8").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }

        }
        else if(NpcQuest.questnum == 10)
        {
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("이전 퀘스트 전구 못없앰!");
            }
        }
        else if(NpcQuest.questnum == 10.5f)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc9").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc9").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if(NpcQuest.questnum == 11f)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc7").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc7").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if(NpcQuest.questnum == 12)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc10").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc10").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 13)
        {
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("퀘스트전구 못찾아서 못숨김");
            }
        }
        else if (NpcQuest.questnum == 13.5f)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc3").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc3").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 14)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc11").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc11").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 15)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc12").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc12").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 16)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning1").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning1").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 17)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning2").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning2").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 18)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning3").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning3").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 19)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning4").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning4").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 20)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning5").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning5").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 21)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Burning6").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Burning6").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 22)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc11").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc11").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 23)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc13").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc13").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 24)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc14").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc14").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 25)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc15").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc15").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if(NpcQuest.questnum == 26)
        {
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }

        else if (NpcQuest.questnum == 27)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc16").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc16").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 28)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc17").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc17").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 29)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc18").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc18").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 30f)
        {
            try
            {
                Npc_light.SetActive(false);
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 30.5f)
        {
            try
            {
                Npc_light = GameObject.Find("Npc").transform.Find("Npc20").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc20").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 33.5f)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("2Npc").transform.Find("Npc22").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("2Npc").transform.Find("Npc22").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }
        else if (NpcQuest.questnum == 34f)
        {
            try
            {
                Npc_light.SetActive(false);
                Npc_light = GameObject.Find("Npc").transform.Find("Npc13").transform.Find("On_quest").gameObject;
                if (Npc_light == GameObject.Find("Npc").transform.Find("Npc13").transform.Find("On_quest").gameObject)
                {
                    Npc_light.SetActive(true);
                }
            }
            catch
            {
                Debug.Log("다음 퀘스트전구 못찾아서 못열음");
            }
        }






    }

}
