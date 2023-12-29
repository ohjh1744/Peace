using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;

    //서브메뉴창이나 미니맵창열릴때 대화창 안눌리도록 하기위한 변수
    public GameObject submenu;
    public GameObject Ui_minimap;


    void Awake()
    {
        
        //비밀지하테스트씬 -> 비밀기지씬넘어갈때 플레이어포지션변경  여긴없어도될듯?
        if(CheckEnter.EnterSecretbattle == 1)
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                transform.position = new Vector2(9, -3.5f);
                CheckEnter.EnterSecretbattle = 0;
            } 
        }

        //비밀기지씬 -> 메인도시넘어갈때 포지션 변경
        if(CheckEnter.EnterSecrethouse == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(-21.5f, 20.5f);
                CheckEnter.EnterSecrethouse = 0;
            }
        }
        //미로씬 -> 메인 도시씬넘어갈때 포지션변경
        if(CheckEnter.FromCitytoMiro == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(11f, 29.5f);
                CheckEnter.FromCitytoMiro = 0;
            }
        }

        //음지 -> 미로씬 넘어갈때 포지션변경
        if (CheckEnter.FromMirotoGaia == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                transform.position = new Vector2(13f, 3f);
                CheckEnter.FromMirotoGaia = 0;
            }
        }

        //음지잡몹전투씬 -> 음지넘어갈때
        if (CheckEnter.FromGaiatofight == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                transform.position = new Vector2(17f, 12f);
                CheckEnter.FromGaiatofight = 0;
            }
        }

        //1스테이지보스 -> 아레아
        if (CheckEnter.FromAreatoBoss == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(9f, 19f);
                CheckEnter.FromAreatoBoss = 0;
            }
        }

        //2스테이지불 -> 아레아
        if (CheckEnter.FromAreatoFire == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = new Vector2(16f, 19f);
                CheckEnter.FromAreatoFire = 0;
            }
        }

        if (CheckEnter.FromFiretoDesert == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                transform.position = new Vector2(7f, 0);
                CheckEnter.FromFiretoDesert = 0;
            }
        }

        if (CheckEnter.FromDesrttoTop == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                transform.position = new Vector2(5f, 13f);
                CheckEnter.FromDesrttoTop = 0;
            }
        }

        if (CheckEnter.FromToptoKilled == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                transform.position = new Vector2(-1.5f, 33f);
                CheckEnter.FromToptoKilled = 0;
            }
        }





        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       

    }

 
    void Update()
    {
        Debug.Log(NpcQuest.questnum);
        Debug.Log(NpcQuest.Npc);
        //move value
        //조사중에는 못움직이게
        h = manager.isTalking ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isTalking ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = manager.isTalking ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isTalking ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isTalking ? false : Input.GetButtonUp("Horizontal");
        bool vUp= manager.isTalking ? false : Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        // ray direction -> 나 스스로 버그 수정.
        if (hDown)
        {
            isHorizonMove = true;
            if(h == 1)
            {
                dirVec = Vector3.right;
            }
            else if(h == -1)
            {
                dirVec = Vector3.left;
            }
 
        }
        else if (vDown)
        {
            isHorizonMove = false;
            if (v == 1)
            {
                dirVec = Vector3.up;
            }
            else if (v == -1)
            {
                dirVec = Vector3.down;
            }
        }
        else if(hUp || vUp) // v- h - v or h - v - h 로 이동할때 멈추는 현상 ,  양옆키를 누른상태에서 한쪽키를 땔때 이동하지않고 멈추는 버그 수정코드
        {
            isHorizonMove = h != 0;
            if(!(h == 0 && v == 0))   // ray의 경우 멈출 시 위에 hup || vUp 조건때문에 꺼지므로 옆조건을 넣어줘야함. 즉, 멈출경우만 제외하면 ray는 남아있음.
            {
                dirVec = isHorizonMove ? new Vector3(h, 0, 0) : new Vector3(0, v, 0);
            }

        }

        PlayerAnimation();   
        UseItem();
        Can_talk();


    }


    void FixedUpdate()
    {
        Playermove();
        scanNpc();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 비밀기지 내부 들어가기
        if(collision.tag == "Secrethouse")
        {
            CheckEnter.EnterSecrethouse = 1;
            SceneManager.LoadScene(2);
        }

        //비밀기지 전투장면 들어가기
        else if (collision.tag == "Secretbattle")
        {
            CheckEnter.EnterSecretbattle = 1;
            SceneManager.LoadScene(3);
        }

        else if (collision.tag == "Area")
        {
            SceneManager.LoadScene(1);
        }

        else if (collision.tag == "AreatoMiro")
        {
            CheckEnter.FromCitytoMiro = 1;
            SceneManager.LoadScene(4);
        }

        else if(collision.tag == "MirotoGaia")
        {
            CheckEnter.FromMirotoGaia = 1;
            SceneManager.LoadScene(5);
        }
        else if(collision.tag == "GaiatoMiro")
        {
            SceneManager.LoadScene(4);
        }
        else if (collision.tag == "Gaiatofight")
        {
            CheckEnter.FromGaiatofight = 1;
            SceneManager.LoadScene(6);
        }
        else if (collision.tag == "AreatoBoss")
        {
            CheckEnter.FromAreatoBoss = 1;
            SceneManager.LoadScene(7);
        }
        else if (collision.tag ==  "AreatoFire")
        {
            CheckEnter.FromAreatoFire = 1;
            SceneManager.LoadScene(8);
        }
        else if (collision.tag == "FiretoArea")
        {
            SceneManager.LoadScene(1);
        }
        else if(collision.tag == "FiretoDesert")
        {
            CheckEnter.FromFiretoDesert = 1;
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "DeserttoFire")
        {
            SceneManager.LoadScene(8);
        }
        else if (collision.tag == "DeserttoTop")
        {
            CheckEnter.FromDesrttoTop = 1;
            SceneManager.LoadScene(10);
        }
        else if (collision.tag == "ToptoDesert")
        {
            SceneManager.LoadScene(9);
        }
        else if (collision.tag == "ToptoKilled")
        {
            CheckEnter.FromToptoKilled = 1;
            SceneManager.LoadScene(11);
        }
        else if (collision.tag == "KilledtoTop")
        {
            SceneManager.LoadScene(10);
        }


    }

    void Can_talk()
    {

        // 서브메뉴랑 맵버튼 켜져잇을때도 대화못하도록막기
        submenu = GameObject.Find("UI").transform.Find("MenuSet").gameObject;
        Ui_minimap = GameObject.Find("UI").transform.Find("Map_button").transform.Find("MiniMapUi").gameObject;

        if (submenu.activeSelf == false && Ui_minimap.activeSelf == false)
        {
            talk();
            monologue();
        }
    }


    void PlayerAnimation()
    {
        //animation
        //transition을 연속적으로 태우면 애니메이션동작이 안댐. //골메피셜? 근데 나는됌..
        //isChange로 walk 두가지이상상태 겹치지않고 작동가능.
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
    }

    void Playermove()
    {
        //플래그 변수 하나로 수평, 수직이동 결정
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }

    void UseItem()
    {
        if(NpcQuest.get_badge == 1)
        {
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.use_badge = 1;
                NpcQuest.get_badge = 0;
            }
        }
        else if(NpcQuest.get_key == 1 && NpcQuest.Npc.name == "Npc9")
        {
            
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.questnum = 11;
                NpcQuest.use_key = 1;   //이건 필요 없는듯?
                NpcQuest.get_key = 0;
                
            }
        }
        else if(NpcQuest.get_basket == 1 && NpcQuest.Npc.name == "Npc12")
        {
            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.questnum = 16; // 물뜨면 물바구니로 바꿔주기위해서.
                NpcQuest.use_basket = 1;  //이부분도 딱히 필요 없는듯?
                NpcQuest.get_basket = 0;
                NpcQuest.get_water =1;
               
            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.Npc.name == "Burning1")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 17;
                NpcQuest.use_water = 1;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 1&& NpcQuest.Npc.name == "Burning2")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 18;
                NpcQuest.use_water = 2;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 2 && NpcQuest.Npc.name == "Burning3")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 19;
                NpcQuest.use_water = 3;

            }
        }

        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 3 && NpcQuest.Npc.name == "Burning4")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 20;
                NpcQuest.use_water = 4;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 4 && NpcQuest.Npc.name == "Burning5")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 21;
                NpcQuest.use_water = 5;

            }
        }
        else if (NpcQuest.get_water == 1 && NpcQuest.use_water == 5 && NpcQuest.Npc.name == "Burning6")
        {

            if (Input.GetButtonDown("UseItem"))
            {
                NpcQuest.Npc.SetActive(false);
                NpcQuest.questnum = 22;
                NpcQuest.use_water = 6;
                NpcQuest.get_water = 0;

            }
        }

    }

    void monologue()  //독백부분 독백은 questnum처리를 talk가 아닌 여기서 따로 처리.
    {
            
        if (manager.isTalking == true && NpcQuest.Npc == null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                manager.talk_num++;
                manager.Monologue_Action();
            }
        }
        else
        {   // 음지로 들어가고 나서 바로 npc없이 대화창을 뛰우기위한부분
            if (SceneManager.GetActiveScene().buildIndex == 5 && NpcQuest.questnum == 6)
            {
                NpcQuest.questnum = 7;
                manager.isTalking = true;
                manager.Monologue_Action();
            }

            if (NpcQuest.Npc == null &&  NpcQuest.questnum == 26)
            {
                NpcQuest.questnum = 27;
                manager.isTalking = true;
                manager.Monologue_Action();
            }
        }
    }



    void talk()
    {            
        if (Input.GetButtonDown("Jump") && NpcQuest.Npc != null) //npc와의 대화
        {
            if(manager.isTalking == true)
            {
                manager.talk_num++;
                manager.Action(NpcQuest.Npc);
            }
            else
            {
                //npc1이랑 대화햇을때 questnum 1, 2랑대화할때 questnum2
                if(NpcQuest.Npc.name == "Npc1" && NpcQuest.questnum == 0)
                {
                    NpcQuest.questnum = 1;
                }
                else if(NpcQuest.Npc.name == "Npc2" && NpcQuest.questnum == 1)
                {
                    NpcQuest.questnum = 2;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 2)
                {
                    NpcQuest.questnum = 3;
                }
                else if (NpcQuest.Npc.name == "Npc4" && NpcQuest.questnum == 3)
                {
                    NpcQuest.questnum = 4;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 4.5f) // 비밀기지테스트에서 보스를 죽이면 4.5로 변환해놓음.
                {
                    NpcQuest.questnum = 5;
                }
                else if (NpcQuest.Npc.name == "Npc5" && NpcQuest.questnum == 5) 
                {
                    NpcQuest.questnum = 6;
                }
     
                else if (NpcQuest.Npc.name == "Npc6" && NpcQuest.questnum == 7)
                {
                    NpcQuest.questnum = 8;
                }
                else if (NpcQuest.Npc.name == "Npc7" && NpcQuest.questnum == 8)
                {
                    NpcQuest.questnum = 9;
                }
                else if (NpcQuest.Npc.name == "Npc8" && NpcQuest.questnum == 9)
                {
                    NpcQuest.questnum = 10;
                }
                else if (NpcQuest.Npc.name == "Npc7" && NpcQuest.questnum == 11) // 잡몹잡고나서 10.5f, 키미션성공하면 11f로변환. 키미션은 위에 use item에서 변환.
                {
                    NpcQuest.questnum = 12;
                }
                else if (NpcQuest.Npc.name == "Npc10" && NpcQuest.questnum == 12) 
                {
                    NpcQuest.questnum = 13;
                }
                else if (NpcQuest.Npc.name == "Npc3" && NpcQuest.questnum == 13.5f) //보스잡고나면 13.5로 변경.
                {
                    NpcQuest.questnum = 14;
                }
                else if (NpcQuest.Npc.name == "Npc11" && NpcQuest.questnum == 14)
                {
                    NpcQuest.questnum = 15;
                }
                else if (NpcQuest.Npc.name == "Npc11" && NpcQuest.questnum == 22)
                {
                    NpcQuest.questnum = 23;
                }
                else if (NpcQuest.Npc.name == "Npc13" && NpcQuest.questnum == 23)
                {
                    NpcQuest.questnum = 24;
                }
                else if (NpcQuest.Npc.name == "Npc14" && NpcQuest.questnum == 24)
                {
                    NpcQuest.questnum = 25;
                }
                else if (NpcQuest.Npc.name == "Npc15" && NpcQuest.questnum == 25)
                {
                    NpcQuest.questnum = 26;
                }
                else if (NpcQuest.Npc.name == "Npc16" && NpcQuest.questnum == 27)
                {
                    NpcQuest.questnum = 28;
                }


                manager.Action(NpcQuest.Npc);
            }
        }

    }

    void scanNpc()
    {
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("NPC"));
        if (rayHit.collider != null)
        {
            NpcQuest.Npc = rayHit.collider.gameObject;
        }
        else
        {
            NpcQuest.Npc = null;
        }
    }

 
}
