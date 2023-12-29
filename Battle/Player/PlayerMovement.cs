using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TrailRenderer))]
public class PlayerMovement : MonoBehaviour
{

    float h;
    float v;
    bool isDash;
    bool isDashCoolDown;
    bool isHorizionMove;
    Rigidbody2D rb;
    TrailRenderer tr;
    SkillUIProvider skillUIProvider;
    UICoolTimeControl dashUI;

    //서브메뉴창이나 미니맵창열릴때 fire함수 안먹게하도록
    public GameObject submenu;
    public GameObject Ui_minimap;

    [Header("PlayerMovement")]
    public bool LockDiagonal = true; //대각선 이동 잠금여부
    public float Speed = 5f;
    public Animator anim;

    [HideInInspector] public Vector2 dirVec;

    [Header("Dash Setting")]
    public string KeySetting;
    public float DashPower = 14f;
    public float DashTime = 0.1f;
    public float DashCoolDown = 1F;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        if (TryGetComponent<SkillUIProvider>(out skillUIProvider))
        {
            dashUI = skillUIProvider.CoolTimeDash;
        }
        dirVec = Vector2.down;
        isDash = false;
        isDashCoolDown = false;

    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        // 키 입력(수평,수직) 값

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        // 키 Down,Up 체크


        if (hDown)
            isHorizionMove = true;
        else if (vDown)
            isHorizionMove = false;
        else if (hUp || vUp)
            isHorizionMove = h != 0;
        //키 중복 입력 처리

        if (anim != null)
        {
            if (anim.GetInteger("vAxisRaw") != v)
            { //이전 v값과 다른 경우에 애니메이션 변화
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else if (anim.GetInteger("hAxisRaw") != h) //이전 값과 다른 경우에 애니메이션 변화
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else anim.SetBool("isChange", false);
        }
        // 이동 애니메이션

        if ((vDown || hUp || vUp) && v == 1)
            dirVec = Vector2.up;
        else if ((vDown || hUp || vUp) && v == -1)
            dirVec = Vector2.down;
        else if ((hDown || hUp || vUp) && h == -1)
            dirVec = Vector2.left;
        else if ((hDown || hUp || vUp) && h == 1)
            dirVec = Vector2.right;

        //바라보는 방향벡터 저장

        bool dash = Input.GetButtonDown(KeySetting);
        if (dash&&!isDashCoolDown)
        {
            Can_Dash();
        }
    }

    private void FixedUpdate()
    {
        if (isDash) return; //대쉬중에는 이동 불가, but 업데이트에서 키입력 감지는 수행해야됨

        Vector2 moveVec = new Vector2(h, v);

        float adjustSpeed = 1f; // 대각선 이동시 속도 조정
        if (h != 0 && v != 0) adjustSpeed = 0.7f;

        if (LockDiagonal)
        {
            moveVec = isHorizionMove ? new Vector2(h, 0) : new Vector2(0, v);
            adjustSpeed = 1f;
        } //대각선이동 못하는 경우에 isHorizonMove에 따라 수평 또는 수직 이동만 가능

        rb.velocity = moveVec * Speed * adjustSpeed;
    }

    private IEnumerator Dash()
    {
        isDash = true;
        isDashCoolDown = true;
        rb.velocity = new Vector2(dirVec.x * DashPower, dirVec.y * DashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        if(dashUI!= null) StartCoroutine(dashUI.CoolTime(DashCoolDown));
        isDash = false;
        tr.emitting = false;
        yield return new WaitForSeconds(DashCoolDown);
        isDashCoolDown = false;
    }

    void Can_Dash()
    {

        // 서브메뉴랑 맵버튼 켜져잇을때도 대화못하도록막기
        submenu = GameObject.Find("UI").transform.Find("MenuSet").gameObject;
        Ui_minimap = GameObject.Find("UI").transform.Find("Map_button").transform.Find("MiniMapUi").gameObject;

        if (submenu.activeSelf == false && Ui_minimap.activeSelf == false)
        {
            StartCoroutine(Dash());
        }
    }
}
