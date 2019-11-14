using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public DialogueList dialogueList;
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialogue;

    private Queue<string> speakers;
    private Queue<string> textToDisplay;
    //public static DialogueManager self;

    public Dialogue CurrentDialogue { get => dialogueList.CurrentDialogue; }

    private void Start()
    {
        speakers = new Queue<string>();
        textToDisplay = new Queue<string>();
    }

    public void StartDialogue()
    {
        speakers.Clear();
        textToDisplay.Clear();

        for (int i = 0; i < CurrentDialogue.numDialogue; i++)
        {
            speakers.Enqueue(CurrentDialogue.speakers[i]);
            textToDisplay.Enqueue(CurrentDialogue.sentences[i]);
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

        speaker.text = speakers.Dequeue();
        dialogue.text = textToDisplay.Dequeue();
    }

    private void EndDialogue()
    {

    }
}
