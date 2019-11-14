using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class DialogueManager : MonoBehaviour
{
    public Queue<string> textToDisplay;
    public static DialogueManager self;
    public DialogueList dialogueList;

    public Dialogue CurrentDialogue { get => dialogueList.CurrentDialogue; }

    private void Awake()
    {
        self = this;
    }

    private void Start()
    {
        textToDisplay = new Queue<string>();
    }

    public void StartDialogue()
    {
        textToDisplay.Clear();

        foreach(string sentence in CurrentDialogue.sentences)
        {
            textToDisplay.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (textToDisplay.Count == 0)
        {
            EndDialogue();
            return;
        }

        string text = textToDisplay.Dequeue();
    }

    private void EndDialogue()
    {

    }

    public void AddText(List<string> text)
    {

    }
}
