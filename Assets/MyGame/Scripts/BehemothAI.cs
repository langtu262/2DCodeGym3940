using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehemothAI : EnemyAI
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Animator anim;
    private Transform target;
    [SerializeField] private float speedMove = 3;
    [SerializeField] private float stopDistance = 3;
    private Vector3 pointC;
    private Vector3 targetPos;
    private int isIdle;
    [SerializeField] private float attackDistance;
    void Start()
    {

        pointC = pointA.position;
        isIdle = Animator.StringToHash("isIdle");
        target=GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
           
            Vector2 dir = (target.position - transform.position).normalized;
            if (Vector2.Distance(transform.position,target.position) < stopDistance)
            {
                rb.velocity = dir* speedMove;

                if (Vector2.Distance(transform.position, target.position) < attackDistance)
                {
                    anim.SetBool("isAttack", true);
                }
                else
                {
                    anim.SetBool("isAttack", false);
                }
            }
            else if(Vector2.Distance(transform.position, target.position) > stopDistance) 
            {
                /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                     return;*/
                if (pointC == pointA.position)
                {
                    targetPos = pointB.position;
                    sp.flipX = false;
                    anim.SetTrigger(isIdle);
                    pointC = pointB.position;
                }
                if (transform.position==pointB.position)
                {
                    targetPos = pointA.position;
                    sp.flipX = true;
                    anim.SetTrigger(isIdle);
                }
                if (transform.position == pointA.position)
                {
                    pointC = pointA.position;                   
                }                      
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }        
    }

}
