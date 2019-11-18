﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    public List<BaseStat> Stats = new List<BaseStat>();

    public CharacterStats(int power, int defense, int attackSpeed)
    {
        Stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Power, power, "Power"),
            new BaseStat(BaseStat.BaseStatType.Defense, defense, "Defense"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "Atk Spd"),
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return Stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}