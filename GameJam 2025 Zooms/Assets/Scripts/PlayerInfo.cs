using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Health, MaxHealth;

    [SerializeField]
    private HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        healthBar.SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            healthBar.HandleHealthChange(-20, 0.5f);
        }

        if (Input.GetKeyDown("h")){
            healthBar.HandleHealthChange(20, 0.5f);
        }
    }
    
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
