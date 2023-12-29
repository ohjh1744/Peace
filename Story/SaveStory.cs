using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStory : MonoBehaviour
{

    Rigidbody2D rigid;


    void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", rigid.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", rigid.transform.position.y);
        PlayerPrefs.SetFloat("QuestNum", NpcQuest.questnum);
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.SetInt("EnterSecrethouse", CheckEnter.EnterSecrethouse);
        PlayerPrefs.SetInt("EnterSecretbattle", CheckEnter.EnterSecretbattle);
        PlayerPrefs.SetInt("FromCitytoMiro", CheckEnter.FromCitytoMiro);
        PlayerPrefs.SetInt("FromMirotoGaia", CheckEnter.FromMirotoGaia);
        PlayerPrefs.SetInt("FromGaiatofight", CheckEnter.FromGaiatofight);
        PlayerPrefs.SetInt("FromAreatoBoss", CheckEnter.FromAreatoBoss);
        PlayerPrefs.SetInt("FromAreatoFire", CheckEnter.FromAreatoFire);
        PlayerPrefs.SetInt("FromFiretoDesert", CheckEnter.FromFiretoDesert);
        PlayerPrefs.SetInt("FromDesrttoTop", CheckEnter.FromDesrttoTop);
        PlayerPrefs.SetInt("FromToptoKilled", CheckEnter.FromToptoKilled);

        PlayerPrefs.SetInt("get_badge", NpcQuest.get_badge);
        PlayerPrefs.SetInt("use_badge", NpcQuest.use_badge);
        PlayerPrefs.SetInt("clear_badge_mission", NpcQuest.clear_badge_mission);

        PlayerPrefs.SetInt("get_key", NpcQuest.get_key);
        PlayerPrefs.SetInt("use_key", NpcQuest.use_key);

        PlayerPrefs.SetInt("get_basket", NpcQuest.get_basket);
        PlayerPrefs.SetInt("use_basket", NpcQuest.use_basket);

        PlayerPrefs.SetInt("get_water", NpcQuest.get_water);
        PlayerPrefs.SetInt("use_water", NpcQuest.use_water);

    }

    void LoadGame()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float Qnum = PlayerPrefs.GetFloat("QuestNum");
        int Scene_num = PlayerPrefs.GetInt("Scene");
        int EnterSecrethouse = PlayerPrefs.GetInt("EnterSecrethouse");
        int EnterSecretbattle = PlayerPrefs.GetInt("EnterSecretbattle");
        int FromCitytoMiro = PlayerPrefs.GetInt("FromCitytoMiro");
        int FromMirotoGaia = PlayerPrefs.GetInt("FromMirotoGaia");
        int FromGaiatofight = PlayerPrefs.GetInt("FromGaiatofight");
        int FromAreatoBoss = PlayerPrefs.GetInt("FromAreatoBoss");
        int FromAreatoFire = PlayerPrefs.GetInt("FromAreatoFire");
        int FromFiretoDesert = PlayerPrefs.GetInt("FromFiretoDesert");
        int FromDesrttoTop = PlayerPrefs.GetInt("FromDesrttoTop");
        int FromToptoKilled = PlayerPrefs.GetInt("FromToptoKilled");
        int get_badge = PlayerPrefs.GetInt("get_badge");
        int use_badge = PlayerPrefs.GetInt("use_badge");
        int clear_badge_mission = PlayerPrefs.GetInt("clear_badge_mission");
        int get_key = PlayerPrefs.GetInt("get_key");
        int use_key = PlayerPrefs.GetInt("use_key");
        int get_basket = PlayerPrefs.GetInt("get_basket");
        int use_basket = PlayerPrefs.GetInt("use_basket");
        int get_water = PlayerPrefs.GetInt("get_water");
        int use_water = PlayerPrefs.GetInt("use_water");



        rigid.transform.position = new Vector3(x, y, 0);
        NpcQuest.questnum = Qnum;
      
        CheckEnter.EnterSecrethouse = EnterSecrethouse;
        CheckEnter.EnterSecretbattle = EnterSecretbattle;
        CheckEnter.FromCitytoMiro = FromCitytoMiro;
        CheckEnter.FromMirotoGaia = FromMirotoGaia;
        CheckEnter.FromGaiatofight = FromGaiatofight;
        CheckEnter.FromAreatoBoss = FromAreatoBoss;
        CheckEnter.FromAreatoFire = FromAreatoFire;
        CheckEnter.FromFiretoDesert = FromFiretoDesert;
        CheckEnter.FromDesrttoTop = FromDesrttoTop;
        CheckEnter.FromToptoKilled = FromToptoKilled;

        NpcQuest.get_badge = get_badge;
        NpcQuest.use_badge = use_badge;
        NpcQuest.clear_badge_mission = clear_badge_mission;

        NpcQuest.get_key = get_key;
        NpcQuest.use_key = use_key;

        NpcQuest.get_basket = get_basket;
        NpcQuest.use_basket = use_basket;

        NpcQuest.get_water = get_water;
        NpcQuest.use_water = use_water;

        SceneManager.LoadScene(Scene_num);




    }
}
