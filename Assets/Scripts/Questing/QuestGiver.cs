using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    private Quest Quest { get; set; } 
    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;

    public override void Interact()
    {
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();   
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue("Thanks for evrything!.", name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if(Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueManager.Instance.AddNewDialogue(new string[] { "Thanks for that! Here's your reward.", "Good bye."}, name);
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue("Please finish helping me for your reward.", name);

        }
    }
}
