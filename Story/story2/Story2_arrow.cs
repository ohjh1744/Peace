using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story2_arrow : MonoBehaviour
{
    GameObject explosion;
    void Start()
    {
        //explosion은 stroy2_exp씬에서 필요한 아이템으로 setactive true시키면 사라지므로 오류제거를 위해 awake에서 따로 선언.
        try
        {
            explosion = GameObject.Find("Effect").transform.Find("Explosion").gameObject;
        }
        catch
        {
            Debug.Log("explosion 못찾음");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "Story2_Tank")
        {
            explosion.SetActive(true);
            gameObject.SetActive(false);
        } 
    }
}
