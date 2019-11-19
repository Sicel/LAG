using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    //public string name;
    public int numDialogue;
    public List<string> speakers;

    [TextArea(2, 10)]
    public List<string> sentences;
    public AudioClip audio;

    [SerializeField] private List<bool> usePrevSpeaker;
}
