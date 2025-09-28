using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Health, MaxHealth;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private PlayerScript playa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxHealth = playa.hp;
        Health = playa.hp;
        healthBar.SetMaxHealth(MaxHealth);
        healthBar.SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        Health = playa.hp;
        if(playa.isAttacked && playa.canBeAttacked)
        {
            healthBar.HandleHealthChange(-1, 0.5f);
        }
    }
    
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
