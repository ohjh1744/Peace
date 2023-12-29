using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    public void Spawn()
    {
        GameObject enemy = Scene1_mine_fight_GameManager.instance.pool.Get(Random.Range(0,Scene1_mine_fight_GameManager.instance.pool.prefabs.Length));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

}
