using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isAttacked = false;
    private Rigidbody2D rb;
    public float hp = 5;
    public SimpleFlash flashDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InflictDamage()
    {
        if (isAttacked == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
            flashDamage.Flash();
            hp -= 1;
            isAttacked = false;
        }

    }
}
