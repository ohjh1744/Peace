using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);

        direction = (target.transform.position - transform.position).normalized;

        currentPosition = transform.position;
        face_direction = (currentPosition - previousPosition).normalized;
        previousPosition = currentPosition; //���� ���� ������ ����

        if (isAttack) // ���� �߿��� ������ �̵� ����
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;

            if (face_direction.magnitude > 0)
            {
                anim.SetFloat("h", face_direction.x);
                anim.SetFloat("v", face_direction.y);
            } // �ʱ����� ���? �������� ���⿡ face_direction�� ���� ����
            else
            {
                anim.SetFloat("h", direction.x);
                anim.SetFloat("v", direction.y);
            }
        }
    }
}
