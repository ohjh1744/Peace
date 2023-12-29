using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene0_dialogue : MonoBehaviour
{
    public GameObject text_show;
    public GameObject map_show;
    public Text text;

    int talknum = 0;
    string[] talkbox = new string[5];

    void Awake()
    {
        talkbox[0] = "주인공: 후...드디어 도착했군... ";
        talkbox[1] = "주인공: 여기가 자동차 산업으로 빠른 성장을 이룬 도시 아레아인가? ";
        talkbox[2] = "주인공: 확실히 그 비싸고 좋은 차들이 많이 보이는군..";
        talkbox[3] = "주인공: 스스로 동력을 생산하는 자동차라니.. 직접보니 더 신기하군.";
        talkbox[4] = "주인공: 오랜만에 쉬러 온 김에 좀 둘러볼까?";
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(talknum == 0)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 1;
            }
            else if (talknum == 1)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 2;
            }
            else if (talknum == 2)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                map_show.SetActive(true);
                talknum = 3;
            }
            else if (talknum == 3)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 4;
            }
            else if (talknum == 4)
            {
                text.text = talkbox[talknum];
                text_show.SetActive(true);
                talknum = 5;
            }
            else if (talknum == 5)
            {
                SceneManager.LoadScene(1);
            }
        }




    }
}
