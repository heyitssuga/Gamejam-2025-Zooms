using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Health, MaxHealth;
    private float lastHealth;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private PlayerScript playa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastHealth = playa.hp;
        MaxHealth = playa.hp;
        Health = playa.hp;
        healthBar.SetMaxHealth(MaxHealth);
        healthBar.SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        Health = playa.hp;
        if(playa.hp == lastHealth - 1)
        {
            healthBar.HandleHealthChange(-1, 0.5f);
        }

        lastHealth = playa.hp;
    }
    
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
