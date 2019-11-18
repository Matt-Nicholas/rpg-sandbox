using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSlayer : Quest {

    private void Start()
    {
        QuestName = "Slime Slayer";
        Description = "Kill 3 slimes";
        ItemReward = ItemDatabase.Instance.GetItem("potion_log");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this, 0, "Kill 3 Slimes", false, 0, 3));
        Goals.Add(new CollectionGoal(this, "sword", "Find the guards sword.", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
