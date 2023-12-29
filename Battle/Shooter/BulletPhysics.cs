using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject ui;
    private Vector3 initialPosition;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialPosition = rigid.transform.position;
        ui = GameObject.Find("UiControl");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {   
            // GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            // 충돌한 객체가 "Player" 또는 "Obstacle" 태그를 가지고 있다면 총알을 비활성화
            ui.GetComponent<UiControl>().GetHurt();
            gameObject.SetActive(false);
            rigid.transform.position = initialPosition;
        }

        if (collision.collider.CompareTag("Obstacle"))
        {   
            // 충돌한 객체가 "Player" 또는 "Obstacle" 태그를 가지고 있다면 총알을 비활성화
            gameObject.SetActive(false);
            rigid.transform.position = initialPosition;
        }
    }
}
