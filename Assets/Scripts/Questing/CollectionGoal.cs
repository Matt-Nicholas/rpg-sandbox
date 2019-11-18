using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal {

    public string ItemID { get; set; }

    public CollectionGoal(Quest quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        ItemID = itemID;
        Description = description;
        Completed = completed;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToInventory += ItemPickedUp;
    }

    void ItemPickedUp(Item item)
    {
        if(item.ObjectSlug == ItemID)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
