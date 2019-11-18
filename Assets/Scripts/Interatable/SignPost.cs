using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost: ActionItem
{
    [SerializeField] string title;
    [SerializeField] string[] dialogue;

    public override void Interact()
    {
        DialogueManager.Instance.AddNewDialogue(dialogue, title);
        Debug.Log("Interacting with SignPost: " + gameObject.name);
    }

}
