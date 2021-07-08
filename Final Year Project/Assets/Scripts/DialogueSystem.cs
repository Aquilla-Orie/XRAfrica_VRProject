using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueLines = new List<string>();
    public string npcName;
    public GameObject dialoguePanel;

    Button continueButton;
    TextMeshProUGUI dialogueText, nameText;
    int dialogueIndex;

    private void Awake()
    {
        //Grabbing all components from the dialogue panel
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        nameText = dialoguePanel.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);

        //Creating a singleton of the DialogueSystem Class
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        AddNewDialogue(dialogueLines.ToArray(), npcName);
    }

    public void AddNewDialogue(string[] lines, string name)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        npcName = name;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
