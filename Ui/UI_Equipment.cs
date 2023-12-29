using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
    public GameObject equip;


    void Start()
    {
        // console창 빨간문 오류 제거하기위해서 미리 초기화 설정해놈. 안해도 게임자체에는 지장없긴함.
        try
        {
            equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("initial").gameObject;
            Debug.Log(equip + "찾음!");
        }
        catch
        {
            Debug.Log(equip + "badge못찾음!");

        }
    }

    void Update()
    {
        Find_Equipment();
        //스토리 1에서의 뱃찌
        if (NpcQuest.get_badge == 1)
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_key == 1)  //battle_result에서 get_key 1전환
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_basket == 1 )
        {
            equip.SetActive(true);
        }
        else if (NpcQuest.get_water == 1)
        {
            //코드상 여기서 basket이미지 안보이게함.
            GameObject basket = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Basket").gameObject;
            basket.SetActive(false);
            equip.SetActive(true);
        }
        else
        {
            equip.SetActive(false);
        }

    }

    void Find_Equipment()
    {

        if (NpcQuest.questnum == 5)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Badge").gameObject;
                Debug.Log(equip + "찾음!");
            }
            catch
            {
                Debug.Log(equip + "badge못찾음!");

            }
        }

        else if (NpcQuest.questnum == 10.5f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Key").gameObject;
                Debug.Log(equip + "찾음!");
            }
            catch
            {
                Debug.Log(equip + "key못찾음!");

            }
        }
        else if (NpcQuest.questnum == 15f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Basket").gameObject;
                Debug.Log(equip + "찾음!");
            }
            catch
            {
                Debug.Log(equip + "Basket못찾음!");

            }
        }
        else if (NpcQuest.questnum == 16f)
        {
            try
            {
                equip = GameObject.Find("UI").transform.Find("CharacterUi").gameObject.transform.Find("EquipSet").gameObject.transform.Find("Water_Basket").gameObject;

                Debug.Log(equip + "찾음!");
            }
            catch
            {
                Debug.Log(equip + "Water_Basket못찾음!");

            }
        }







    }
}
