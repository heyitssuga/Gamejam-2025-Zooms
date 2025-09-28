using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isAttacked = false;
    private Rigidbody2D rb;
    public float hp = 5;
    public SimpleFlash flashDamage;
    private float timer;
    public bool canBeAttacked = true;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite[] sprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(player);
        }
        if (!canBeAttacked)
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = sprites[2];
            isAttacked = false;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canBeAttacked = true;
                timer = 2f;
                player.GetComponent<Animator>().enabled = true;
                if (!animator.GetBool("IsMoving"))
                {
                    player.GetComponent<SpriteRenderer>().sprite = sprites[0];
                } else
                {
                    player.GetComponent<SpriteRenderer>().sprite = sprites[1];
                }
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
            flashDamage.Flash();
            hp -= 1;
            isAttacked = false;
            canBeAttacked = false;
        }

    }
}
