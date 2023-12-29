using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Battle_Shooter))] //원거리 공격시에 필수
public class BossAi_stage1 : MonoBehaviour
{
    public GameObject DummyCarPrefab;
    public GameObject DummyCarPrefab2;
    public GameObject TrashMobPrefab;
    public GameObject TrashMob;

    private EnemyMovement movement;
    private UnityEngine.AI.NavMeshAgent BossAgent;
    private Battle_Shooter shooter;
    private float last_attack_time;
    private float attack_weight= 10; //확률 동적 가중치
    private LineRenderer lr;
    private ParticleSystem ps;
    private Vector3 BossPos;
    private Vector3 TargetPos;
    


    public Animator anim;

    [Header("VFX")]
    public List<Material> particle_mat;
    public GameObject SweepingObj;
    public GameObject TeleportAttackObj;

    void Start()
    {
        if(SweepingObj == null)
            SweepingObj = transform.Find("SweepingAttack").gameObject;
        if(TeleportAttackObj == null)
            TeleportAttackObj = transform.Find("TeleportAttack").gameObject;

        //보스로직
        movement = GetComponent<EnemyMovement>();
        BossAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        BossAgent.updateUpAxis = false;
        BossAgent.updateRotation = false;
        shooter = GetComponent<Battle_Shooter>();
        last_attack_time = Time.time;

        //라인렌더러, 파티클 시스템 로드
        lr = GetComponent<LineRenderer>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        InvokeRepeating("PatternGenerator", 0f, 1f); //1초 마다 패턴생성 함수로 스킬 시전

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PatternGenerator()
    {
        if (movement.isAttack) return; // 중복 스킬 사용 방지
        if (Time.time - last_attack_time > 5.0f) // 5초 이상 공격을 못한 경우에 원거리 공격 시전
        {
            if (Random.Range(0, 100) < 50)
            {
                StartCoroutine(Burst5());
            }
            else
            {
                StartCoroutine(ScatterShot());
            }
        }
        else if (Vector2.Distance(movement.target.transform.position, transform.position) > 10.0f) // 거리 10.0f 이상이면 텔포
        {
            StartCoroutine(TeleportAttack());
        }
        else if (Random.Range(0, 100) < 33) // 33%확률 패턴 진입
        {
            int RandomNum = Random.Range(0, 100);
            if (RandomNum <= 40)
            {
                StartCoroutine(Rush());
            }
            else if (RandomNum > 40 && RandomNum <= (70+attack_weight))
            {
                StartCoroutine(CarAttack());
                attack_weight = -attack_weight; //사용했던 스킬 재사용 확률 대폭 낮춤
            }
            else
            {
                StartCoroutine(SummonTrashMob());
                attack_weight = -attack_weight; //사용했던 스킬 재사용 확률 대폭 낮춤
            }
        }
        else if (Vector2.Distance(movement.target.transform.position, transform.position) < 2.0f) //거리 2.0f 이내일때 휩쓸기
        {
            StartCoroutine(Sweeping());
        }
    }


    private IEnumerator SummonTrashMob() //잡몹소환 패턴
    {
        movement.isAttack = true;
        BossAudioControl.instance.SoundGenerator(4);
        if (anim != null)
        {   
            anim.SetTrigger("SummonTrashMob");
            print("SummonTrashMob");
        }
        //보스위 현재 위치 초기화
        BossPos = transform.position;
        Vector2 spawnPosition1 = new Vector2(BossPos.x + 1.5f, BossPos.y);
        Vector2 spawnPosition2 = new Vector2(BossPos.x - 1.5f, BossPos.y);
        //보스 위치 양옆에 잡몹 각각 한마리씩 인스턴스화 하여 소환
        TrashMob = Instantiate(TrashMobPrefab, spawnPosition1, Quaternion.identity);
        TrashMob = Instantiate(TrashMobPrefab, spawnPosition2, Quaternion.identity);

        yield return new WaitForSeconds(1.0f);
        last_attack_time = Time.time;
        movement.isAttack = false;
        yield return null;

    }
    private IEnumerator TeleportAttack() //점프공격 패턴
    {
        movement.isAttack = true;
        //플레이어 위치 추적
        TargetPos = movement.target.transform.position;

        //점차 사라지면서 콜라이더 비활성화
        var sprite = GetComponent<SpriteRenderer>();
        var colider = GetComponent<Collider2D>();
        colider.enabled = false;
        for (float f = 1; f >= 0; f-= 0.01f)
        {
            sprite.color = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(0.001f);
        }

        //순간이동 후 점차 나타나면서 추후 콜라이더 활성화
        transform.position = new Vector2(TargetPos.x, TargetPos.y);
        for (float f = 0; f <= 1; f += 0.05f)
        {
            sprite.color = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(0.0005f);
        }

        var TeleportDir = movement.direction; //공격 방향

        anim.SetFloat("TeleportDirX",TeleportDir.x);
        anim.SetFloat("TeleportDirY",TeleportDir.y);

        BossAudioControl.instance.SoundGenerator(3);

        if (anim != null)
        {
            yield return new WaitForSeconds(0.3f);
            colider.enabled = true;
            anim.SetTrigger("TeleportAttack");
            yield return new WaitForSeconds(0.2f);

            //토네이도 어택방향
            float up = Vector2.Dot(TeleportDir, Vector2.up);
            float down = Vector2.Dot(TeleportDir, Vector2.down);
            float left = Vector2.Dot(TeleportDir, Vector2.left);
            float right = Vector2.Dot(TeleportDir, Vector2.right);
            float maxDirection = Mathf.Max(up, down, left, right);

            float scale = 1.5f;
            if (maxDirection == down)
                TeleportAttackObj.transform.position = new Vector3(0f, -scale, 0f) + transform.position;
            else if (maxDirection == up)
                TeleportAttackObj.transform.position = new Vector3(0f, scale, 0f) + transform.position;
            else if (maxDirection == left)
                TeleportAttackObj.transform.position = new Vector3(-scale, 0f, 0f) + transform.position;
            else
                TeleportAttackObj.transform.position = new Vector3(scale, 0f, 0f) + transform.position;

            TeleportAttackObj.SetActive(true);
            print("TeleportAttack");
            BossAudioControl.instance.SoundGenerator(2);
            yield return new WaitForSeconds(0.5f);
        }
        last_attack_time = Time.time;

        TeleportAttackObj.SetActive(false);
        movement.isAttack = false;
        yield return null;
    }

    private IEnumerator Sweeping() //전방 부채꼴공격
    {
        movement.isAttack = true;
        SweepingObj.transform.SetParent(null);

        anim.SetFloat("SweepingDirX",movement.face_direction.x);
        anim.SetFloat("SweepingDirY",movement.face_direction.y);

        //공격범위 보여주기
        float up = Vector2.Dot(movement.face_direction, Vector2.up);
        float down = Vector2.Dot(movement.face_direction, Vector2.down);
        float left = Vector2.Dot(movement.face_direction, Vector2.left);
        float right = Vector2.Dot(movement.face_direction, Vector2.right);
        float maxDirection = Mathf.Max(up, down, left, right);

        SpriteRenderer spriteRenderer = null;
        if (SweepingObj.TryGetComponent<SpriteRenderer>(out spriteRenderer)) // 바라보는 방향에 따라 범위 오프셋 변경
        {
            float scale = 3f;
            if (maxDirection == down)
            {
                SweepingObj.transform.position = new Vector3(0f, -scale, 0f)+transform.position;
            }
            else if (maxDirection == up)
            {
                SweepingObj.transform.position = new Vector3(0f, scale, 0f) + transform.position;
            }

            else if (maxDirection == left)
            {
                SweepingObj.transform.position = new Vector3(-scale, 0f, 0f) + transform.position;
            }
            else
            {
                SweepingObj.transform.position = new Vector3(scale, 0f, 0f) + transform.position;
            }
        }

        // 스킬 범위 나타나기
        for (float f = 0.01f; f <= 1f; f+= 0.01f)
        {
            spriteRenderer.color = new Color(1,1,1,f);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.1f);
        // 스킬 범위 사라지기
        for (float f = 1f; f >= 0f; f -= 0.2f)
        {
            spriteRenderer.color = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(0.01f);
        }

        if (anim != null)
        {
            //애니메이션 시전과 콜라이더 활성화
            SweepingObj.GetComponent<Collider2D>().enabled = true;
            anim.SetTrigger("Sweeping");
            print("Sweeping");
            BossAudioControl.instance.SoundGenerator(0);
            yield return new WaitForSeconds(1.0f);
        }

        //피봇과 오프셋 정리
        SweepingObj.GetComponent<Collider2D>().enabled = false;
        SweepingObj.transform.SetParent(transform);
        SweepingObj.transform.position = transform.position;

        last_attack_time = Time.time;
        movement.isAttack = false;
        yield return null;
    }

    private IEnumerator Rush() // 적까지의 경로에 장애물이 없을시에 돌진하는 스킬, 경로를 미리 알려주고 돌진
    {
        print("Rush");
        movement.isAttack = true;
        RaycastHit2D hit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0f, new Vector2(movement.direction.x, movement.direction.y), 100f, (-1) - (1 << LayerMask.NameToLayer("Ignore Raycast")));
        Vector3 targetPos = movement.direction;
        print(hit.collider.name);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            if (lr != null)
            {
                lr.material = particle_mat[4]; // 돌진방향 알려주기
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position+(targetPos * 10f));
            }
            float up = Vector2.Dot(targetPos, Vector2.up);
            float down = Vector2.Dot(targetPos, Vector2.down);
            float left = Vector2.Dot(targetPos, Vector2.left);
            float right = Vector2.Dot(targetPos, Vector2.right);
            float maxDirection = Mathf.Max(up, down, left, right);
            var render = gameObject.GetComponent<ParticleSystemRenderer>();
            render.minParticleSize = 0.1f;
            render.maxParticleSize = 0.5f;
            if (render != null)
            {
                if (maxDirection == down)
                    render.material = particle_mat[0];
                else if (maxDirection == up)
                    render.material = particle_mat[1];
                else if (maxDirection == left)
                    render.material = particle_mat[2];
                else render.material = particle_mat[3]; // 바라보는 방향에 따라 잔상 메터리얼 달라짐
            }
            yield return new WaitForSeconds(1f);
            if (ps != null && lr != null)
            {
                ps.Play();
                lr.enabled = false;

            }
            float DashPower = 10f;
            var rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(targetPos.x * DashPower, targetPos.y * DashPower);
            yield return new WaitForSeconds(1f);
            BossAudioControl.instance.SoundGenerator(1);
            rb.velocity = BossAgent.velocity;
            if (ps != null)
                ps.Stop();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        }
        movement.isAttack = false;
        yield return null;
    }
    private IEnumerator Slash() // 일정 거리까지 가까워질때 칼을 휘두르는 근접 공격 스킬, 시전 딜레이는 잠깐 있음
    {
        movement.isAttack = true;
        BossAudioControl.instance.SoundGenerator(0);
        if (anim != null)
        {
            anim.SetTrigger("Attack"); 
            yield return new WaitForSeconds(0.5f);
            print("Slash2");
        }
        last_attack_time = Time.time;
        movement.isAttack = false;
        yield return null;
    }


    private IEnumerator CarAttack()
    {
        movement.isAttack = true;

        if (anim != null)
        {
            BossAudioControl.instance.SoundGenerator(4);
            anim.SetTrigger("SummonTrashMob");
            yield return new WaitForSeconds(0.7f);
            print("CarAttack");
        }
        for (int i = -2; i <= 3; i++)
        {
            //인스턴스 생성과 위치 설정
            if (Random.Range(0, 100) < 50)
            {
                Vector2 setPosition = new Vector2(15.0f, (i * 2.5f));
                var DummyCar = Instantiate(DummyCarPrefab, setPosition, Quaternion.identity);

                //각 시전마다 랜덤 딜레이
                yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));

                //Line Renderer로 진행 경로 표시
                if (lr != null)
                {
                    lr.material = particle_mat[4]; // 돌진방향 알려주기
                    lr.enabled = true;
                    lr.SetPosition(0, setPosition);
                    lr.SetPosition(1, new Vector2(-15.0f, (i * 2.5f)));
                }

                //물리력 추가
                Rigidbody2D CarRigidBody = DummyCar.GetComponent<Rigidbody2D>();
                CarRigidBody.AddForce(new Vector2(-20.0f, 0), ForceMode2D.Impulse);
            }
            else
            {
                Vector2 setPosition = new Vector2(-15.0f, (i * 2.5f));
                var DummyCar = Instantiate(DummyCarPrefab2, setPosition, Quaternion.identity);

                //각 시전마다 랜덤 딜레이
                yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));

                //Line Renderer로 진행 경로 표시
                if (lr != null)
                {
                    lr.material = particle_mat[4]; // 돌진방향 알려주기
                    lr.enabled = true;
                    lr.SetPosition(0, setPosition);
                    lr.SetPosition(1, new Vector2(15.0f, (i * 2.5f)));
                }

                //물리력 추가
                Rigidbody2D CarRigidBody = DummyCar.GetComponent<Rigidbody2D>();
                CarRigidBody.AddForce(new Vector2(20.0f, 0), ForceMode2D.Impulse);
            }
        }
        if (lr != null){
            lr.enabled = false;
        }
        last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        movement.isAttack = false;
        yield return null;
    }
    private IEnumerator Burst5() // 원거리 화살을 5연발하는 스킬, 기를 모으는 액션을 통한 시전 딜레이 존재
    {
        movement.isAttack = true;
        print("Burst5");
        for (int i = 0; i < 5; i++)
        {
            var dir = (movement.target.transform.position - transform.position).normalized; //매 발사시마다 타겟 위치 갱신
            if (shooter.Fire(0, dir) == false) { break; }
            yield return new WaitForSeconds(0.3f);
            last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        }
        movement.isAttack = false;
        yield return null;
    }
    private IEnumerator ScatterShot()
    {
        movement.isAttack = true;
        print("ScatterShot");
        var dir = (movement.target.transform.position - transform.position).normalized; // 타겟 위치
        shooter.Scatter(0, dir);
        yield return new WaitForSeconds(0.3f);
        last_attack_time = Time.time; //공격이 시전 성공시에 시간 초기화
        movement.isAttack = false;
        yield return null;
    }
}
