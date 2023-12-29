using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isAttack;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Vector2 direction;
    public Vector2 face_direction;
    [HideInInspector]
    public Vector2 previousPosition;
    [HideInInspector]
    public Vector2 currentPosition;

    [Header("Target")]
    public GameObject target;
    [Header("MovementAnimation")]
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        direction = (target.transform.position - transform.position).normalized;

        currentPosition = transform.position;
        face_direction = (currentPosition - previousPosition).normalized;
        previousPosition = currentPosition; //방향 벡터 정보들 갱신

        if (isAttack) // 공격 중에는 보스는 이동 못함
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;

            if(face_direction.magnitude > 0)
            {
                anim.SetFloat("h", face_direction.x);
                anim.SetFloat("v", face_direction.y);
            } // 초근접의 경우 움직임이 없기에 face_direction을 쓰면 에러
            else
            {
                anim.SetFloat("h", direction.x);
                anim.SetFloat("v", direction.y);
            }
        }
    }
}
