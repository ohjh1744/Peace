using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTeleportEffect : MonoBehaviour
{
    private SpriteRenderer rend;
    private Collider2D coll;
    public GameObject Mob;
    public List<GameObject> ToolsObject;

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        rend = Mob.GetComponent<SpriteRenderer>();
        rend.enabled = false; // 렌더러 비활성화
        coll = Mob.GetComponent<Collider2D>();
        coll.enabled = false; // 콜라이더 비활성화
        if(ToolsObject != null)
        {
            for(int i = 0; i < ToolsObject.Count; i++)
            {
                ToolsObject[i].GetComponent<SpriteRenderer>().enabled = false;
                ToolsObject[i].GetComponent<Collider2D>().enabled = false;
            }
        }
        var anim = GetComponent<Animator>();
        anim.Play(0);
    }

    public void TeleportEnd()
    {
        rend.enabled = true;
        coll.enabled = true;
        if (ToolsObject != null)
        {
            for (int i = 0; i < ToolsObject.Count; i++)
            {
                ToolsObject[i].GetComponent<SpriteRenderer>().enabled = true;
                ToolsObject[i].GetComponent<Collider2D>().enabled = true;
            }
        }
        Mob.GetComponent<EnemyAI>().isPlay = true;
        GetComponent<Animator>().SetTrigger("End");
    }

    public void AnimationEnd()
    {
        var anim = GetComponent<Animator>();
        anim.StopPlayback();
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
