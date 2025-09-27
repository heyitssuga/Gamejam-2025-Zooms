using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackScript : MonoBehaviour
{

    InputAction attackAction;
    private float attackCooldown = 10f;
    public bool hit1, hit2, hit3;
    private bool canAttack, canAttack2, canAttack3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions["Attack"];
        canAttack = true;
        canAttack2 = false;
        canAttack3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown <= 0)
        {
            Debug.Log("Refreshed!");
            hit1 = false;
            hit2 = false;
            hit3 = false;
            canAttack = true;
            attackCooldown = 10f;
        }

        if (hit1)
        {
            attackCooldown -= Time.deltaTime;
        }

        if(!hit2 && attackCooldown <= 7f)
        {
            canAttack2 = true;
        }

        if(!hit3 && attackCooldown <= 4f)
        {
            canAttack3 = true;
        }

        if (attackAction.IsPressed() && canAttack)
        {
            hit1 = true;
            canAttack = false;
            Debug.Log("Attack 1");
        }
       else if(attackAction.IsPressed() && canAttack2)
        {
            hit2 = true;
            canAttack2 = false;
            Debug.Log("Attack 2");
        }
        else if (attackAction.IsPressed() && canAttack3)
        {
            hit3 = true;
            canAttack3 = false;
            Debug.Log("Attack 3");
        }
    }

}
