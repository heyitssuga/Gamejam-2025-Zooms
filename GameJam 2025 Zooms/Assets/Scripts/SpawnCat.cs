using UnityEngine;

public class SpawnCat : MonoBehaviour
{
    public GameObject ShowObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowObject.SetActive(true);
        Destroy(gameObject);
    }
}
