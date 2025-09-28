using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackScript : MonoBehaviour
{

    InputAction attackAction;
    private float attackCooldown = 10f;
    private float length, length2, length3;
    public bool hit1, hit2, hit3;
    private bool canAttack, canAttack2, canAttack3;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip clip, clip2, clip3;
    [SerializeField] private GameObject hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions["Attack"];
        canAttack = true;
        canAttack2 = false;
        canAttack3 = false;
        length = clip.length;
        length2 = clip2.length;
        length3 = clip3.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown <= 0)
        {
            Debug.Log("Refreshed!");
            hitbox.SetActive(false);
            length = clip.length;
            length2 = clip2.length;
            length3 = clip3.length;
            hit1 = false;
            hit2 = false;
            hit3 = false;
            canAttack = true;
            attackCooldown = 10f;
        }

        if (hit1)
        {
            attackCooldown -= Time.deltaTime;
            length -= Time.deltaTime;
            if(length <= 0)
            {
                animator.SetBool("IsHit1", false);
            }
        }

        if(!hit2 && attackCooldown <= 9.5f)
        {
            hitbox.SetActive(false);
            canAttack2 = true;
        }

        if (hit2 && !canAttack2)
        {
            length2 -= Time.deltaTime;
            if (length2 <= 0)
            {
                animator.SetBool("IsHit2", false);
            }
        }

        if (!hit3 && attackCooldown <= 9f)
        {
            hitbox.SetActive(false);
            canAttack3 = true;
        }

        if(attackCooldown <= 8.5f)
        {
            hitbox.SetActive(false);
        }

        if(hit3 && !canAttack3)
        {
            length3 -= Time.deltaTime;
            if (length3 <= 0)
            {
                animator.SetBool("IsHit3", false);
            }
        }

        if (attackAction.IsPressed() && canAttack)
        {
            hitbox.SetActive(true);
            hit1 = true;
            animator.SetBool("IsHit1", true);
            canAttack = false;
            Debug.Log("Attack 1");
        }
       else if(attackAction.IsPressed() && canAttack2)
        {
            hitbox.SetActive(true);
            hit2 = true;
            animator.SetBool("IsHit2", true);
            canAttack2 = false;
            Debug.Log("Attack 2");
        }
        else if (attackAction.IsPressed() && canAttack3)
        {
            hitbox.SetActive(true);
            hit3 = true;
            animator.SetBool("IsHit3", true);
            canAttack3 = false;
            Debug.Log("Attack 3");
        }
    }
}
