using UnityEngine;

public class CheckPlayerInRange : MonoBehaviour
{
    public GroundEnemy thisEnemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
      if( col.gameObject.tag == "Player")
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
