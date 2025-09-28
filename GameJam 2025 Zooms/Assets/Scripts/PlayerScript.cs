using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isAttacked = false;
    private Rigidbody2D rb;
    public float hp = 5;
    public SimpleFlash flashDamage;
    private float timer;
    private bool canBeAttacked = true;
    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(player);
        }
        if(!canBeAttacked)
        {
            isAttacked = false;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canBeAttacked = true;
                timer = 2f;
            }
        }
        if (canBeAttacked)
        {
            InflictDamage();
        }
    }

    private void InflictDamage()
    {
        if (isAttacked == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
            flashDamage.Flash();
            hp -= 1;
            isAttacked = false;
            canBeAttacked = false;
        }

    }
}
