sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escpae_Npc : MonoBehaviour
{
    public GameObject Npc;
    public GameObject gameManager;
    public GameObject player;
    public SpriteRenderer renderer;
    public bool check;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
        player = GameObject.Find("Player").gameObject;
        renderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        check = gameManager.GetComponent<GameManager>().isTalking;
        if (!check)
        {
            escape_or_showNpc();
        }
    }

    void escape_or_showNpc()
    {
        if(NpcQuest.questnum >= 8)  //Npc6없애기
        {
            try
            {
                Npc = GameObject.Find("Npc").transform.Find("Npc6").gameObject;
                Npc.SetActive(false);
            }
            catch
            {
                Debug.Log("Npc6못찾음!");
            }
        }
        if (NpcQuest.questnum == 12)  
        {
            try
            {
                Npc = GameObject.Find("Npc").transform.Find("Npc10").gameObject;
                Npc.SetActive(true);
            }
            catch
            {
                Debug.Log("Npc10못찾음!");
            }
        }
        if (NpcQuest.questnum >= 29)  
        {
            try
            {
                Npc = GameObject.Find("Npc").transform.Find("Npc19").gameObject;
                Npc.SetActive(false);
            }
            catch
            {
                Debug.Log("Npc19못찾음!");
            }
        }
        if (NpcQuest.questnum >= 30)
        {
            try
            {
                Npc = GameObject.Find("Npc").transform.Find("Npc18").gameObject;
                Npc.SetActive(false);
            }
            catch
            {
                Debug.Log("Npc18못찾음!");
            }
        }
        if (NpcQuest.questnum >= 30.5f)
        {
            try
            {
                Npc = GameObject.Find("Npc").transform.Find("Npc20").gameObject;
                Npc.SetActive(true);
            }
            catch
            {
                Debug.Log("Npc18못찾음!");
            }
        }
        if (NpcQuest.questnum >= 33f)
        {
            try
            {
                if(SceneManager.GetActiveScene().buildIndex == 15)
                {
                    renderer.enabled = true;
                }
  
            }
            catch
            {
                Debug.Log("player못찾음!");
            }
        }

        if (NpcQuest.questnum >= 33.5f)
        {
            try
            {
                 Npc = GameObject.Find("Npc").transform.Find("Npc21").gameObject;
                 Npc.SetActive(false);
                 Npc = GameObject.Find("2Npc").transform.Find("Npc22").gameObject;
                 Npc.SetActive(true);         
            }
            catch
            {
                Debug.Log("player못찾음!");
            }
        }

        if (NpcQuest.questnum >= 34f)
        {
            try
            {
                if (SceneManager.GetActiveScene().buildIndex == 14 || SceneManager.GetActiveScene().buildIndex == 15)
                {
                    Npc = GameObject.Find("Npc");
                    Npc.SetActive(false);
                }
            }
            catch
            {
                Debug.Log("player못찾음!");
            }
        }

    }

}
