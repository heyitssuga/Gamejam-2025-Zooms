using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Mono.Cecil;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class GroundEnemy : MonoBehaviour
{

    public float hp = 3;
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    private Animator animator;
    public float enemyInvincbleTime = 0.8f;
    private bool isDead = false;
    public bool isWalking = false;
    public SimpleFlash flashDamage;



    public bool inAttackRange;
    public AnimationClip clip1;
    private float lengthClip;
    private float waitTime  = 0;
    public GameObject hitBox;

    public bool isAttacked = false;

    private bool isFacingRight = false;

    private bool isCloseX = false;
    private bool isCloseY = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        Flip();
        lengthClip = clip1.length;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        checkShouldFlip();
        checkDistance();
        animator.SetBool("isHurt", isAttacked);
        InflictDamage();
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction * moveSpeed;
            //float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (isWalking)
            {

                if (isCloseX == true && isCloseY == false)
                {
                    rb.linearVelocity = new Vector2(0, moveDirection.y) * moveSpeed;
                    animator.SetBool("isMoving", true);

                }
                else if (isCloseY == true && isCloseX == false)
                {
                    rb.linearVelocity = new Vector2(moveDirection.x, 0) * moveSpeed;
                    animator.SetBool("isMoving", true);

                }
                else if (isCloseX == true && isCloseY == true)
                {
                    rb.linearVelocity = new Vector2(0, 0);
                    animator.SetBool("isMoving", false);
                }
                else
                {
                    rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
                    animator.SetBool("isMoving", true);
                }
            }
        }
    }

    private void checkDistance()
    {
        if(Mathf.Abs(target.position.x - transform.position.x) <= 1)
        {
            isCloseX = true;
        }
        else
        {
            isCloseX = false;
        }

        if (Mathf.Abs(target.position.y - transform.position.y) <= 0.2)
        {
            isCloseY = true;
        }
        else
        {
            isCloseY = false;
        }
    }

    private void InflictDamage()
    {
        if(isAttacked == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
            isWalking = false;
            flashDamage.Flash();
            hp -= 1;
            isAttacked = false;
        }

    }
    private void checkShouldFlip()
    {
        if (isFacingRight == true && target.position.x < transform.position.x)
        {
            Flip();
        }
        else if (isFacingRight == false && target.position.x > transform.position.x)
        {
            Flip();
        }

    }

    private void Attack()
    {
        if ((waitTime <= 0))
        {

            if (inAttackRange == true)
            {
                rb.linearVelocity = new Vector2(0, 0);
                hitBox.SetActive(true);
                animator.SetTrigger("Attack");
                waitTime = lengthClip;
                isWalking = false;
            }
            else
            {
                isWalking = true;
                hitBox.SetActive(false);
            }
        }
        else if ((waitTime > 0))
        {
            waitTime -= Time.deltaTime;
        }
    }

    /*
     * Flip just flips the player sprite.
     */
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 ls = transform.localScale;
        ls.x *= -1f;
        transform.localScale = ls;
    }


}