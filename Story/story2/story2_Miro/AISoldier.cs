using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISoldier : MonoBehaviour
{

    Rigidbody2D rigid;
    public float speed;
    public Vector2 dir; 
    public int direction_H;
    public int direction_V;

    public GameObject warning;
    public GameObject n_warning;

    bool isspeedup; //코루틴 한번씩 순차대로 실행하도록


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Direction();
    }

    void FixedUpdate()
    {
        scan();
        if (gameObject.layer == 10)
        {
            Move_Vertical();  
        }
        else
        {
            Move_Horizontal();
        }
    }

    void Direction()
    {
        direction_H = Random.Range(0, 2);  // 0은 좌, 1은 우
        direction_V = Random.Range(0, 2);  // 0은 위, 1은 아래

        Invoke("Direction", 2);
    }

    IEnumerator SpeedUp()
    {
        if (isspeedup == true)
        {
            yield break;
        }

        isspeedup = true;

        warning.SetActive(true);
        n_warning.SetActive(false);
        speed = 6;

        yield return new WaitForSeconds(3);

        speed = 3;
        n_warning.SetActive(true);
        warning.SetActive(false);
        isspeedup = false;

        yield break;

    }

    void Move_Horizontal() //수평이동
    {
        if(direction_H == 0)
        {
            dir = Vector2.left;
            rigid.velocity = dir * speed;
        }
        else
        {
            dir = Vector2.right;
            rigid.velocity = dir * speed;
        }
    }

    void Move_Vertical() //수직이동
    {
        if (direction_V == 0)
        {
            dir = Vector2.up;
            rigid.velocity = dir * speed;
        }
        else
        {
            dir = Vector2.down;
            rigid.velocity = dir * speed;
        }
    }

    void scan()
    {
        Debug.DrawRay(rigid.position, dir * 2f, new Color(0, 1, 0));
        RaycastHit2D rayHitObject = Physics2D.Raycast(rigid.position, dir, 0.5f, LayerMask.GetMask("Object"));
        RaycastHit2D rayHitLine = Physics2D.Raycast(rigid.position, dir, 0.5f, LayerMask.GetMask("Line"));
        RaycastHit2D rayHitPlayer = Physics2D.Raycast(rigid.position, dir, 2f , LayerMask.GetMask("Player"));

        //장애물과 벽에 부딪히면 방향전환
        if (rayHitObject.collider != null || rayHitLine.collider != null)
        {
            if(gameObject.layer == 10) //v
            {
                if(direction_V == 1)
                {
                    direction_V = 0;
                }
                else
                {
                    direction_V = 1;
                }
            }
            else if(gameObject.layer == 11) //h
            {
                if (direction_H == 1)
                {
                    direction_H = 0;
                }
                else
                {
                    direction_H = 1;
                }
            }
            CancelInvoke();
            Invoke("Direction", 2);
        }

        //Player발견시
        if (rayHitPlayer.collider != null)
        {
            StartCoroutine(SpeedUp());
        }



    }


}
