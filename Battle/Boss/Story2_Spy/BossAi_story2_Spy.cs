using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Battle_Shooter))] //원거리 공격시에 필수
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyMovement))]
public class BossAi_story2_Spy : MonoBehaviour
{
    private float last_attack_time;
    private EnemyMovement movement;
    private Battle_Shooter Shooter;
    private LineRenderer lr;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private Status status; //보스 체력에 따라 공격 스킬 확률 변동


    AudioSource audiosource;

    [Header("Movement&Attack Animation")]
    public Animator anim;

    [Header("Sounds")]
    public List<AudioClip> audioclip = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        last_attack_time = Time.time;
        agent = GetComponent<NavMeshAgent>();
        Shooter = GetComponent<Battle_Shooter>();
        movement = GetComponent<EnemyMovement>();
        audiosource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        status = GetComponent<Status>();

        // 밑에있는 코드는 훈련 교관의 경우의 코드
        lr = GetComponent<LineRenderer>();
        InvokeRepeating("Training_1", 0f, 1f); //1초마다 훈련 교관 AI 생각
    }

    //스파이 교관 전용 ai
    void Training_1()
    {
        if (movement.isAttack) return; // 중복 스킬 사용 방지
        if (Vector2.Distance(movement.target.transform.position, transform.position) < agent.stoppingDistance) //근접인 경우
        {
            var sel = UnityEngine.Random.Range(0, 100);
            if (status.curHp > status.hp / 2)
            {
                if (sel < 25) // 표창 던지기
                {
                    StartCoroutine(Shoot(movement.target.transform.position, 0));
                }
                else if (sel < 50) //표창 던지고 검기로 나누기
                {
                    StartCoroutine(SpyFirstSkill(movement.target.transform.position, 0, 1));
                }
                else if (sel < 75)// 은신
                {
                    StartCoroutine(Cloaking());
                }
                else if (sel < 100)// 돌진
                {
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                    StartCoroutine(Rush());
                }
                else // 근접 공격 (근접인 경우 가장 확률 높아짐)이 의미없다고 판단하여 사용 X
                {
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                    StartCoroutine(ClosedAttack());
                }
            }
        }
        else
        {
            var sel = UnityEngine.Random.Range(0, 100);
            if (status.curHp > status.hp / 2)
            {
                if (sel < 25) // 표창 던지기
                {
                    StartCoroutine(Shoot(movement.target.transform.position, 0));
                }
                else if (sel < 50) //표창 던지고 검기로 나누기
                {
                    StartCoroutine(SpyFirstSkill(movement.target.transform.position, 0, 1));
                }
                else if (sel < 65)// 은신
                {
                    StartCoroutine(Cloaking());
                }
                else if (sel < 80)// 덫 설치
                {
                    StartCoroutine(Shoot(transform.position, 2));
                }
                else // 돌진
                {
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                    StartCoroutine(Rush());
                }
            }
            else // 체력 절반 이하인 경우
            {
                if (sel < 15) // 표창 던지기
                {
                    StartCoroutine(Shoot(movement.target.transform.position, 0));
                }
                else if (sel < 50) //표창 던지고 검기로 나누기
                {
                    StartCoroutine(SpyFirstSkill(movement.target.transform.position, 0, 1));
                }
                else if (sel < 65)// 덫 설치
                {
                    StartCoroutine(Shoot(transform.position, 2));
                }
                else // 돌진
                {
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                    StartCoroutine(Rush());
                }
            }

        }
    }


    //스파이 전용 스킬

    public IEnumerator Shoot(Vector2 targetPos, int bulletidx) // 덫설치 스킬 및 원거리 공격으로 사용
    {
        movement.isAttack = true;  // 공격중임을 표시
        if (anim != null && System.Array.Exists(anim.parameters, p => p.name == "Shoot")) //공격할 애니메이션 확인
        {
            anim.SetTrigger("Shoot"); //캐릭터 애니메이션 내의 원거리 공격 Trigger이름은 일반적으로 Shoot 통일!
            yield return new WaitForSeconds(0.05f); // 애니메이션 재생동안 딜레이
        }
        else
        {
            print("No Character Animation Controller");
        }
        Shooter.Fire(bulletidx, targetPos - (Vector2)transform.position);
        last_attack_time = Time.time;
        movement.isAttack = false; //공격해제
        yield break;
    }

    // 근거리 공격
    public IEnumerator ClosedAttack() //캐릭터 애니메이션 컨트롤러내에 필요한 애니메이션 클립들이 존재한다고 가정
    {
        movement.isAttack = true; // 공격중임을 표시
        if (anim != null && System.Array.Exists(anim.parameters, p => p.name == "ClosedAttack"))
        {
            anim.SetTrigger("ClosedAttack"); //캐릭터 애니메이션 내의 근접 공격 Trigger이름은 일반적으로 ClosedAttack 통일!
            yield return new WaitForSeconds(0.5f); // 애니메이션 재생동안 딜레이
        }
        else
        {
            print("No Character Animation Controller");
        }
        movement.isAttack = false; //공격해제
        yield break;
    }


    // 표창 던지고 검기로 나누기
    public IEnumerator SpyFirstSkill(Vector2 targetPos, int bulletIdx1, int bulletIdx2)
    {

        movement.isAttack = true; // 공격중임을 표시
        if (anim != null && System.Array.Exists(anim.parameters, p => p.name == "Shoot") && System.Array.Exists(anim.parameters, p => p.name == "ClosedAttack")) //공격할 애니메이션 확인
        {
            anim.SetTrigger("Shoot"); //캐릭터 애니메이션 내의 원거리 공격 Trigger이름은 일반적으로 Shoot 통일!
            yield return new WaitForSeconds(0.5f); // 애니메이션 재생동안 딜레이
            Shooter.Fire(bulletIdx1, targetPos - (Vector2)transform.position);

            spriteRenderer.color = new Color(1, 1, 1, 1); //검기는 은신을 풀리게 함
            anim.SetTrigger("ClosedAttack"); //캐릭터 애니메이션 내의 근접 공격 Trigger이름은 일반적으로 ClosedAttack 통일!
            yield return new WaitForSeconds(1f); // 애니메이션 재생동안 딜레이

            Shooter.Fire(bulletIdx2, targetPos - (Vector2)transform.position);
        }
        else
        {
            print("No Character Animation Controller");
        }
        last_attack_time = Time.time;
        movement.isAttack = false; //공격해제

        yield break;
    }

    // 은신
    public IEnumerator Cloaking()
    {
        movement.isAttack = true; // 공격중임을 표시
        spriteRenderer.color = new Color(1, 1, 1, 1);
        if (anim != null && System.Array.Exists(anim.parameters, p => p.name == "Cloaking"))
        {
            anim.SetTrigger("Cloaking");
            yield return new WaitForSeconds(0.5f); // 애니메이션 재생동안 딜레이
        }
        else
        {
            print("No Character Animation Controller");
        }
        spriteRenderer.color = new Color(1, 1, 1, 0);

        last_attack_time = Time.time;
        movement.isAttack = false; //공격해제
        yield break;
    }

    // 돌진
    private IEnumerator Rush() // 적까지의 경로에 장애물이 없을시에 돌진하는 스킬, 경로를 미리 알려주고 돌진
    {
        movement.isAttack = true;
        Vector2 targetPos = movement.target.transform.position;
        RaycastHit2D hit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0f, new Vector2(movement.direction.x, movement.direction.y), 100f, (-1) - (1 << LayerMask.NameToLayer("Ignore Raycast")));
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            yield return new WaitForSeconds(0.5f); //대쉬전 0.5초 대기
            if (lr != null)
            {
                lr.enabled = false;
            }
            float DashPower = 10f;
            var rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(movement.direction.x * DashPower, movement.direction.y * DashPower);
            if (audioclip.Count > 0)
            {
                audiosource.clip = audioclip[0];
                audiosource.Play();
            }
            var t = (targetPos - (Vector2)transform.position).magnitude / rb.velocity.magnitude;
            if (TryGetComponent<TrailRenderer>(out TrailRenderer tr)) //대쉬 효과로 트레일렌더러 있는경우에는 효과 재생
            {
                tr.emitting = true;
            }
            yield return new WaitForSeconds(t);

            if (tr != null) { tr.emitting = false; }
            rb.velocity = agent.velocity;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        }

        last_attack_time = Time.time;
        movement.isAttack = false;
        yield break;
    }
}
