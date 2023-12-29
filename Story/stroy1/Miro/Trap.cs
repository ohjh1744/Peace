using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trapPrefab;
    public GameObject trap;

    void Start()
    {   
        trapPrefab = Resources.Load<GameObject>("Prefabs/Trap");
        if (trapPrefab == null)
        {
            Debug.LogError("프리팹을 찾을 수 없습니다. Resources 폴더에 'MyPrefab'이 존재해야 합니다.");
        }
        // "trap" 프리팹을 인스턴스화하여 함정 생성
        trap = Instantiate(trapPrefab, transform.position, transform.rotation);
        trap.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(DelayedAction());
        }
    }

    void GetPlayerOnTrap()
    {
        trap.SetActive(true);
        StartCoroutine(AutoOffTrap());

    }
    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(0.5f); // 0.5초 후 덫 발동
        // 딜레이 이후에 실행할 동작
        GetPlayerOnTrap();
    }
    IEnumerator AutoOffTrap()
    {
        yield return new WaitForSeconds(1f); // 1초 후 
        // 딜레이 이후에 실행할 동작
        trap.SetActive(false);
    }
}
