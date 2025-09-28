using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject pow, crunch, boom;
    public GameObject spawn1, spawn2, spawn3, spawn4, spawn5, spawn6, spawn7, spawn8, spawn9, spawn10;

    public float hp = 3;
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    private Animator animator;
    public float enemyInvincbleTime = 0.8f;
    public bool isWalking = false;
    public SimpleFlash flashDamage;

    private bool isDead = false;
    float deadTimer = 0;
    bool startedTimer = false;

    public bool inAttackRange;
    public AnimationClip clip1;
    private float lengthClip;
    private float waitTime = 0;
    public GameObject hitBox;

    public bool isAttacked = false;

    private bool isFacingRight = false;

    private bool isCloseX = false;
    private bool isCloseY = false;
    private AudioSource sfx;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfx = GameObject.Find("Sfx").GetComponent<AudioSource>();
        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        Flip();
        lengthClip = clip1.length;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player").transform;
        if (!isDead)
        {
            checkShouldFlip();
            checkDistance();
            animator.SetBool("isHurt", isAttacked);
            CheckDead();
            if (target)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction * moveSpeed;
                //float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
                //rb.rotation = angle;
            }
        }
        else
        {
            Died();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            Attack();
            InflictDamage();
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
    }

    private void checkDistance()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) <= 1)
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
        if (isAttacked == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
            isWalking = false;
            flashDamage.Flash();
            hp -= 1;
            isAttacked = false;
            if (hp == 9)
            {
                Instantiate(pow, spawn1.transform.position, spawn1.transform.rotation);
            }
            else if (hp == 8)
            {
                Instantiate(crunch, spawn2.transform.position, spawn2.transform.rotation);
            }
            else if (hp == 7)
            {
                Instantiate(crunch, spawn4.transform.position, spawn4.transform.rotation);
            }
            else if (hp == 6)
            {
                Instantiate(pow, spawn5.transform.position, spawn5.transform.rotation);
            }
            else if (hp == 5)
            {
                Instantiate(crunch, spawn6.transform.position, spawn6.transform.rotation);
            }
            else if (hp == 4)
            {
                Instantiate(pow, spawn7.transform.position, spawn7.transform.rotation);
            }
            else if (hp == 3)
            {
                Instantiate(crunch, spawn8.transform.position, spawn8.transform.rotation);
            }
            else if (hp == 2)
            {
                Instantiate(pow, spawn9.transform.position, spawn9.transform.rotation);
            }
            else if (hp == 1)
            {
                Instantiate(pow, spawn10.transform.position, spawn10.transform.rotation);
            }
            else if (hp == 0)
            {
                Instantiate(boom, spawn3.transform.position, spawn3.transform.rotation);
            }
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
                waitTime = lengthClip + 1;
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

    private void CheckDead()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
    }
    private void Died()
    {
        if (deadTimer <= 0 && startedTimer == false)
        {
            sfx.clip = Resources.Load<AudioClip>("Audio/SFX/hammer");
            sfx.Play();
            rb.linearVelocity = new Vector2(0, 0);
            rb.rotation = Random.Range(-360, 360);
            rb.linearVelocity = new Vector2(Random.Range(100, 1000), Random.Range(100, 1000));
            deadTimer = 3f;
            startedTimer = true;
        }
        else if (deadTimer > 0 && startedTimer == true)
        {
            deadTimer -= Time.deltaTime;
        }
        else if (deadTimer <= 0 && startedTimer == true)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
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
