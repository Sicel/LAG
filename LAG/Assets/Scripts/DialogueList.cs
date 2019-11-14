using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue List")]
public class DialogueList : ScriptableObject
{
    [SerializeField] private int currentIndex = 0;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public Dialogue CurrentDialogue { get { return dialogues[currentIndex]; } }

    public int CurrentIndex
    {
        get => currentIndex;
        set
        {
            currentIndex = value;
        }
    }
}
