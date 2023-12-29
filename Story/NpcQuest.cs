using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NpcQuest
{
    public static GameObject Npc;
    public static float questnum = 24f;

    public static int get_badge; //퀘스트넘6을 위한 퀘스트아이템  1이면 받음  ,get 1이되면 ui에서 on으로
    public static int use_badge; // 1: 사용함 0: 사용안함 , use는 1이되면 ui에서 off로꺼버리기
    public static int clear_badge_mission; // clear여부로 전구와 퀘스트창 띄우기 위해서.

    public static int get_key; //퀘스트12를 위한 퀘스트아이템 여기는 대화창이 없기에 clear변수 따로필요 없음.
    public static int use_key;

    public static int get_basket;
    public static int use_basket;

    public static int get_water;
    public static int use_water;



}
