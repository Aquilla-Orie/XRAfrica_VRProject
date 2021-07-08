using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public string[] dialogue;
    public string name;

    private void Start()
    {
        DisplayScript();
    }

    public void DisplayScript()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
    }
}
