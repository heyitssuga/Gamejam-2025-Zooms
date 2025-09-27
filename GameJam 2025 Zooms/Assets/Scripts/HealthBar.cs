using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height;

    private float currentTempHealth;

    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private RectTransform tempHealthBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float newWidth = (Health / MaxHealth) * Width;
        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }

    public void SetTempHealth(float tempHealth)
    {
        currentTempHealth = tempHealth;
    }

    public void UpdateTempHealth()
    {
        float newWidth = (currentTempHealth / MaxHealth) * Width;
        tempHealthBar.sizeDelta = new Vector2(newWidth, Height);
    }
    
    public void HandleHealthChange(float healthChange, float trailTime)
    {
        float oldHealth = Health;

        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        UpdateHealthBar();

        SetTempHealth(oldHealth);
        StartCoroutine(SmoothTempHealthBar(oldHealth, Health, trailTime));

    }

    private IEnumerator SmoothTempHealthBar(float fromHealth, float toHealth, float duration)
    {
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            currentTempHealth = Mathf.Lerp(fromHealth, toHealth, elapsedTime / duration);
            UpdateTempHealth();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentTempHealth = toHealth;
        UpdateTempHealth();
    }
}   
