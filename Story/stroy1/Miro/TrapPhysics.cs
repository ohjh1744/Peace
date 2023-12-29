using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPhysics : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject ui;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ui = GameObject.Find("UiControl");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {   
            ui.GetComponent<UiControl>().GetHurt();
        }
    }
}
