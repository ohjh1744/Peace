using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Minimap : MonoBehaviour
{

    public GameObject MiniMapUi;
    public GameObject gameManager;

    bool istalking;
    void Start()
    {
        Find_Minimap();
        gameManager = GameObject.Find("GameManager").gameObject;
    }


    void Update()
    {
        istalking = gameManager.GetComponent<GameManager>().isTalking;
        if (Input.GetButtonDown("Minimap"))
        {
            OnOff_Minimap();
        }
        
    }

    public void Find_Minimap()
    {
        try
        {
            MiniMapUi = GameObject.Find("UI").transform.Find("Map_button").gameObject.transform.Find("MiniMapUi").gameObject;
            Debug.Log(MiniMapUi + "찾음!");
        }
        catch
        {
            Debug.Log(MiniMapUi + "미니맵못찾음!");

        }
    }

    public void OnOff_Minimap()
    {
        if(istalking == false)
        {
            if (MiniMapUi.activeSelf == true)
            {
                MiniMapUi.SetActive(false);
            }
            else
            {
                MiniMapUi.SetActive(true);
            }
        }
    }

  
}
