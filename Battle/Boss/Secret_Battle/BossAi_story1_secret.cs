using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Battle_Shooter))] //원거리 공격시에 필수
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyMovement))]
public class BossAi_story1_secret : MonoBehaviour
{
    private float last_attack_time;
    private EnemyMovement movement;
    private Battle_Shooter shooter;
    private LineRenderer lr;
    private ParticleSystem ps;
    private NavMeshAgent agent;


    AudioSource audiosource;

    [Header("Attack Animation")]
    public Animator anim;

    [Header("VFX")]
    public List<Material> particle_mat;


    [Header("Sounds")]
    public List<AudioClip> audioclip = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        last_attack_time = Time.time;
        agent = GetComponent<NavMeshAgent>();
        shooter = GetComponent<Battle_Shooter>();
        movement = GetComponent<EnemyMovement>();
        audiosource = GetComponent<AudioSource>();


        // 밑에있는 코드는 훈련 교관의 경우의 코드
        lr = GetComponent<LineRenderer>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        InvokeRepeating("Training_1", 0f, 1f); //1초마다 훈련 교관 AI 생각
    }

    //훈련 교관 전용 ai
    void Training_1()
    {
        if (movement.isAttack) return; // 중복 스킬 사용 방지
        if (Time.time - last_attack_time > 5f) // 5초 이상 공격을 못한 경우에 원거리 공격 시전
        {
            StartCoroutine(Burst3());
        }
        else if(Random.Range(0,100) < 40) // 40%확률로 Rush시전
        {
            StartCoroutine(Rush());
        } else if(Vector2.Distance(movement.target.transform.position, transform.position) < 2f)
        {
            StartCoroutine(Slash());
        } 
    }


    //훈련 교관 전용 스킬
    private IEnumerator Rush() // 적까지의 경로에 장애물이 없을시에 돌진하는 스킬, 경로를 미리 알려주고 돌진
    {
        movement.isAttack = true;
        RaycastHit2D hit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0f ,new Vector2(movement.direction.x, movement.direction.y), 100f, (-1) - (1 << LayerMask.NameToLayer("Ignore Raycast")));
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            if(lr !=  null) {
                lr.material = particle_mat[4];
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position + (new Vector3(hit.point.x, hit.point.y, 0) - transform.position).normalized * 3f);
            }
            float up = Vector2.Dot(movement.face_direction, Vector2.up);
            float down = Vector2.Dot(movement.face_direction, Vector2.down);
            float left = Vector2.Dot(movement.face_direction, Vector2.left);
            float right = Vector2.Dot(movement.face_direction, Vector2.right);
            float maxDirection = Mathf.Max(up, down, left, right);
            var render = gameObject.GetComponent<ParticleSystemRenderer>();
            if(render != null) {
                if (maxDirection == down)
                    render.material = particle_mat[0];
                else if (maxDirection == up)
                    render.material = particle_mat[1];
                else if (maxDirection == left)
                    render.material = particle_mat[2];
                else render.material = particle_mat[3]; // 바라보는 방향에 따라 잔상 메터리얼 달라짐
            }
            yield return new WaitForSeconds(1f);
            if(ps!=null && lr!=null)
            {
                ps.Play();
                lr.enabled = false;
            }
            float DashPower = 10f;
            var rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(movement.direction.x * DashPower, movement.direction.y * DashPower);

            audiosource.clip = audioclip[0];
            audiosource.Play();

            yield return new WaitForSeconds(1f);
            rb.velocity = agent.velocity;
            if (ps!=null) 
                ps.Stop();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        }
        movement.isAttack = false;
        yield return null;
    }
    private IEnumerator Slash() // 일정 거리까지 가까워질때 칼을 휘두르는 근접 공격 스킬, 시전 딜레이는 잠깐 있음
    {
        audiosource.clip = audioclip[1];
        audiosource.Play();
        movement.isAttack = true;
        if(anim != null)
        {
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            print("Slash2");
        }
        last_attack_time = Time.time;
        movement.isAttack = false;
        yield return null;
    }

    private IEnumerator Burst3() // 원거리 화살을 3연발하는 스킬, 기를 모으는 액션을 통한 시전 딜레이 존재
    {
        audiosource.clip = audioclip[2];
        movement.isAttack = true;
        print("Burst3");
        for (int i = 0; i<3; i++) {
            var dir = (movement.target.transform.position - transform.position).normalized; //매 발사시마다 타겟 위치 갱신
            if (shooter.Fire(0, dir) == false) { break; }
            audiosource.Play();
            yield return new WaitForSeconds(0.5f);
            last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        }
        movement.isAttack = false;
        yield return null;
    }
}
