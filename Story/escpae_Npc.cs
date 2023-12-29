using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escpae_Npc : MonoBehaviour
{
    public GameObject Npc;
    public GameObject gameManager;
    public bool check;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject;
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
        if (NpcQuest.questnum == 12)  //Npc6없애기
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

    }

}
