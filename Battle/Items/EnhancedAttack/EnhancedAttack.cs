using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancedAttack : MonoBehaviour
{

    Battle_Shooter battle_Shooter;
    GameObject enhancedbullet_ui;
    GameObject generalbullet_ui;
    Text bulletCountTxt;

    [HideInInspector]
    public int CurBulletCnt;

    private void OnEnable()
    {
        battle_Shooter = GetComponent<Battle_Shooter>();
        try
        {
            enhancedbullet_ui = GetComponent<SkillUIProvider>().CoolTimeBulletList[2].transform.parent.gameObject;
            generalbullet_ui = GetComponent<SkillUIProvider>().CoolTimeBulletList[0].transform.parent.gameObject;
        }
        catch
        {
            print("강화공격 UI가 적절하게 설정이 안됨");
        }

        bulletCountTxt = enhancedbullet_ui.GetComponentInChildren<Text>(); ;
        Battle_Shooter.OnFireExcuted += HandlerFireExecuted;
    }

    private void HandlerFireExecuted(Transform other_transform, int bulletIdx)
    {
        if (transform.CompareTag(other_transform.tag) && bulletIdx == 2) // 2번이 강화 공격이라고 가정
        {
            CurBulletCnt--;
            UpdateBulletState();
        }
    }

    public void UpdateBulletState()
    {
        if (enhancedbullet_ui.activeSelf == false)
        {
            battle_Shooter.keys[0] = ""; //기존 일반공격 키는 먹통으로 만들기
            battle_Shooter.keys[2] = "Fire1"; //키 선정
            generalbullet_ui.SetActive(false);
            enhancedbullet_ui.SetActive(true);
        }

        if (CurBulletCnt >= 100) bulletCountTxt.text = "?"; //100발 이상의 강화 공격일시 ?표기
        else bulletCountTxt.text = CurBulletCnt.ToString();

        if (CurBulletCnt <= 0)
        {
            generalbullet_ui.SetActive(true);
            enhancedbullet_ui.SetActive(false); // 원래 무기 UI로 복구
            battle_Shooter.keys[0] = "Fire1";
            battle_Shooter.keys[2] = ""; //원래키 복구
            CurBulletCnt = 0;
        }
    }

    private void OnDisable()
    {
        Battle_Shooter.OnFireExcuted -= HandlerFireExecuted;
    }
}
