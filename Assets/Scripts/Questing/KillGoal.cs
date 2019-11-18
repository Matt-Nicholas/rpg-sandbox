using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal {

    public int EnemyId { get; set; }

    public KillGoal(Quest quest, int enemyId, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        EnemyId = enemyId;
        Description = description;
        Completed = completed;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        if(enemy.ID == EnemyId)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
