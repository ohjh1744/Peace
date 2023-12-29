using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    public GameObject player;
    private Vector3 iniPos;

    void Start()
    {
        //초기 위치 설정
        player = GameObject.Find("Player");
        iniPos = player.transform.position;
    }
    public void initPos()
    {
        player.transform.position = iniPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //씬변경
            SceneManager.LoadScene("Title");
        }
    }
}
