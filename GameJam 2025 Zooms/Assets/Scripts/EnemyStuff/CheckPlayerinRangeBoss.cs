using UnityEngine;

public class CheckPlayerinRangeBoss : MonoBehaviour
{
    public Boss thisEnemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            thisEnemy.inAttackRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            thisEnemy.inAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            thisEnemy.inAttackRange = false;
        }
    }
}
