
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Status : MonoBehaviour
{
    private float time;

    [Header("General Setting")]
    [Tooltip("설정한 태그는 적의 총알과 같은 피격판정을 적용할 오브젝트의 태그\n 또한, 해당 태그의 오브젝트에 Bullet컴포넌트가 있어야 작동")]
    public List<string> HitTag;

    [Header("Stat")]
    public GameObject healthUI;
    public float hp = 100;
    public float curHp = 100; 
    [Space(10f)] // 임시 비활성화 UI에 맞춰 디자인
    public float mp = 5; //mp관련해서 필요없으면, 삭제해도 무방
    public float curMp = 0;
    [Space(10f)]
    public float atk = 1f;
    [Space (10f)]
    public float def = 0; //방어력만큼의 데미지 경감, 필요없으면 삭제해도 무방

    [Space(10f)]
    public bool Imunity = false; //데미지 면역을 위한 옵션

    public bool player_win;
    public bool player_lose;

    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < HitTag.Count; i++)
        {
            if (collision.gameObject.tag == HitTag[i] && Time.time - time > 1f) //중복 충돌 방지
            {
                if (!Imunity)
                {
                    Hit(collision.gameObject.GetComponent<Status>().atk);
                }
                time = Time.time;
            }
        }
    }// 오브젝트 충돌과 같이 Physics Collision일때 필요, 대상 스테이터스의 공격력만큼으로 적용

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i<HitTag.Count;i++)
        {
            if (collision.gameObject.tag == HitTag[i]) 
            {
                Bullet emp;
                if(collision.TryGetComponent<Bullet>(out emp))
                {
                    if (!Imunity)
                    {
                        Hit(collision.GetComponent<Bullet>().Damage);
                    }
                    collision.GetComponent<Bullet>().DestroyBullet();
                }
                else //적이 들고 있는 근접 무기(trigger된 무기)에 의해 피격일때
                {
                    if (!Imunity && Time.time - time > 1f) //근접 중복 피격 방지
                    {
                        Hit(collision.GetComponentInParent<Status>().atk);
                        time = Time.time;
                    }
                }
            }
        }
    } // 총알과 같이 Trigger충돌할 때 필요, Bullet의 자체 데미지만큼 적용

    private void OnEnable()
    {
        if (transform.CompareTag("Mob"))
        {
            curHp = hp;
            var ui = healthUI.GetComponent<Image>();
            ui.fillAmount = curHp / hp;
        } //몹 리젠시에 UI업데이트와 스텟 초기화를 위해 사용
        time = Time.time;
    }

    
    public void Hit(float enemyAtk)
    {
        if(healthUI !=  null)
        {
            switch (transform.tag)
            {
                case "Player":
                    healthUI.GetComponent<UiControl>().GetHurt();
                    curHp -= 1;
                    if (curHp <= 0) player_lose = true;
                    break;
                case "Boss":
                    float dmg;
                    if (def >= enemyAtk) dmg = 1f; //방어력이 데미지보다 높으면 1로 고정
                    else dmg = enemyAtk - def; //반대 경우, 방어력을 경감한만큼 데미지 계산 
                    curHp -= dmg;
                    if (curHp <= 0) { player_win = true; }
                    break;
                case "Mob":
                    if (def >= enemyAtk) dmg = 1f; //방어력이 데미지보다 높으면 1로 고정
                    else dmg = enemyAtk - def; //반대 경우, 방어력을 경감한만큼 데미지 계산 
                    curHp -= dmg;
                    if (curHp <= 0) { gameObject.SetActive(false); }
                    break;
            }
        }
    }

    private void Update()
    {
        if (healthUI != null)
        {
            switch (transform.tag)
            {
                case "Player":
                    break;
                default:
                    healthUI.GetComponent<Image>().fillAmount = curHp / hp; //지속적으로 체력 ui 업데이트
                    break;
            }
        }
    }

}
