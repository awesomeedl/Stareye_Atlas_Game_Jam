using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacebarContinueDialogue : MonoBehaviour
{
    DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if(dialogueManager.started && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
