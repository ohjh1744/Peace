using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_result : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;


    bool p_w;
    bool p_l;


    void Update()
    {
        p_w = boss.GetComponent<Status>().player_win;
        p_l = player.GetComponent<Status>().player_lose;

        Player_win();
        Player_Lose();
    }

    public void Player_win()
    {
       if(NpcQuest.questnum == 4)
        {
            if(p_w == true)
            {
                Debug.Log("win!");
                NpcQuest.questnum = 4.5f;
                SceneManager.LoadScene(2);
            }
        }
       else if(NpcQuest.questnum == 10)
        {
            if (p_w == true)
            {
                Debug.Log("win!");
                NpcQuest.get_key = 1;
                NpcQuest.questnum = 10.5f;
                SceneManager.LoadScene(5);
            }
        }
        else if (NpcQuest.questnum == 13)
        {
            if (p_w == true)
            {
                Debug.Log("win!");
                NpcQuest.questnum = 13.5f;
                SceneManager.LoadScene(1);
            }
        }



    }

    public void Player_Lose()
    {
        if(p_l == true)
        {
            Debug.Log("Lose!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
