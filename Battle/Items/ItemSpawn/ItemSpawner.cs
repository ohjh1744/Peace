using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    Transform[] rangeTransform;
    float AllAreaSize;
    float[] EachAreaSize;
    public ItemPoolManager itemPool;
    public float SpawnItemIntervalTime;

    private void Awake()
    {
        rangeTransform = GetComponentsInChildren<Transform>();
        EachAreaSize = new float[rangeTransform.Length];
        for (int i = 0; i < rangeTransform.Length; i++) 
        { 
            EachAreaSize[i] = (rangeTransform[i].lossyScale.x * rangeTransform[i].lossyScale.y * rangeTransform[i].lossyScale.z);
            AllAreaSize += EachAreaSize[i];
        }

        //林扁利 酒捞袍 积己
        InvokeRepeating("Spawn", SpawnItemIntervalTime, SpawnItemIntervalTime);
    }

    private int RandomSpot()
    {
        float rand = Random.Range(0, AllAreaSize);
        for (int i = 0;i < rangeTransform.Length;i++)
        {
            if (EachAreaSize[i] <= rand)
            {
                rand -= EachAreaSize[i];
            } else
            {
                return i;
            }
        }
        return rangeTransform.Length - 1;
    }

    public void Spawn()
    {
        int s = RandomSpot();
        Vector2 originPos = rangeTransform[s].position;
        float rangeX = rangeTransform[s].lossyScale.x;
        float rangeY = rangeTransform[s].lossyScale.y;

        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeY = Random.Range((rangeY / 2) * -1, rangeY / 2);
        Vector2 RandomPos = new Vector2(rangeX, rangeY);
        Vector2 respawnPosition = originPos + RandomPos;
        GameObject item = itemPool.Get(Random.Range(0,itemPool.Items.Count));
        if(item != null) { item.transform.position = respawnPosition; }
        else { print("SpawnObject is Null"); }
    }

}
