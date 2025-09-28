using UnityEngine;

public class CheckPointEnter : MonoBehaviour
{
    [SerializeField] private CheckPointEnemyManager checkPointEnemyManager;
    public int checkPointNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointEnemyManager.PlayerEnterCheckPoint(checkPointNumber);
            this.gameObject.SetActive(false);
        }
    }
}
