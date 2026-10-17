using DG.Tweening;
using TMPro;
using UnityEngine;

public class CombatantView : MonoBehaviour
{
    [SerializeField] protected TMP_Text healthText;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    
    public int MaxHealth {get; private set;}
    public int CurrentHealth {get; private set;}

    protected void SetupBase(int health, Sprite image)
    {
        MaxHealth = CurrentHealth = health;
        spriteRenderer.sprite = image;
        UpdateHealthText();
    }

    protected void UpdateHealthText()
    {
        healthText.text = CurrentHealth + "/" + MaxHealth;
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        
        // small animation
        transform.DOShakePosition(0.2f, 0.5f);
        UpdateHealthText();
    }
}
