using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Mono.Cecil;

public class GroundEnemy : MonoBehaviour
{

    public float hp = 3;
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;

    public bool inAttackRange;

    private bool isFacingRight = true;

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
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        checkShouldFlip();
        checkDistance();
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
            if (isCloseX == true && isCloseY == false)
            {
                rb.linearVelocity = new Vector2(0, moveDirection.y) * moveSpeed;
            }
            else if (isCloseY == true && isCloseX == false)
            {
                rb.linearVelocity = new Vector2(moveDirection.x, 0) * moveSpeed;
            }
            else if(isCloseX == true && isCloseY == true)
            {
                rb.linearVelocity = new Vector2(0, 0);
            }
            else
            {
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
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

    private void attack()
    {
        if (inAttackRange == true)
        {
            Debug.Log("attack");
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