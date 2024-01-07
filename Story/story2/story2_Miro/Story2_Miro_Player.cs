using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story2_Miro_Player : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector3 Player_pos;

    void Start()
    {
        Player_pos = gameObject.transform.position;  
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            gameObject.transform.position = Player_pos;
        }
    }
}
