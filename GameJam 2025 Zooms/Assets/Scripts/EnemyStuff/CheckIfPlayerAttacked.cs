using UnityEngine;

public class CheckIfPlayerAttacked : MonoBehaviour
{
    public GroundEnemy thisEnemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
      if( col.gameObject.layer == LayerMask.NameToLayer("PlayerHit"))
        {
            thisEnemy.isAttacked = true;
        }
    }
}
