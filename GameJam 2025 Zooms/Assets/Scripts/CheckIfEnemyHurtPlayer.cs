using UnityEngine;

public class CheckIfEnemyHurtPlayer : MonoBehaviour
{
    public PlayerScript player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            player.isAttacked = true;
        }
    }
}
