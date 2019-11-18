using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager> {

    public string npcName;
    [HideInInspector]
    public List<string> dialogeLines = new List<string>();
    private GameObject dialoguePanel;
    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    EventSystem _eventSystem;

    private void Awake()
    {
        _eventSystem = EventSystem.current;

        dialoguePanel = GameObject.Find("DialoguePanel");
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        dialoguePanel.SetActive(false);

    }


    public void AddNewDialogue(string line, string npcName) { AddNewDialogue(new string[] { line,}, npcName); }
    public void AddNewDialogue(string[] lines, string npcName)
    {
        if(_eventSystem.currentSelectedGameObject != continueButton.gameObject)
            _eventSystem.SetSelectedGameObject(continueButton.gameObject);

        dialogueIndex = 0;
        dialogeLines = new List<string>(lines.Length);
        dialogeLines.AddRange(lines);
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogeLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    void ContinueDialogue()
    {
        if(dialogueIndex < dialogeLines.Count-1)
        {
            
            dialogueIndex++;
            dialogueText.text = dialogeLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
