using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueManager : MonoBehaviour
{
    public Queue<string> textToDisplay;
    public static DialogueManager self;

    private void Awake()
    {
        self = this;
    }

    private void Start()
    {
        textToDisplay = new Queue<string>();
    }

    public void AddText(List<string> text)
    {

    }

    public void DisplayText()
    {

    }
}
