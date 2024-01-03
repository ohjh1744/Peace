
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
    [Tooltip("������ �±״� ���� �Ѿ˰� ���� �ǰ������� ������ ������Ʈ�� �±�\n ����, �ش� �±��� ������Ʈ�� Bullet������Ʈ�� �־�� �۵�")]
    public List<string> HitTag;

    [Header("Stat")]
    public GameObject healthUI;
    public float hp = 100;
    public float curHp = 100;
    [Space(10f)] // �ӽ� ��Ȱ��ȭ UI�� ���� ������
    public float mp = 5; //mp�����ؼ� �ʿ������, �����ص� ����
    public float curMp = 0;
    [Space(10f)]
    public float atk = 1f;
    [Space(10f)]
    public float def = 0; //���¸�ŭ�� ������ �氨, �ʿ������ �����ص� ����

    [Space(10f)]
    public bool Imunity = false; //������ �鿪�� ���� �ɼ�

    public bool player_win;
    public bool player_lose;

    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < HitTag.Count; i++)
        {
            if (collision.gameObject.tag == HitTag[i] && Time.time - time > 1f) //�ߺ� �浹 ����
            {
                if (!Imunity)
                {
                    Hit(collision.gameObject.GetComponent<Status>().atk);
                }
                time = Time.time;
            }
        }
    }// ������Ʈ �浹�� ���� Physics Collision�϶� �ʿ�, ��� �������ͽ��� ���ݷ¸�ŭ���� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < HitTag.Count; i++)
        {
            if (collision.gameObject.tag == HitTag[i])
            {
                switch (transform.tag)
                {
                    case "Player":
                        if (collision.TryGetComponent<Bullet>(out Bullet b) && Time.time - time > 1f)
                        {
                            if (!Imunity)
                            {
                                Hit(b.Damage);
                            }
                            b.DestroyBullet();
                            time = Time.time;
                        }
                        if (collision.TryGetComponent<Status>(out Status s) && Time.time - time > 1f) //���� ��� �ִ� ���� ����(trigger�� ����)�� ���� �ǰ��϶�
                        {
                            if (!Imunity) //���� �ߺ� �ǰ� ����
                            {
                                Hit(s.atk);
                            }
                            time = Time.time;
                        }
                        break;
                    default:
                        if (collision.TryGetComponent<Bullet>(out Bullet b2))
                        {
                            if (!Imunity)
                            {
                                Hit(b2.Damage);
                            }
                            b2.DestroyBullet();
                            time = Time.time;
                        }
                        if (collision.TryGetComponent<Status>(out Status s2)) //���� ��� �ִ� ���� ����(trigger�� ����)�� ���� �ǰ��϶�
                        {
                            if (!Imunity) //���� �ߺ� �ǰ� ����
                            {
                                Hit(s2.atk);
                            }
                            time = Time.time;
                        }
                        break;
                }

            }
        }
    } // �Ѿ˰� ���� Trigger�浹�� �� �ʿ�, Bullet�� ��ü ��������ŭ ����

    private void OnEnable()
    {
        if (transform.CompareTag("Mob"))
        {
            curHp = hp;
            var ui = healthUI.GetComponent<Image>();
            ui.fillAmount = curHp / hp;
        } //�� �����ÿ� UI������Ʈ�� ���� �ʱ�ȭ�� ���� ���
        time = Time.time;
    }


    public void Hit(float enemyAtk)
    {
        if (healthUI != null)
        {
            switch (transform.tag)
            {
                case "Player":
                    healthUI.GetComponent<UiControl>().GetHurt();
                    curHp -= 0.5f;
                    if (curHp <= 0) player_lose = true;
                    break;
                case "Boss":
                    float dmg;
                    if (def >= enemyAtk) dmg = 1f; //������ ���������� ������ 1�� ����
                    else dmg = enemyAtk - def; //�ݴ� ���, ������ �氨�Ѹ�ŭ ������ ��� 
                    curHp -= dmg;
                    if (curHp <= 0) { player_win = true; }
                    break;
                case "Mob":
                    if (def >= enemyAtk) dmg = 1f; //������ ���������� ������ 1�� ����
                    else dmg = enemyAtk - def; //�ݴ� ���, ������ �氨�Ѹ�ŭ ������ ��� 
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
                    healthUI.GetComponent<Image>().fillAmount = curHp / hp; //���������� ü�� ui ������Ʈ
                    break;
            }
        }
    }

}
