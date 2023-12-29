using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    public GameObject SubMenu;
    public GameObject CharacterUi;
    public GameObject QuestSet;
    public GameObject Map_button;
    public GameObject canvasObject;
    public GameObject[] Health = new GameObject[3];
    public GameObject teleport;
    public int healthPoint;

    public GameObject gameManager;
    bool istalking;

    bool isMap; // 씬마다 Map버튼이 존재여부가 다르고 Map버튼이 없는 씬의 경우 서브메뉴창을 켜고 다시 끌때 Map버튼 또한 On되지 않게 막아두는 변수.
    void Start()
    {
        healthPoint = 3;


        // 미로의 텔레포트기 찾기
        teleport = GameObject.Find("Teleport");
        canvasObject = GameObject.Find("UI");
        gameManager = GameObject.Find("GameManager").gameObject;
       

        if (canvasObject != null)
        {
            Transform canvasTransform = canvasObject.transform;
            Transform menuSetTransform = canvasTransform.Find("MenuSet");
            Transform CharacterUiTransform = canvasTransform.Find("CharacterUi");
            Transform QuestSetTransform = canvasTransform.Find("QuestSet");
            Transform Map_buttonTransform = canvasTransform.Find("Map_button");
            Transform HealthSetTransform = CharacterUiTransform.Find("HealthSet");

            if (menuSetTransform != null && CharacterUiTransform != null)
            {
                SubMenu = menuSetTransform.gameObject;
                CharacterUi = CharacterUiTransform.gameObject;
                QuestSet = QuestSetTransform.gameObject;
                Map_button = Map_buttonTransform.gameObject;

                for (int i = 0; i < 3; i++)
                {
                    Transform healthTransform = HealthSetTransform.Find("Health " + (i + 1));
                    if (healthTransform != null)
                    {
                        Health[i] = healthTransform.gameObject;
                    }
                    else
                    {
                        Debug.LogError("Health " + (i + 1) + "을 찾을 수 없습니다.");
                    }
                }
            }
            else
            {
                Debug.LogError("오브젝트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Canvas 오브젝트를 찾을 수 없습니다.");
        }

    }

    void Update()
    {
        // 대화창 켜지는 여부에 따라 서브메뉴 켜게 못하기
        istalking = gameManager.GetComponent<GameManager>().isTalking;

        //Esc로 서브메뉴 껐다 키기
        if (istalking == false && Input.GetButtonDown("Cancel"))
        {
            SubMenuControl();
        }
    }

    public void GetHurt()
    {
        //포인트 깎고 배열에 담긴 체력 오브젝트 비활성화
        //체력이 0이 되면 위치 초기화 후 포인트 다시 채움 + 활성화
        healthPoint--;
        if (healthPoint < 3)
        {
            Health[healthPoint].SetActive(false);
        }
        if (healthPoint == 0)
        {
            // 위치 초기화 로직
            teleport.GetComponent<Teleport>().initPos();
            healthPoint = 3;
            for (int i = 0; i < 3; i++)
            {
                Health[i].SetActive(true);
            }
        }
    }

    //서브메뉴 설정
    public void SubMenuControl()
    {
        if (!SubMenu.activeSelf)
        {
            CharacterUi.SetActive(false);
            QuestSet.SetActive(false);
            SubMenu.SetActive(true);
            if (Map_button.activeSelf == true)
            {
                Map_button.SetActive(false);
                isMap = true;
            }
            Time.timeScale = 0;
        }
        else
        {
            CharacterUi.SetActive(true);
            QuestSet.SetActive(true);
            SubMenu.SetActive(false);
            if(isMap == true)
            {
                Map_button.SetActive(true);
            }
            Time.timeScale = 1;
        }
    }
}