using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

    public string[] dialogue;
    public string myName;

    public override void Interact()
    {
        DialogueManager.Instance.AddNewDialogue(dialogue, myName);

        Debug.Log("Interacting with NPC: " + gameObject.name);
    }
}
