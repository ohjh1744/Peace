using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BulletInf
{
    public GameObject obj;
    public float Speed;
    public float MaxDelay;
} //총알 및 속도, 딜레이에 관한 변수 구조체 선언

[RequireComponent(typeof(Status))] //데미지 산정을 위해 스테이터스 컴포넌트 필요
public class Battle_Shooter : MonoBehaviour
{

    //서브메뉴창이나 미니맵창열릴때 fire함수 안먹게하도록
    public GameObject submenu;
    public GameObject Ui_minimap;

    [HideInInspector]
    public List<float> last_shoot_time;
    [HideInInspector]
    public delegate void Action(int value);
    [HideInInspector]
    public static event Action OnFireExcuted; // fire함수 실행을 이벤트로 감지하게 만들어줄 필요있음 --> EnhancedAttack에서 감지할 예정

    List<UICoolTimeControl> SkillUI;
    SkillUIProvider SkillUIProvider;
    PlayerMovement playerMovement;
    Status status;

    [Header("Skill Key Mapping")]
    public List<string> keys;

    [Header("Bullet Setting")]
    public List<BulletInf> bullets;

    [Header("Scatter Num")]
    public float angleOffsetNum;


    void OnEnable()
    {
        last_shoot_time = new List<float>();
        for (int i = 0; i < bullets.Count; i++)
        {
            last_shoot_time.Add(Time.time - 999f);
        }
        if (TryGetComponent(out SkillUIProvider))
        {
            SkillUI = SkillUIProvider.CoolTimeBulletList;
        }
        TryGetComponent(out playerMovement); //적의 경우에는 다른 AI컴포넌트로 대체 될 예정
        status = GetComponent<Status>();
    }

    private void Update()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (!string.IsNullOrEmpty(keys[i]) && Input.GetButtonDown(keys[i]))
            {
                Can_fire(i, playerMovement.dirVec);
            } //주인공의 경우 키입력으로 총알 발사 ==> 적의 Shooter인 경우에는 현재 코드 재사용 가능
        }
    }

    public bool Fire(int bulletIndex, Vector2 dir)
    {
        if (bullets.Count <= bulletIndex) { return false; }
        if (last_shoot_time.Count <= bulletIndex) { return false; }
        if (Time.time - last_shoot_time[bulletIndex] > bullets[bulletIndex].MaxDelay) //각 총알 발사 쿨타임이 적당하게 돈 경우에만
        {
            if (SkillUI != null) StartCoroutine(SkillUI[bulletIndex].CoolTime(bullets[bulletIndex].MaxDelay));

            float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Quaternion rot = Quaternion.Euler(0f, 0f, newAngle);
            GameObject bullet = Instantiate(bullets[bulletIndex].obj, transform.position, rot * bullets[bulletIndex].obj.transform.rotation);
            bullet.GetComponent<Bullet>().Damage += status.atk; //공격력에 의한 데미지 변동을 위해, 추가 데미지 설정 ==> 디폴트 데미지 + 추가 데미지. 필요없으면 삭제해도 괜찮습니다.
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(dir * bullets[bulletIndex].Speed, ForceMode2D.Impulse);
            last_shoot_time[bulletIndex] = Time.time; //가장 최근 발사 시간 기록
            OnFireExcuted?.Invoke(bulletIndex);
            return true;
        }
        return false; //시전 성공 유무를 반환
    }

    public bool Scatter(int bulletIndex, Vector2 dir)
    {
        if (bullets.Count <= bulletIndex) { return false; }
        if (Time.time - last_shoot_time[bulletIndex] > bullets[bulletIndex].MaxDelay) //총알 발사 쿨타임이 적당하게 돈 경우에만
        {
            float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            for (float i = angleOffsetNum * -1; i < angleOffsetNum; i++)
            {
                float angleOffset = i * 15;
                Quaternion rot = Quaternion.Euler(0f, 0f, newAngle + angleOffset);
                Vector2 rotatedDir = rot * Vector2.right;

                GameObject bullet = Instantiate(bullets[bulletIndex].obj, transform.position, rot * bullets[bulletIndex].obj.transform.rotation);

                //회전된 방향으로 물리 가함
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(rotatedDir * bullets[bulletIndex].Speed * 1.5f, ForceMode2D.Impulse);
            }

            last_shoot_time[bulletIndex] = Time.time; //가장 최근 발사 시간 기록
            return true;
        }
        return false; //시전 성공 유무를 반환
    }

    void Can_fire(int bulletIndex, Vector2 dir)
    {

        // 서브메뉴랑 맵버튼 켜져잇을때도 대화못하도록막기
        submenu = GameObject.Find("UI").transform.Find("MenuSet").gameObject;
        Ui_minimap = GameObject.Find("UI").transform.Find("Map_button").transform.Find("MiniMapUi").gameObject;

        if (submenu.activeSelf == false && Ui_minimap.activeSelf == false)
        {
            Fire(bulletIndex, dir);
        }
    }

}