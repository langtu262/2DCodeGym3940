using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemothAI : EnemyAI
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Animator anim;
    private Vector3 targetPos;
    private int isIdle;

    void Start()
    {
        
        transform.position = pointA.position;
        isIdle = Animator.StringToHash("isIdle");
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;*/
        if (transform.position==pointA.position) 
        {
            targetPos = pointB.position;
            sp.flipX = false;
            anim.SetTrigger(isIdle);

        }
        else if(transform.position==pointB.position)
        {
            targetPos = pointA.position;
            sp.flipX = true;
            anim.SetTrigger(isIdle);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
