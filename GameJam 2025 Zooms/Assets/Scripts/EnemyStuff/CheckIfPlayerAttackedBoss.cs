using UnityEngine;

public class CheckIfPlayerAttackedBoss : MonoBehaviour
{
    public Boss thisEnemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PlayerHit"))
        {
            thisEnemy.isAttacked = true;
        }
    }
}
