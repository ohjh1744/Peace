using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1_mine_fight_GameManager : MonoBehaviour
{
    public static Scene1_mine_fight_GameManager instance;
    public MobPoolManager pool;
    public MobSpawner spawner;

    public int VictoryMobCount;
    public int MaxSpawnMobCount;
    [HideInInspector]
    public int CatchMobCount=0;

    [Header("UI")]
    public Text VictoryCount;
    public Text CatCount;
    public Status playerStatus;

    void Awake()
    {
        instance = this;
        if(VictoryMobCount < MaxSpawnMobCount) VictoryMobCount = MaxSpawnMobCount;
        VictoryCount.text = VictoryMobCount.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < MaxSpawnMobCount; i++)
        {
            spawner.Spawn();
        }
    } //시점때문에 스폰은 Awake다음으로

    private void Update()
    {
        int mob_cnt = CurMobCount();
        int dif = MaxSpawnMobCount - mob_cnt;
        if (dif > 0)
        {
            VictoryMobCount -= dif;
            print("남은 몹 개수: " + VictoryMobCount);
            if (VictoryMobCount <= 0)
            {
                Gameover(); //승리조건만큼의 몹을 잡았을때 게임 승리
            }
            else // 승리조건까지 달성하지 못한경우에 두가지 경우
            {
                if(VictoryMobCount > mob_cnt)
                {
                    for (int i = 0; i < dif; i++)
                    {
                        spawner.Spawn();
                    }
                }
                else
                {
                    MaxSpawnMobCount = mob_cnt; //dif가 더이상 발생하지 않아야됨
                }
                CatchMobCount += dif;
            }
        }
        CatCount.text = CatchMobCount.ToString();
    }

    public int CurMobCount()
    {
        int res = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) { res++; }
        }
        return res;
    }

    void Gameover()
    {
        playerStatus.player_win = true;
}
}
