using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler:MonoBehaviour {

    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory = delegate { };
    public static event ItemEventHandler OnItemEquiped = delegate { };

    public delegate void PlayerHealthEventHandler(int maxHealth, int currentHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged = delegate { };

    public delegate void StatEventHandler();
    public static event StatEventHandler OnStatsChanged = delegate { };

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChanged = delegate { };

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquiped(Item item)
    {
        OnItemEquiped(item);
    }

    public static void HealthChanged(int maxHealth, int currentHealth)
    {
        OnPlayerHealthChanged(maxHealth, currentHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLevelChanged()
    {
        OnPlayerLevelChanged();
    }
}
