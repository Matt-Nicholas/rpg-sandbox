using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public CharacterStats CharacterStats;
    public int CurrentHealth;
    public int MaxHealth;
    public PlayerLevel PlayerLevel { get; set; }

    private void Awake()
    {
        PlayerLevel = GetComponent<PlayerLevel>();
        CurrentHealth = MaxHealth;
        CharacterStats = new CharacterStats(10, 10, 10);
        UIEventHandler.HealthChanged(MaxHealth, CurrentHealth);
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth < 0) CurrentHealth = 0;
        if(CurrentHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged(MaxHealth, CurrentHealth);
    }

    private void Die()
    {
        CurrentHealth = MaxHealth;
        UIEventHandler.HealthChanged(MaxHealth, CurrentHealth);
    }
}
